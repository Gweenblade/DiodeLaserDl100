using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADwin;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;
using System.IO;
using ADwin.Driver;
using Oscyloskop;
using OscyloskopT1;
using lasery;

namespace Laser
{
    public partial class Form1 : Form
    {
        bool Eventbool = false;
        double[] WAVEFORM;
        double Napięciemin = 0;
        double Napięciemax = 80000;
        double Tempmin = 15, TempMinAdvanced = 0, TempMaxAdvanced = 0;
        double Tempmax = 30;
        double Krokprad = 100;
        double Kroktemp = 0.1;
        int Graphcombo = 1;
        long Stoper;
        int Kroktprad = 100;
        int Krokttemp = 100;
        int Pradindex = 0, Tempindex = 0, lambdaindex = 0, MHzindex = 0, kindex = 0, calkaindex = 0;
        bool pause = false, Graphrubber = false, Threadkiller = false;
        Stopwatch stopWatch = new Stopwatch();
        Stopwatch stopWatchV = new Stopwatch();
        Stopwatch stopWatchT = new Stopwatch();
        PointPairList PPL1 = new PointPairList();
        PointPairList PPL2 = new PointPairList();
        PointPairList PPL = new PointPairList();
        PointPairList PPLcalka = new PointPairList();
        PointPairList PPLTHz = new PointPairList();
        PointPairList PPLlambda = new PointPairList();
        PointPairList PPLk = new PointPairList();
        SymbolType ST1 = SymbolType.None;
        obsługaAdWina AW;
        AdvancedMeasurements Advanced;
        StringBuilder SB, SBoscyl, SBloop;
        ThreadStart VSCAN, TSCAN, VTSCAN, TLO, ADVANCEDSCANK, ADVANCEDSCANNM, ADVANCEDSCANTHZ, WMTESTER, DL100tuning;
        Thread Vscan, Tscan, VTscan, Tlo, AdvancedScanK, AdvancedScannm, AdvancedScanthz, wmtester, DL100TUNING;
        public static EventWaitHandle EWHprzestroj, EWHustawiono, EWHbreak, EWHendoftuning;
        DateTime thisDay = DateTime.Today;
        Help help;
        ScalingParameters scalingParameters;
        private BackgroundWorker myWorker = new BackgroundWorker();
        OscyloskopT1.Form1 Oscyl;
        private bool stopthemeasurements = false;
        public bool StopTheMeasurements
        {
            get { return stopthemeasurements; }
            set { stopthemeasurements = value; }
        }
        public Form1()
        {
            Form2 form2 = new Form2();
            InitializeComponent();
            Combofalo.Enabled = false;
            Oscyl = new OscyloskopT1.Form1();
            help = new Help();
            scalingParameters = new ScalingParameters();
            Advanced = new AdvancedMeasurements();
            AW = new obsługaAdWina(aDwinSystem1);
            VSCAN = new ThreadStart(PrzestrajanieVpróba);
            TSCAN = new ThreadStart(PrzestrajanieTpróba);
            VTSCAN = new ThreadStart(PrzestrajanieVTpróba);
            ADVANCEDSCANK = new ThreadStart(AdvancedLoopk);
            TLO = new ThreadStart(RysowanieWykresów);
            WMTESTER = new ThreadStart(SeederCheckerFunction);
            Tlo = new Thread(TLO);
            wmtester = new Thread(WMTESTER);
            Vscan = new Thread(VSCAN);
            Tscan = new Thread(TSCAN);
            VTscan = new Thread(VTSCAN);
            AdvancedScanK = new Thread(ADVANCEDSCANK);
            DL100tuning = new ThreadStart(DL100Vtuningf);
            DL100TUNING = new Thread(DL100tuning);
            EWHprzestroj = new EventWaitHandle(false, EventResetMode.AutoReset, "PRZESTROJ");
            EWHbreak = new EventWaitHandle(false, EventResetMode.AutoReset, "ZATRZYMAJ");
            EWHendoftuning = new EventWaitHandle(false, EventResetMode.AutoReset, "KONIEC");
            try
            {
                EWHustawiono = EventWaitHandle.OpenExisting("USTAWIONO");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("PROBLEM: " + ex.Message);
                EWHustawiono = new EventWaitHandle(false, EventResetMode.AutoReset, "USTAWIONO");
            }

        }
        private void Bla()
        {
            MessageBox.Show("Bla");
        }
        void RysowanieWykresów()
        {
            while (true)
            {
                if (Graphrubber == true)
                {
                    PPLcalka.Clear();
                    PPLTHz.Clear();
                    PPLlambda.Clear();
                    PPLk.Clear();
                    PPL.Clear();
                    Graphrubber = false;
                }
                if (Radiooscylo.Checked)
                {
                    if (Laser.Properties.Settings.Default.Graphsettingoption == 0)
                        RysujWF(Oscyl.os.czytajW0(1));
                    else
                    if (Laser.Properties.Settings.Default.Graphsettingoption == 1)
                        Rysujcalke();
                }
                if (Radiofalo.Checked)
                {
                    if (Laser.Properties.Settings.Default.Graphsettingoption == 2)
                        Rysujlambda();
                    if (Laser.Properties.Settings.Default.Graphsettingoption == 3)
                        RysujTHz();
                    if (Laser.Properties.Settings.Default.Graphsettingoption == 4)
                        Rysujk();
                }
                Rysujprad();
                Rysujtemp();
                Thread.Sleep(5);
            }
        }

        // private int SkalNaTemp(double T)
        //  {
        //     double V;
        //    int POM;
        //     V = (T - 19.037) / (-0.005);
        //   POM = Convert.ToInt32(V);
        //    return POM;
        //   }

        // private int SkalNaPrad(double A)
        //  {
        //      double V;
        //      int POM;
        //     V = (A + 0.703) / (0.008);
        //    POM = Convert.ToInt32(V);
        //     return POM;
        //  }
        //  private double Templine(int V)
        //  {
        //      return -0.005 * V + 19.037;
        //  }

        // private double Pradline(int V)
        // {
        //     return 0.008 * V - 0.703;
        //  }


        private void odczytOscylo()
        {
            WAVEFORM = new double[2500];
            WAVEFORM = Oscyl.os.czytajW0(1);
        }
        private double zapisOscylo()
        {
            int i;
            WAVEFORM = new double[2500];
            WAVEFORM = Oscyl.os.czytajW0(1);
            double sum = 0, sr = 0;
            for (i = 0; i < 2500; i++)
            {
                sum = sum + WAVEFORM[i];
            }
            sr = sum / 2500;
            return sr;
        }

        public void RysujWF(double[] WF)
        {
            PPL.Clear();
            int refresher = 0;
            for (int i = 0; i < WF.Length; i++)
            {
                PPL.Add(i, WF[i]);
            }
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Iterator";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Sygnał";
            zedGraphControl3.GraphPane.XAxis.Scale.Max = WF.Length;
            zedGraphControl3.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.AddCurve("Wskazania oscyloskopu", PPL, Color.Red, SymbolType.None);
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
        }
        public void Rysujcalke()
        {

            int i = 0;
            WAVEFORM = new double[2500];
            WAVEFORM = Oscyl.os.czytajW0(1);
            double sum = 0, sr = 0;
            for (i = 0; i < 2500; i++)
            {
                sum = sum + WAVEFORM[i];
            }
            sr = sum;
            if (calkaindex > 300)
            {
                PPLcalka.RemoveAt(0);
                PPLcalka.Add(calkaindex, sr);
            }
            else
            {
                PPLcalka.Add(calkaindex, sr);
            }
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Czas (s)";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Wartość całki sygnału";
            zedGraphControl3.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.AddCurve("Całka z sygnału oscyloskopu", PPLcalka, Color.Red, SymbolType.None);
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
            calkaindex = calkaindex + 1;
        }
        public void Rysujprad()
        {
            double POM;
            POM = AW.odczytPrad();
            int wartosc;
            wartosc = AW.odczytPrad();
            POM = scalingParameters.Pradline(wartosc);
            zedGraphControl1.GraphPane.CurveList.Clear();
            if (Pradindex > 1000)
            {
                PPL1.RemoveAt(0);
                PPL1.Add(stopWatchV.ElapsedMilliseconds / 1000, POM);
            }
            else
            {
                PPL1.Add(stopWatchV.ElapsedMilliseconds / 1000, POM);
            }
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Czas (s)";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Prąd (mA)";
            zedGraphControl1.GraphPane.AddCurve("Prąd", PPL1, Color.Blue, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            Pradindex = Pradindex + 1;
        }

        public void Rysujtemp()
        {
            double POM;
            int wartosc;
            wartosc = AW.odczytTemp();
            POM = scalingParameters.Templine(wartosc);
            zedGraphControl2.GraphPane.CurveList.Clear();
            if (Tempindex > 1000)
            {
                PPL2.RemoveAt(0);
                PPL2.Add(stopWatchT.ElapsedMilliseconds / 1000, POM);
            }
            else
            {
                PPL2.Add(stopWatchT.ElapsedMilliseconds / 1000, POM);
            }
            zedGraphControl2.GraphPane.XAxis.Title.Text = "Czas (s)";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "Temperatura (°C)";
            zedGraphControl2.GraphPane.AddCurve("Temperatura", PPL2, Color.Blue, SymbolType.None);
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
            Tempindex = Tempindex + 1;
        }
        public void WykresProbny()
        {
            double POM;
            POM = 1;
            zedGraphControl3.GraphPane.CurveList.Clear();
            PPLlambda.Add(lambdaindex, POM);
            if (lambdaindex > 300)
            {
                PPLlambda.RemoveAt(0);
                PPLlambda.Add(lambdaindex, POM);
            }
            else
            {
                PPLlambda.Add(lambdaindex, POM);
            }
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Czas (s)";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Długość fali (nm)";
            zedGraphControl3.GraphPane.AddCurve("Długość fali", PPLlambda, Color.Blue, SymbolType.None);
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
            lambdaindex = lambdaindex + 1;
        }
        public void Rysujlambda()
        {
            double POM;
            POM = Wavecontrol.ReadWavelenght();
            zedGraphControl3.GraphPane.CurveList.Clear();
            if (lambdaindex > 300)
            {
                PPLlambda.RemoveAt(0);
                PPLlambda.Add(lambdaindex, POM);
            }
            else
            {
                PPLlambda.Add(lambdaindex, POM);
            }
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Czas (s)";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Długość fali (nm)";
            zedGraphControl3.GraphPane.AddCurve("Długość fali", PPLlambda, Color.Blue, SymbolType.None);
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
            lambdaindex = lambdaindex + 1;
        }

        public void RysujTHz()
        {
            double POM;
            POM = Wavecontrol.ReadHZ();
            zedGraphControl3.GraphPane.CurveList.Clear();
            PPLTHz.Add(MHzindex, POM);
            if (MHzindex > 300)
            {
                PPLTHz.RemoveAt(0);
                PPLTHz.Add(MHzindex, POM);
            }
            else
            {
                PPLTHz.Add(MHzindex, POM);
            }
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Czas (s)";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Częstotliwość (THz)";
            zedGraphControl3.GraphPane.AddCurve("Częstotliwość", PPLTHz, Color.Blue, SymbolType.None);
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
            MHzindex = MHzindex + 1;
        }

        public void Rysujk()
        {
            double POM;
            POM = Wavecontrol.Readcm();
            zedGraphControl3.GraphPane.CurveList.Clear();
            if (kindex > 300)
            {
                PPLk.RemoveAt(0);
                PPLk.Add(kindex, POM);
            }
            else
            {
                PPLk.Add(kindex, POM);
            }
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Czas (s)";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Liczba falowa (cmˉ¹)";
            zedGraphControl3.GraphPane.AddCurve("Liczba falowa", PPLk, Color.Blue, SymbolType.None);
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
            kindex = kindex + 1;
        }
        public void Intro()
        {

            if (Checknm.Checked == true)
            {
                SB.Append(" Długość fali (nm)");
                SBloop.Append(" Długość fali (nm)");
            }
            if (Checkk.Checked == true)
            {
                SB.Append(" Liczba falowa (cm)");
                SBloop.Append(" Liczba falowa (cm)");
            }
            if (CheckMHz.Checked == true)
            {
                SB.Append(" Częstotliwość (MHz)");
                SBloop.Append(" Częstotliwość (MHz)");
            }
            if (CheckeV.Checked == true)
            {
                SB.Append(" Energia (eV)");
                SBloop.Append(" Energia (eV)");
            }
            if (Checkoscylo.Checked == true)
            {
                SB.Append(" Wskazania oscyloskopu");
                SBloop.Append(" Wskazania oscyloskopu");
            }
            SB.Append(Environment.NewLine);
        }
        public void Wykonajpomiar()
        {
            int i = 0, ave = 0, Timeave = 0;
            double SUMW = 0, SUMK = 0, SUMV = 0, SUME = 0, SUMO = 0;
            int.TryParse(Averages.Text, out ave);
            int.TryParse(TimeAverages.Text, out Timeave);
            double[] WAVET, WAVENT, ENERGYT, FREQT, OSCYLOT;
            WAVET = new double[ave];
            WAVENT = new double[ave];
            ENERGYT = new double[ave];
            FREQT = new double[ave];
            OSCYLOT = new double[ave];
            for (i = 0; i < ave; i++)
            {
                if (Checknm.Checked == true)
                {
                    SUMW = SUMW + Wavecontrol.ReadWavelenght();
                    WAVET[i] = Wavecontrol.ReadWavelenght();
                }
                if (Checkk.Checked == true)
                {
                    SUMK = SUMK + Wavecontrol.Readcm();
                    WAVENT[i] = Wavecontrol.Readcm();
                }
                if (CheckMHz.Checked == true)
                {
                    SUMV = SUMV + Wavecontrol.ReadHZ();
                    FREQT[i] = Wavecontrol.ReadHZ();
                }
                if (CheckeV.Checked == true)
                {
                    SUME = SUME + Wavecontrol.ReadEnergy();
                    ENERGYT[i] = Wavecontrol.ReadEnergy();
                }
                if (Checkoscylo.Checked == true)
                {
                    SUMO = SUMO + zapisOscylo();
                    OSCYLOT[i] = zapisOscylo();
                }
                Thread.Sleep(Timeave);
            }

            if (Checknm.Checked == true)
            {
                for (i = 0; i < ave; i++)
                {
                    SB.Append(" " + WAVET[i]);
                    SBloop.Append(" " + WAVET[i]);
                }
                if (AveY.Checked)
                {
                    SUMW = SUMW / ave;
                    SB.Append(" Średnia: " + SUMW);
                    SBloop.Append(" Średnia: " + SUMW);
                }

            }
            if (Checkk.Checked == true)
            {
                for (i = 0; i < ave; i++)
                {
                    SB.Append(" " + WAVENT[i]);
                    SBloop.Append(" " + WAVENT[i]);
                }
                if (AveY.Checked)
                {
                    SUMK = SUMK / ave;
                    SB.Append(" Średnia: " + SUMK);
                    SBloop.Append(" Średnia: " + SUMK);
                }

            }
            if (CheckMHz.Checked == true)
            {
                for (i = 0; i < ave; i++)
                {
                    SB.Append(" " + FREQT[i]);
                    SBloop.Append(" " + FREQT[i]);
                }
                if (AveY.Checked)
                {
                    SUMV = SUMV / ave;
                    SB.Append(" Średnia: " + SUMV);
                    SBloop.Append(" Średnia: " + SUMV);
                }

            }
            if (CheckeV.Checked == true)
            {
                for (i = 0; i < ave; i++)
                {
                    SB.Append(" " + ENERGYT[i]);
                    SBloop.Append(" " + ENERGYT[i]);
                }
                if (AveY.Checked)
                {
                    SUME = SUME / ave;
                    SB.Append(" Średnia: " + SUME);
                    SBloop.Append(" Średnia: " + SUME);
                }

            }
            if (Checkoscylo.Checked == true)
            {
                for (i = 0; i < ave; i++)
                {
                    SB.Append(" " + OSCYLOT[i]);
                    SBloop.Append(" " + OSCYLOT[i]);
                }
                if (AveY.Checked)
                {
                    SUMO = SUMO / ave;
                    SB.Append(" Średnia: " + SUMO);
                    SBloop.Append(" Średnia: " + SUMO);
                }

            }
            SB.Append(Environment.NewLine);
        }

        private void PrzestrajanieVpróba()
        {
            PointPairList PPL1 = new PointPairList();
            double VMIN, VMAX, StepV, VPOM, i, r, OSmin, OSmax;
            int x;
            SB = new StringBuilder();
            SBloop = new StringBuilder();
            double.TryParse(TextBox1.Text, out Napięciemin);  //16,5
            double.TryParse(textBox2.Text, out Napięciemax);
            double.TryParse(textBox3.Text, out Krokprad);
            int.TryParse(textBox4.Text, out Kroktprad); // Sprawdzic czy ma to sens wgl
            int stoper = Kroktprad;
            VMIN = Convert.ToDouble(Napięciemin);
            VMAX = Convert.ToDouble(Napięciemax);
            StepV = Convert.ToDouble(Krokprad);
            r = (VMAX - VMIN) / StepV;
            StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName);
            SB.Append("Czas (ms)" + "    " + "Prąd (mA)");
            SBloop.Append("Czas (ms)" + "    " + "Prąd (mA)");
            Intro();
            VPOM = VMIN;
            stopWatch.Start();
            for (i = 0; i <= r; i++)
            {
                if (TriggerY.Checked)
                {
                    if (EWHprzestroj.WaitOne())
                    {

                    }
                }
                while (pause == true)
                {
                    Thread.Sleep(100);
                }
                VPOM = VMIN + i * StepV;
                x = scalingParameters.SkalNaPrad(VPOM);
                AW.ustawPrad(x);         //Trzeba sprawdzic czy przyjmie miliwolty
                Thread.Sleep(stoper);
                while (x != AW.odczytPrad())
                {
                    Thread.Sleep(10);
                }
                stopWatch.Stop();         //Stoper zatrzymuje sie bez wlaczenia
                Stoper = stopWatch.ElapsedMilliseconds;
                SB.Append(Stoper + "    " + VPOM);
                SBloop.Append(Stoper + "    " + VPOM);
                Wykonajpomiar();
                StreamLoop.Write(SBloop);
                SBloop.Clear();
                SBloop.Append("" + Environment.NewLine);
                stopWatch.Start();
                EWHustawiono.Set();
            }
            stopWatch.Stop();
            stopWatch.Reset();
            StreamLoop.Close();
            MessageBox.Show("Przestrajanie zakończone");
        }

        private void PrzestrajanieTpróba()
        {
            PointPairList PPL2 = new PointPairList();
            SB = new StringBuilder();
            SBloop = new StringBuilder();
            double TMIN, TMAX, StepT, TPOM, i, r, IN = 60000;
            int x;
            double.TryParse(textBox5.Text, out Tempmin);
            double.TryParse(textBox6.Text, out Tempmax);
            double.TryParse(textBox7.Text, out Kroktemp);
            int.TryParse(textBox8.Text, out Krokttemp);
            TMIN = Convert.ToDouble(Tempmin);
            TMAX = Convert.ToDouble(Tempmax);
            StepT = Convert.ToDouble(Kroktemp);
            int stoper = Krokttemp;
            SB.Append("Czas (ms)" + "    " + "Temperatura (°C)");
            SBloop.Append("Czas (ms)" + "    " + "Temperatura (°C)");
            Intro();
            r = (TMAX - TMIN) / StepT;
            StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName);
            stopWatch.Start();

            for (i = 0; i <= r; i++)
            {
                if (TriggerY.Checked)
                {
                    if (EWHprzestroj.WaitOne())
                    {

                    }
                }
                while (pause == true)
                {
                    Thread.Sleep(100);
                }
                TPOM = TMIN + i * StepT;
                x = scalingParameters.SkalNaTemp(TPOM);
                AW.ustawTemp(x);
                Thread.Sleep(stoper);
                while (x != IN)
                {
                    IN = AW.odczytTemp();
                    Thread.Sleep(10);
                }
                stopWatch.Stop();
                Stoper = stopWatch.ElapsedMilliseconds;
                stopWatch.Start();
                SB.Append(Stoper + "    " + TPOM);
                SBloop.Append(Stoper + "    " + TPOM);
                Wykonajpomiar();
                StreamLoop.Write(SBloop);
                SBloop.Clear();
                SBloop.Append("" + Environment.NewLine);
                EWHustawiono.Set();
            }
            stopWatch.Stop();
            stopWatch.Reset();
            StreamLoop.Close();
            MessageBox.Show("Przestrajanie zakończone");
        }

        private void PrzestrajanieVTpróba()
        {
            EventWaitHandle EWHfilesave = new EventWaitHandle(false, EventResetMode.AutoReset, "ZAPISUJE DO PLIKU");
            PointPairList PPL1 = new PointPairList();
            PointPairList PPL2 = new PointPairList();
            double TMIN, TMAX, StepT, TPOM, i, j, p, r, IN = 60000;
            double VMIN, VMAX, StepV, VPOM, OSmin, OSmax, POM;
            int x, y, repeatCT = 0, repeatValue = 0;
            int.TryParse(RepeatTB.Text, out repeatValue);
            SB = new StringBuilder();
            SBloop = new StringBuilder();
            int stoper = Kroktprad;
            double.TryParse(textBox5.Text, out Tempmin);
            double.TryParse(textBox6.Text, out Tempmax);
            double.TryParse(textBox7.Text, out Kroktemp);
            int.TryParse(textBox4.Text, out Kroktprad);
            double.TryParse(TextBox1.Text, out Napięciemin);
            double.TryParse(textBox2.Text, out Napięciemax);
            double.TryParse(textBox3.Text, out Krokprad);
            int.TryParse(textBox8.Text, out Krokttemp);
            using (StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName, true))
            {
                StreamLoop.Write("");
            }
            TMIN = Convert.ToDouble(Tempmin);
            TMAX = Convert.ToDouble(Tempmax);
            StepT = Convert.ToDouble(Kroktemp);
            VMIN = Convert.ToDouble(Napięciemin);
            VMAX = Convert.ToDouble(Napięciemax);
            StepV = Convert.ToDouble(Krokprad);
            OSmin = VMIN;
            OSmax = VMAX;
            r = (TMAX - TMIN) / StepT;
            p = (VMAX - VMIN) / StepV;
            int stoperV = Kroktprad, stoperT = Krokttemp;
            TPOM = TMIN;
            VPOM = VMIN;
            SB.Append("Czas (ms) " + " Temperatura " + " Prąd (mA)");
            Intro();
            for (i = 0; i <= r; i++)
            {
                while (pause == true)
                {
                    Thread.Sleep(100);
                }
                TPOM = TMIN + i * StepT;
                x = scalingParameters.SkalNaTemp(TPOM);
                if (TriggerY.Checked)
                {
                    Thread.Sleep(150); // 12:14 23.09 - Warunek w kwesii bezpieczeństwa ze nie dojdzie do przestrojenia temp. w trakcie pomiaru
                }
                AW.ustawTemp(x);         //trzeba sprawdzic stopnie
                Thread.Sleep(stoperT);
                while (x != IN)
                {
                    IN = AW.odczytTemp();
                    Thread.Sleep(10);
                }
                if(stopWatch.IsRunning)
                    Stoper = stopWatch.ElapsedMilliseconds;
                for (j = 0; j <= p || !stopthemeasurements; j++)
                {
                    if (TriggerY.Checked)
                    {
                        EWHprzestroj.WaitOne();
                    }
                    if(!stopWatch.IsRunning)
                        stopWatch.Start();
                    VPOM = VMIN + j * StepV;
                    while (pause == true)
                    {
                        Thread.Sleep(100);
                    }
                    y = scalingParameters.SkalNaPrad(VPOM);
                    AW.ustawPrad(y);         //Trzeba sprawdzic czy przyjmie miliwolty
                    Thread.Sleep(stoperV);
                    while (y != AW.odczytPrad())
                    {
                        Thread.Sleep(10);
                    }
                    Stoper = stopWatch.ElapsedMilliseconds;
                    SB.Append(Stoper + "    " + TPOM + "    " + VPOM);
                    SBloop.Append(Stoper + ":" + TPOM + ":" + VPOM +":");
                    Wykonajpomiar();
                    using (StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName,true))
                    {
                        StreamLoop.Write("DFB " + SBloop + Environment.NewLine);
                    }
                    if (TriggerY.Checked)
                    {
                        EWHustawiono.Set();
                    }
                    SBloop.Clear();
                    if (j == p && repeatCT < repeatValue)
                    {
                        j = 0;
                        repeatCT++;
                    }
                }
            }
            stopWatch.Stop();
            stopWatch.Reset();
            StopTheMeasurements = false;
            MessageBox.Show("Przestrajanie zakończone");
        }


        //########################################################################################
        //########################################################################################
        //########################################################################################

        //private void PrzestrajanieVTpróba() WERSJA ZAPASOWA KODU (PRZY CZYM NIE PAMIETAM CZY DZIALA CZY NIE :()
        //{
        //    PointPairList PPL1 = new PointPairList();
        //    PointPairList PPL2 = new PointPairList();
        //    double TMIN, TMAX, StepT, TPOM, i, j, p, r, IN = 60000;
        //    double VMIN, VMAX, StepV, VPOM, OSmin, OSmax, POM;
        //    int x, y;
        //    SB = new StringBuilder();
        //    SBloop = new StringBuilder();
        //    int stoper = Kroktprad;
        //    double.TryParse(textBox5.Text, out Tempmin);
        //    double.TryParse(textBox6.Text, out Tempmax);
        //    double.TryParse(textBox7.Text, out Kroktemp);
        //    int.TryParse(textBox4.Text, out Kroktprad);
        //    double.TryParse(TextBox1.Text, out Napięciemin);
        //    double.TryParse(textBox2.Text, out Napięciemax);
        //    double.TryParse(textBox3.Text, out Krokprad);
        //    int.TryParse(textBox8.Text, out Krokttemp);
        //    TMIN = Convert.ToDouble(Tempmin);
        //    TMAX = Convert.ToDouble(Tempmax);
        //    StepT = Convert.ToDouble(Kroktemp);
        //    VMIN = Convert.ToDouble(Napięciemin);
        //    VMAX = Convert.ToDouble(Napięciemax);
        //    StepV = Convert.ToDouble(Krokprad);
        //    OSmin = VMIN;
        //    OSmax = VMAX;
        //    r = (TMAX - TMIN) / StepT;
        //    p = (VMAX - VMIN) / StepV;
        //    StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName);
        //    int stoperV = Kroktprad, stoperT = Krokttemp;
        //    TPOM = TMIN;
        //    VPOM = VMIN;
        //    stopWatch.Start();
        //    SB.Append("Czas (ms) " + " Temperatura " + " Prąd (mA)");
        //    Intro();
        //    for (i = 0; i <= r; i++)
        //    {
        //        while (pause == true)
        //        {
        //            Thread.Sleep(100);
        //        }
        //        TPOM = TMIN + i * StepT;
        //        x = scalingParameters.SkalNaTemp(TPOM);
        //        AW.ustawTemp(x);         //trzeba sprawdzic stopnie
        //        Thread.Sleep(stoperT);
        //        while (x != IN)
        //        {
        //            IN = AW.odczytTemp();
        //            Thread.Sleep(10);
        //        }
        //        stopWatch.Stop();
        //        Stoper = stopWatch.ElapsedMilliseconds;
        //        stopWatch.Start();
        //        for (j = 0; j <= p; j++)
        //        {
        //            if (TriggerY.Checked)
        //            {
        //                EWHprzestroj.WaitOne();
        //            }

        //            VPOM = VMIN + j * StepV;
        //            while (pause == true)
        //            {
        //                Thread.Sleep(100);
        //            }
        //            y = scalingParameters.SkalNaPrad(VPOM);
        //            AW.ustawPrad(y);         //Trzeba sprawdzic czy przyjmie miliwolty
        //            Thread.Sleep(stoperV);
        //            if (TriggerY.Checked)
        //            {
        //                EWHustawiono.Set();
        //            }
        //            while (y != AW.odczytPrad())
        //            {
        //                Thread.Sleep(10);
        //            }
        //            stopWatch.Stop();         //Stoper zatrzymuje sie bez wlaczenia
        //            Stoper = stopWatch.ElapsedMilliseconds;
        //            SB.Append(Stoper + "    " + TPOM + "    " + VPOM);
        //            SBloop.Append(Stoper + "    " + TPOM + "    " + VPOM);
        //            Wykonajpomiar();
        //            StreamLoop.Write(SBloop);
        //            stopWatch.Start();
        //            SBloop.Clear();
        //            SBloop.Append("" + Environment.NewLine);
        //        }
        //    }
        //    stopWatch.Stop();
        //    stopWatch.Reset();
        //    StreamLoop.Close();
        //    MessageBox.Show("Przestrajanie zakończone");
        //}


        //########################################################################################
        //########################################################################################
        //########################################################################################
        //########################################################################################



        public void AdvancedLoopk()
        {
            //Ustalanie parametrów początkowych
            double step;
            int Tstep, Vstep;
            double.TryParse(TBstepcm.Text, out step);
            int.TryParse(CzasKTMS.Text, out Tstep);
            int.TryParse(CzasKVMS.Text, out Vstep);
            if (tabControl1.SelectedTab == Cm)
            {
                double.TryParse(TBstepcm.Text, out step);
                int.TryParse(CzasKTMS.Text, out Tstep);
                int.TryParse(CzasKVMS.Text, out Vstep);
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                double.TryParse(TBstepTHz.Text, out step);
                int.TryParse(CzasvTMS.Text, out Tstep);
                int.TryParse(CzasvVMS.Text, out Vstep);
            }
            if (tabControl1.SelectedTab == tabPage5)
            {
                double.TryParse(TBstepnm.Text, out step);
                int.TryParse(TBstepnmTMS.Text, out Tstep);
                int.TryParse(TBstepnmVMS.Text, out Vstep);
            }
            double MinT = TempMinAdvanced, MaxT = TempMaxAdvanced, StepS = step;
            int StepTV = Vstep, StepTT = Tstep;
            MessageBox.Show("Działam" + MinT + MaxT + StepS + StepTV + StepTT);
            double TPOM;
            SB = new StringBuilder();
            SBloop = new StringBuilder();
            StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName);
            TPOM = MinT; //TempMinAdvanced, TempMaxAdvanced, step, Vstep, Tstep
            double startT = MinT;
            double pomT = MinT;
            double endT = MaxT;
            MessageBox.Show("Ustalam parametry początkowe");
            if (pomT <= 20)
                AW.ustawPrad(scalingParameters.SkalNaPrad(25));
            if (pomT > 20 && pomT < 32)
                AW.ustawPrad(scalingParameters.SkalNaPrad(30));
            if (pomT >= 32)
                AW.ustawPrad(scalingParameters.SkalNaPrad(35));


            int StepV = 0;
            double helpcurrent = 0;

            double Stepspertemp = StepS / ((endT - startT) * 10); // Ile przejść między temperaturami
            double Stepcountercurrent = 0, Stephelper = 0, Stepcountertemperature;
            Stepcountertemperature = 0;
            double pom;
            SB.Append("Temperatura " + "Prąd (mA)");
            SBloop.Append("Temperatura " + "Prąd (mA)");
            Intro();
            double border = Math.Abs(MaxT - MinT) * 10;
            for (Stepcountertemperature = 0; Stepcountertemperature <= border; Stepcountertemperature++)
            {
                if (pomT <= 20)
                {
                    AW.ustawPrad(scalingParameters.SkalNaPrad(25));
                    helpcurrent = 25;
                }
                if (pomT > 20 && pomT < 32)
                {
                    AW.ustawPrad(scalingParameters.SkalNaPrad(30));
                    helpcurrent = 30;
                }
                if (pomT >= 32)
                {
                    AW.ustawPrad(scalingParameters.SkalNaPrad(35));
                    helpcurrent = 35;
                }
                AW.ustawTemp(scalingParameters.SkalNaTemp(pomT));
                Thread.Sleep(StepTT);
                Stephelper = Advanced.CurrentAmmountPerStep(pomT) / (StepS / ((endT - startT) * 10));
                for (Stepcountercurrent = 0; Stepcountercurrent <= StepS / ((endT - startT) * 10); Stepcountercurrent++)
                {

                    pom = helpcurrent + Stepcountercurrent * Stephelper;
                    MessageBox.Show("" + pomT + pom);
                    AW.ustawPrad(scalingParameters.SkalNaPrad(pom));
                    SB.Append(pomT + "    " + pom);
                    SBloop.Append(pomT + "    " + pom);
                    Thread.Sleep(StepTV);
                    Wykonajpomiar();
                    StreamLoop.Write(SBloop);
                    SBloop.Clear();
                    SBloop.Append("" + Environment.NewLine);
                }
                helpcurrent = 0;
                pomT = pomT + 0.1;
            }
            StreamLoop.Close();
            MessageBox.Show("Przestrajanie zakończone");
        }

        public void AdvancedLoopnm(double MinT, double MaxT, double StepS, int StepTV, int StepTT)
        {
            //Ustalanie parametrów początkowych
            MessageBox.Show("Działam" + MinT + MaxT + StepS + StepTV + StepTT);
            double TPOM;
            SB = new StringBuilder();
            SBloop = new StringBuilder();
            TPOM = MinT;
            double startT = MinT;
            double pomT = MinT;
            double endT = MaxT;
            StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName);
            // if (pomT <= 20)
            //    AW.ustawPrad(scalingParameters.SkalNaPrad(25));
            // if (pomT > 20 && pomT < 32)
            //    AW.ustawPrad(scalingParameters.SkalNaPrad(30));
            // if (pomT >= 32)
            //   AW.ustawPrad(scalingParameters.SkalNaPrad(35));


            int StepV = 0;
            double helpcurrent = 0;

            double Stepspertemp = StepS / ((endT - startT) * 10); // Ile przejść między temperaturami
            double Stepcountercurrent = 0, Stephelper = 0, Stepcountertemperature;
            Stepcountertemperature = 0;
            double pom;
            SB.Append("Temperatura " + "Prąd (mA)");
            SBloop.Append("Temperatura " + "Prąd (mA)");
            Intro();
            double border = Math.Abs(MaxT - MinT) * 10;
            for (Stepcountertemperature = 0; Stepcountertemperature <= border; Stepcountertemperature++)
            {
                if (pomT <= 20)
                {
                    AW.ustawPrad(scalingParameters.SkalNaPrad(25));
                    helpcurrent = 25;
                }
                if (pomT > 20 && pomT < 32)
                {
                    AW.ustawPrad(scalingParameters.SkalNaPrad(30));
                    helpcurrent = 30;
                }
                if (pomT >= 32)
                {
                    AW.ustawPrad(scalingParameters.SkalNaPrad(35));
                    helpcurrent = 35;
                }
                AW.ustawTemp(scalingParameters.SkalNaTemp(pomT));
                Thread.Sleep(StepTT);
                Stephelper = Advanced.CurrentAmmountPerStep(pomT) / (StepS / ((endT - startT) * 10));
                for (Stepcountercurrent = 0; Stepcountercurrent <= StepS / ((endT - startT) * 10); Stepcountercurrent++)
                {
                    pom = helpcurrent + Stepcountercurrent * Stephelper;
                    AW.ustawPrad(scalingParameters.SkalNaPrad(pom));
                    SB.Append(pomT + "    " + pom);
                    SBloop.Append(pomT + "    " + pom);
                    Thread.Sleep(StepTV);
                    Wykonajpomiar();
                    StreamLoop.Write(SBloop);
                    SBloop.Clear();
                    SBloop.Append("" + Environment.NewLine);
                }
                helpcurrent = 0;
                pomT = pomT + 0.1;
            }
            StreamLoop.Close();
            MessageBox.Show("Przestrajanie zakończone");
        }

        public void AdvancedLoopTHz(double MinT, double MaxT, double StepS, int StepTV, int StepTT)
        {
            //Ustalanie parametrów początkowych
            MessageBox.Show("Działam" + MinT + MaxT + StepS + StepTV + StepTT);
            double TPOM;
            SB = new StringBuilder();
            SBloop = new StringBuilder();
            TPOM = MinT;
            double startT = MinT;
            double pomT = MinT;
            double endT = MaxT;

            // if (pomT <= 20)
            //    AW.ustawPrad(scalingParameters.SkalNaPrad(25));
            // if (pomT > 20 && pomT < 32)
            //    AW.ustawPrad(scalingParameters.SkalNaPrad(30));
            // if (pomT >= 32)
            //   AW.ustawPrad(scalingParameters.SkalNaPrad(35));


            int StepV = 0;
            double helpcurrent = 0;

            double Stepspertemp = StepS / ((endT - startT) * 10); // Ile przejść między temperaturami
            double Stepcountercurrent = 0, Stephelper = 0, Stepcountertemperature;
            Stepcountertemperature = 0;
            double pom;
            StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName);
            SB.Append("Temperatura " + "Prąd (mA)");
            SBloop.Append("Temperatura " + "Prąd (mA)");
            Intro();
            double border = Math.Abs(MaxT - MinT) * 10;
            for (Stepcountertemperature = 0; Stepcountertemperature <= border; Stepcountertemperature++)
            {
                if (pomT <= 20)
                {
                    AW.ustawPrad(scalingParameters.SkalNaPrad(25));
                    helpcurrent = 25;
                }
                if (pomT > 20 && pomT < 32)
                {
                    AW.ustawPrad(scalingParameters.SkalNaPrad(30));
                    helpcurrent = 30;
                }
                if (pomT >= 32)
                {
                    AW.ustawPrad(scalingParameters.SkalNaPrad(35));
                    helpcurrent = 35;
                }
                AW.ustawTemp(scalingParameters.SkalNaTemp(pomT));
                Thread.Sleep(StepTT);
                Stephelper = Advanced.CurrentAmmountPerStep(pomT) / (StepS / ((endT - startT) * 10));
                for (Stepcountercurrent = 0; Stepcountercurrent <= StepS / ((endT - startT) * 10); Stepcountercurrent++)
                {
                    pom = helpcurrent + Stepcountercurrent * Stephelper;
                    AW.ustawPrad(scalingParameters.SkalNaPrad(pom));
                    SB.Append(pomT + "    " + pom);
                    SBloop.Append(pomT + "    " + pom);
                    StreamLoop.Write(SBloop);
                    SBloop.Clear();
                    SBloop.Append("" + Environment.NewLine);
                    Thread.Sleep(StepTV);
                    Wykonajpomiar();
                }
                helpcurrent = 0;
                pomT = pomT + 0.1;
            }
            StreamLoop.Close();
            MessageBox.Show("Przestrajanie zakończone");
        }
        //########################################################################################
        //########################################################################################
        //########################################################################################
        //########################################################################################
        //########################################################################################
        //########################################################################################
        //########################################################################################


        private void Form1_Load(object sender, EventArgs e)
        {
            Testbox.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHcm;
            cmmin.Text = "Min cmˉ¹";
            cmmax.Text = "Max cmˉ¹";
            Stepcm.Text = "Liczba punktów pomiarowych";
            button19.Text = "Sprawdź długość fali w cmˉ¹";
            button16.Text = "Przestrajanie długości fali w cmˉ¹";
            button19.Text = "Sprawdz długość fali w cmˉ¹";
            Checkk.Text = "Długość fali (cmˉ¹)";
            CreateGraph1(zedGraphControl1);
            CreateGraph2(zedGraphControl2);
            CreateGraph3(zedGraphControl3);
        }

        private void CreateGraph1(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Time (s)";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Current (mA)";
            zedGraphControl1.GraphPane.Title.Text = "Current analysis";
        }
        private void CreateGraph2(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            zedGraphControl2.GraphPane.XAxis.Title.Text = "Time (s)";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "Temperature (°C)";
            zedGraphControl2.GraphPane.Title.Text = "Temperature analysis";
        }
        private void CreateGraph3(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Time (s)";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Wavenumber (cmˉ¹)";
            zedGraphControl3.GraphPane.Title.Text = "Beam analysis";
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            //Wykres po lewej
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Min.napiecie


            try
            {
                double Napięciemin = double.Parse(TextBox1.Text);
                Laser.Properties.Settings.Default.MinV = Napięciemin;
                Laser.Properties.Settings.Default.Save();
            }
            catch
            {
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Max.napiecie

            try
            {
                double Napięciemax = double.Parse(textBox2.Text);
                Laser.Properties.Settings.Default.MaxV = Napięciemax;
                Laser.Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Min.temp

            try
            {
                double Tempmin = double.Parse(textBox5.Text);
                Laser.Properties.Settings.Default.MinT = Tempmin;
                Laser.Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Max.temp
            try
            {
                double Tempmax = double.Parse(textBox6.Text);
                Laser.Properties.Settings.Default.MaxT = Tempmax;
                Laser.Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Krok prądowy

            try
            {
                double Krokprad = double.Parse(textBox3.Text);
                Laser.Properties.Settings.Default.StepV = Krokprad;
                Laser.Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //Krok temperaturowy
            try
            {
                double Kroktemp = double.Parse(textBox7.Text);
                Laser.Properties.Settings.Default.StepT = Kroktemp;
                Laser.Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Krok czasowy pradowy
            try
            {
                int Kroktprad = int.Parse(textBox4.Text);
                Laser.Properties.Settings.Default.TStepV = Kroktprad;
                Laser.Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //Krok czasowy temperaturowy
            try
            {
                int Krokttemp = int.Parse(textBox8.Text);
                Laser.Properties.Settings.Default.TStepT = Krokttemp;
                Laser.Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Vscan.IsAlive == false)
            {
                button1.BackColor = Color.MediumVioletRed;
                Eventbool = false;
                SaveLoop.ShowDialog();
                double VMIN, VMAX;
                double.TryParse(TextBox1.Text, out VMIN);  //16,5
                double.TryParse(textBox2.Text, out VMAX);
                if (help.CheckPrad(VMIN, VMAX) == false)
                {
                    MessageBox.Show("Przekroczono parametry pomiarowe, proces przestrajania nie może się rozpocząć.");
                    return;
                }
                Vscan = new Thread(VSCAN);
                Vscan.Start();
                Grafrys.PerformClick();
            }
            else
            {
                Grafrys.PerformClick();
                button1.BackColor = Color.White;
                Vscan.Abort();
                MessageBox.Show("Przerwano proces przestrajania");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Przestrajanie temperaturowe test
            if (Tscan.IsAlive == false)
            {
                Eventbool = false;
                button2.BackColor = Color.MediumVioletRed;
                SaveLoop.ShowDialog();
                double TMIN, TMAX;
                double.TryParse(textBox5.Text, out TMIN);  //16,5
                double.TryParse(textBox6.Text, out TMAX);
                if (help.CheckTemp(TMIN, TMAX) == false)
                {
                    MessageBox.Show("Przekroczono parametry pomiarowe, proces przestrajania nie może się rozpocząć.");
                    return;
                }
                Tscan = new Thread(TSCAN);
                Grafrys.PerformClick();
                Tscan.Start();
            }
            else
            {
                Grafrys.PerformClick();
                button2.BackColor = Color.White;
                Tscan.Abort();
                MessageBox.Show("Przerwano proces przestrajania");
            }
        }

        private void zedGraphControl2_Load(object sender, EventArgs e)
        {
            //Wykres po prawej
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Zatrzymać pomiar?", "",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                EWHbreak.Set();
                if (Tlo.IsAlive) Tlo.Abort();
                if (wmtester.IsAlive) wmtester.Abort();
                if (VTscan.IsAlive) VTscan.Abort();
                if (Vscan.IsAlive) Vscan.Abort();
                if (Tscan.IsAlive) Tscan.Abort();
                EWHprzestroj.Set();
                stopthemeasurements = true;
            }
        }

        private void zedGraphControl3_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //Aktualny prąd
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //Aktualna temperatura
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            //Ustal napięcie
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            //Ustal temperature
        }

        private void button6_Click(object sender, EventArgs e) // Sprawdzic jak napięcia działają na ustaloną temperature
        {
            //ustalanie temperatury
            double CurrentT;
            double.TryParse(textBox12.Text, out CurrentT);
            int x = scalingParameters.SkalNaTemp(CurrentT);
            if (help.CheckTemp(CurrentT, CurrentT) == false)
            {
                MessageBox.Show("Przekroczono parametry pomiarowe");
                return;
            }
            AW.ustawTemp(x);
            while (x != AW.odczytTemp())
            {
                Thread.Sleep(100);
            }
            MessageBox.Show("Temperatura została ustalona");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Przestrajanie VT próba
            double minV, maxV, minT, maxT;
            double.TryParse(TextBox1.Text, out minV);
            double.TryParse(textBox2.Text, out maxV);
            double.TryParse(textBox5.Text, out minT);
            double.TryParse(textBox6.Text, out maxT);
            if (help.AllConditions(minV, maxV, minT, maxT))
            {
                if (VTscan.IsAlive == false)
                {
                    button5.BackColor = Color.MediumVioletRed;
                    SaveLoop.ShowDialog();
                    Eventbool = false;
                    VTscan = new Thread(VTSCAN);
                    VTscan.Start();
                    Grafrys.PerformClick();
                }
                else
                {
                    Grafrys.PerformClick();
                    button5.BackColor = Color.White;
                    VTscan.Abort();
                    MessageBox.Show("Przerwano proces przestrajania");
                }
            }
            else
                MessageBox.Show("Przekroczono parametry pomiarowe");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // INICJALIZACJA
            AW.inicjalizuj();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Ustalanie napięcia
            double CurrentV;
            double.TryParse(textBox11.Text, out CurrentV);
            if (help.CheckPrad(CurrentV, CurrentV) == false)
            {
                MessageBox.Show("Przekroczono parametry pomiarowe");
                return;
            }
            int x = scalingParameters.SkalNaPrad(CurrentV);
            AW.ustawPrad(x);
            while (x != AW.odczytPrad())
            {
                Thread.Sleep(100);
            }
            MessageBox.Show("Prąd został ustalony");

        }


        private void button4_Click(object sender, EventArgs e)
        {
            // Odczyt nap
            MessageBox.Show("Aktualny prąd wynosi: " + scalingParameters.Pradline(AW.odczytPrad()) + "mA");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Odczyt temp
            MessageBox.Show("Aktualna temperatura wynosi: " + scalingParameters.Templine(AW.odczytTemp()) + "°C");
        }

        private void PrzestrajanieV_Click(object sender, EventArgs e)
        {
            Eventbool = true;
            if (!Vscan.IsAlive && !Tscan.IsAlive && !VTscan.IsAlive)
            {
                Vscan = new Thread(VSCAN);
                Vscan.Start();
            }
            else
            {
                MessageBox.Show("Trwa przestrajanie, proszę czekać");
            }
            //PrzestrajanieNap();
        }

        private void PrzestrajanieT_Click(object sender, EventArgs e)
        {
            Eventbool = true;
            if (!Vscan.IsAlive && !Tscan.IsAlive && !VTscan.IsAlive)
            {
                Tscan = new Thread(TSCAN);
                Tscan.Start();
            }
            else
            {
                MessageBox.Show("Trwa przestrajanie, proszę czekać");
            }
            //  PrzestrajanieTemp();
        }

        private void PrzestrajanieTV_Click(object sender, EventArgs e)
        {
            Eventbool = true;
            if (!Vscan.IsAlive && !Tscan.IsAlive && !VTscan.IsAlive)
            {
                VTscan = new Thread(VTSCAN);
                VTscan.Start();
            }
            else
            {
                MessageBox.Show("Trwa przestrajanie, proszę czekać");
            }
            // PrzestrajanieNapTemp();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBmineV_TextChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (AdvancedScanK.IsAlive == false)
            {
                double min, max, step;
                int Tstep, Vstep;
                double.TryParse(TBmincm.Text, out min);
                double.TryParse(TBmaxcm.Text, out max);
                double.TryParse(TBstepcm.Text, out step);
                int.TryParse(CzasKTMS.Text, out Tstep);
                int.TryParse(CzasKVMS.Text, out Vstep);
                Laser.Properties.Settings.Default.MinK = min;
                Laser.Properties.Settings.Default.MaxK = max;
                Laser.Properties.Settings.Default.StepK = step;
                Laser.Properties.Settings.Default.KStepT = Tstep;
                Laser.Properties.Settings.Default.KStepV = Vstep;
                Laser.Properties.Settings.Default.ScalingParameter = 1;
                Laser.Properties.Settings.Default.TriggerParameter = false;
                Laser.Properties.Settings.Default.Save();
                AdvancedScanK.Start();
                Grafrys.PerformClick();
            }
            else
            {
                AdvancedScanK.Abort();
                MessageBox.Show("Przerwano przestrajanie");
                Grafrys.PerformClick();
            }

        }

        private void TBminTHz_TextChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            double min, max, step;
            int Tstep, Vstep;
            double.TryParse(TBminTHz.Text, out min);
            double.TryParse(TBmaxTHz.Text, out max);
            double.TryParse(TBstepTHz.Text, out step);
            int.TryParse(CzasvTMS.Text, out Tstep);
            int.TryParse(CzasvVMS.Text, out Vstep);
            Laser.Properties.Settings.Default.MinQ = min;
            Laser.Properties.Settings.Default.MaxQ = max;
            Laser.Properties.Settings.Default.StepQ = step;
            Laser.Properties.Settings.Default.QStepT = Tstep;
            Laser.Properties.Settings.Default.QStepV = Vstep;
            Laser.Properties.Settings.Default.ScalingParameter = 4;
            Laser.Properties.Settings.Default.TriggerParameter = false;
            Laser.Properties.Settings.Default.Save();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            double min, max, step;
            int Tstep, Vstep;
            double.TryParse(TBminnm.Text, out min);
            double.TryParse(TBmaxnm.Text, out max);
            double.TryParse(TBstepnm.Text, out step);
            int.TryParse(TBstepnmTMS.Text, out Tstep);
            int.TryParse(TBstepnmVMS.Text, out Vstep);
            Laser.Properties.Settings.Default.MinW = min;
            Laser.Properties.Settings.Default.MaxW = max;
            Laser.Properties.Settings.Default.StepW = step;
            Laser.Properties.Settings.Default.WStepT = Tstep;
            Laser.Properties.Settings.Default.WStepV = Vstep;
            Laser.Properties.Settings.Default.ScalingParameter = 3;
            Laser.Properties.Settings.Default.TriggerParameter = false;
            Laser.Properties.Settings.Default.Save();
        }

        private void CzasvTMS_TextChanged(object sender, EventArgs e)
        {

        }

        private void StabilnoscV_Click(object sender, EventArgs e) // sprwadzic bledy
        {
            double Amin, Amax, StepT;
            SB = new StringBuilder();
            int i;
            double.TryParse(StabAMin.Text, out Amin);
            double.TryParse(StabAMax.Text, out Amax);
            int y = scalingParameters.SkalNaPrad(Amin);
            if (textBox11 != StabAMin)
            {

                AW.ustawPrad(y);
                Thread.Sleep(500);
            }
            if (help.CheckPrad(Amin, Amax) == false)
            {
                MessageBox.Show("Przekroczono parametry pomiarowe");
                return;
            }
            SB.Append("Numer pomiaru" + "Czas pomiaru");
            Intro();
            SB.Append("0" + " " + "0");
            Wykonajpomiar();
            int x = scalingParameters.SkalNaPrad(Amax);
            double.TryParse(StabTS.Text, out StepT);
            StepT = StepT * 100;
            AW.ustawPrad(x);
            for (i = 1; i < StepT; i++)
            {
                SB.Append(i + " " + i * 10 + " ");
                Wykonajpomiar();
                Thread.Sleep(10);
            }
            AW.ustawPrad(y);
            MessageBox.Show("Powrócono do warunków początkowych");
        }

        private void StabilnoscT_Click(object sender, EventArgs e)
        {
            //Ustalanie napięcia
            double Tmin, Tmax, StepT;
            SB = new StringBuilder();
            int i;
            double.TryParse(StabTMin.Text, out Tmin);
            double.TryParse(StabTMax.Text, out Tmax);
            int y = scalingParameters.SkalNaTemp(Tmin);
            if (textBox12 != StabTMin)
            {

                AW.ustawTemp(y);
                Thread.Sleep(10000);
            }
            if (help.CheckTemp(Tmin, Tmax) == false)
            {
                MessageBox.Show("Przekroczono parametry pomiarowe");
                return;
            }
            SB.Append("Numer pomiaru" + "Czas pomiaru");
            Intro();
            SB.Append("0" + "  " + "0");
            Wykonajpomiar();
            int x = scalingParameters.SkalNaTemp(Tmax);
            AW.ustawTemp(x);
            double.TryParse(StabTS.Text, out StepT);
            StepT = StepT * 100;

            for (i = 1; i < StepT; i++)
            {
                SB.Append(i + " " + i * 10 + "     ");
                Wykonajpomiar();
                Thread.Sleep(10);
            }
            AW.ustawTemp(y);
            MessageBox.Show("Powrócono do warunków początkowych");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + Advanced.lambdatok(Wavecontrol.ReadWavelenght()) + " cmˉ¹");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + Advanced.lambdatoE(Wavecontrol.ReadWavelenght()) + " eV");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + Advanced.lambdatov(Wavecontrol.ReadWavelenght()) + " THz");
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void StabilnoscVT_Click(object sender, EventArgs e)
        {
            double Amin, Amax, Tmin, Tmax, StepT;
            SB = new StringBuilder();
            int i;
            double.TryParse(StabAMin.Text, out Amin);
            double.TryParse(StabAMax.Text, out Amax);
            double.TryParse(StabTMin.Text, out Tmin);
            double.TryParse(StabTMax.Text, out Tmax);
            int y = scalingParameters.SkalNaPrad(Amin);
            int z = scalingParameters.SkalNaTemp(Tmin);
            if (textBox11 != StabAMin)
            {
                AW.ustawPrad(y);
                Thread.Sleep(500);
            }
            if (textBox12 != StabTMin)
            {
                AW.ustawTemp(z);
                Thread.Sleep(10000);
            }
            if (help.CheckPrad(Amin, Amax) == false || help.CheckTemp(Tmin, Tmax) == false)
            {
                MessageBox.Show("Przekroczono parametry pomiarowe");
                return;
            }
            SB.Append("Numer pomiaru" + "Czas pomiaru");
            Intro();
            SB.Append("0" + " " + "0");
            Wykonajpomiar();
            int x = scalingParameters.SkalNaPrad(Amax);
            int a = scalingParameters.SkalNaTemp(Tmax);
            double.TryParse(StabTS.Text, out StepT);
            StepT = StepT * 100;
            AW.ustawPrad(x);
            AW.ustawTemp(a);
            for (i = 1; i < StepT; i++)
            {
                SB.Append(i + " " + i * 10 + " ");
                Wykonajpomiar();
                Thread.Sleep(10);
            }
            AW.ustawPrad(y);
            AW.ustawTemp(z);
            MessageBox.Show("Powrócono do warunków początkowych");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //Co ma się dziać przy wyłączeniu programu
        {
            AW.ustawPrad(0);
            AW.ustawTemp(0);

            Environment.Exit(Environment.ExitCode);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + Wavecontrol.ReadWavelenght());
            double POM, POM1, POM2;
            int i;
            for (i = 0; i < 100; i++)
            {
                zedGraphControl3.GraphPane.CurveList.Clear();
                POM = 12835 - i * 0.01;
                PPLk.Add(kindex, POM);
                zedGraphControl3.GraphPane.XAxis.Title.Text = "Time (s)";
                zedGraphControl3.GraphPane.YAxis.Title.Text = "Wavenumber (cmˉ¹)";
                zedGraphControl3.GraphPane.AddCurve("Wavenumber", PPLk, Color.Red, SymbolType.None);
                zedGraphControl3.AxisChange();
                zedGraphControl3.Invalidate();
                kindex = kindex + 1;

                POM1 = 40 + i * 0.1;
                zedGraphControl1.GraphPane.CurveList.Clear();
                PPL1.Add(Pradindex, POM1);
                zedGraphControl1.GraphPane.XAxis.Title.Text = "Time (s)";
                zedGraphControl1.GraphPane.YAxis.Title.Text = "Current (mA)";
                zedGraphControl1.GraphPane.AddCurve("Current", PPL1, Color.Green, SymbolType.None);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                Pradindex = Pradindex + 1;


                POM2 = 20 + i * 0.05;
                zedGraphControl2.GraphPane.CurveList.Clear();
                PPL2.Add(Tempindex, POM2);
                zedGraphControl2.GraphPane.XAxis.Title.Text = "Time (s)";
                zedGraphControl2.GraphPane.YAxis.Title.Text = "Temperature (°C)";
                zedGraphControl2.GraphPane.AddCurve("Temperature", PPL2, Color.Blue, SymbolType.None);
                zedGraphControl2.AxisChange();
                zedGraphControl2.Invalidate();
                Tempindex = Tempindex + 1;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {

        }
        bool Oscylbutton = false;
        private void ButtOscyl_Click(object sender, EventArgs e)
        {
            stopWatchV.Start();
            stopWatchT.Start();
            if (Oscylbutton == false)
            {
                this.Grafrys.BackColor = Color.Green;
                Tlo = new Thread(TLO);
                Tlo.Start();
                Oscylbutton = true;
            }
            else
            {
                this.Grafrys.BackColor = Color.Red;
                if (Tlo.IsAlive) Tlo.Abort();
                Oscylbutton = false;
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.ShowDialog();
        }

        private void Oscylinit_Click(object sender, EventArgs e)
        {
            Oscyl.Show();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox1.Text = "Current control";
            groupBox2.Text = "Temperature control";
            groupBox3.Text = "Parameters establishing";
            groupBox4.Text = "Advanced tuning";
            groupBox5.Text = "Measured parameters";
            groupBox6.Text = "Control panel";
            groupBox8.Text = "Tuning";
            groupBox7.Text = "Averages";
            groupBox9.Text = "General settings";
            groupBox10.Text = "Stability of laser beam";
            groupBox11.Text = "Curr. change (mA)";
            groupBox12.Text = "Temp. change (°C)";
            groupBox13.Text = "Graph options";
            button1.Text = "Current tuning";
            button2.Text = "Temperature tuning";
            button4.Text = "Read current";
            button5.Text = "Current and temperature tuning";
            button6.Text = "Set temperature";
            button7.Text = "Set current";
            button8.Text = "Save measurements";
            button9.Text = "Connect with laser";
            button10.Text = "Read temp.";
            button12.Text = "Check wavelenght (nm)";
            button16.Text = "Wavenumber tuning (cmˉ¹)";
            button18.Text = "Wavelenght tuning (nm)";
            button19.Text = "Check wavelenght (nm)";
            button20.Text = "Check energy (eV)";
            button21.Text = "Check frequency (THz)";
            button22.Text = "Frequency tuning";
            button23.Text = "Diode settings";
            TriggerY.Text = "With trigger";
            TriggerN.Text = "Without trigger";
            Grafrys.Text = "Draw graphs";
            Oscylinit.Text = "Connect with oscilloscope";
            Checknm.Text = "Wavelenght (nm)";
            CheckeV.Text = "Energy (eV)";
            Checkk.Text = "Wavenumber (cmˉ¹)";
            CheckMHz.Text = "Frequency (THz)";
            Checkoscylo.Text = "Oscilloscope measurements";
            Radiooscylo.Text = "Oscilloscope";
            Radiofalo.Text = "Wavemeter";
            StabilnoscV.Text = "Current stability";
            StabilnoscT.Text = "Temperature stability";
            StabilnoscVT.Text = "Current and temperature stability";
            label1.Text = "Min. current (mA)";
            label2.Text = "Max. current (mA)";
            label3.Text = "Time step (ms)";
            label4.Text = "Max. temp. (°C)";
            label5.Text = "Temp. step (°C)";
            label6.Text = "Min. temp (°C)";
            label7.Text = "Curr. step (mA)";
            label8.Text = "Time step (ms)";
            label11.Text = "Set current (mA)";
            label12.Text = "Set temp. (°C)";
            cmmin.Text = "Min. (cmˉ¹)";
            cmmax.Text = "Max. (cmˉ¹)";
            Stepcm.Text = "Number of points";
            label15.Text = "Temp. stabilisation (ms)";
            label16.Text = "Current stabilisation (ms)";
            label9.Text = "From:";
            label10.Text = "To:";
            label13.Text = "From:";
            label14.Text = "To:";
            label27.Text = "Measurent time (s)";
            label31.Text = "Number of measurements";
            label32.Text = "Delay between \nmeasurements (ms)";
            label33.Text = "Average?";
            AveY.Text = "Yes";
            AveN.Text = "No";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Time (s)";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Current (mA)";
            zedGraphControl1.GraphPane.Title.Text = "Current";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "Time (s)";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "Temperature (°C)";
            zedGraphControl2.GraphPane.Title.Text = "Temperature";
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Time (s)";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Wavenumber (cmˉ¹)";
            zedGraphControl3.GraphPane.Title.Text = "Beam analysis";
            Dioda1.Text = "Diode 1";
            Dioda2.Text = "Diode 2";
            Dioda3.Text = "Diode 3";
            label22.Text = "Current stabilisation (ms)";
            label23.Text = "Temp. stabilisation (ms)";
            label24.Text = "Number of points";
            label45.Text = "Current stabilisation (ms)";
            label46.Text = "Temp. stabilisation (ms)";
            label47.Text = "Number of points";
            UsedDiode.Text = "Used diode";
            Advancedchecker.Text = "Initial checking";
            Veryadvancedchecker.Text = "Precise checking";
            label17.Text = "Tuning parameters";
            LabelMinTemp.Text = "Initial temp ... °C";
            LabelMaxTemp.Text = "Final temp ... °C";
            button13.Text = "Exit";
        }

        private void AktualizacjaWykresu_Click(object sender, EventArgs e)
        {
            if (Combooscylo.SelectedIndex == 0)
            {
                Laser.Properties.Settings.Default.Graphsettingoption = 0;
                Laser.Properties.Settings.Default.Save();
            }
            if (Combooscylo.SelectedIndex == 1)
            {
                Laser.Properties.Settings.Default.Graphsettingoption = 1;
                Laser.Properties.Settings.Default.Save();
            }
            if (Combofalo.SelectedIndex == 0)
            {
                Laser.Properties.Settings.Default.Graphsettingoption = 2;
                Laser.Properties.Settings.Default.Save();
            }
            if (Combofalo.SelectedIndex == 1)
            {
                Laser.Properties.Settings.Default.Graphsettingoption = 3;
                Laser.Properties.Settings.Default.Save();
            }
            if (Combofalo.SelectedIndex == 2)
            {
                Laser.Properties.Settings.Default.Graphsettingoption = 4;
                Laser.Properties.Settings.Default.Save();
            }
        }

        private void Advancedchecker_Click(object sender, EventArgs e)
        {
            double min, max, Tmin, Tmax;



            if (tabControl1.SelectedTab == Cm)
            {
                double.TryParse(TBmincm.Text, out min);
                double.TryParse(TBmaxcm.Text, out max);
                Tmin = Advanced.Tforkseeker(min, false);
                Tmax = Advanced.Tforkseeker(max, true);
                TempMinAdvanced = Tmin;
                TempMaxAdvanced = Tmax;
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                double.TryParse(TBminTHz.Text, out min);
                double.TryParse(TBmaxTHz.Text, out max);
                Tmin = Advanced.TforHzseeker(min, false);
                Tmax = Advanced.TforHzseeker(max, true);
                TempMinAdvanced = Tmin;
                TempMaxAdvanced = Tmax;
            }
            if (tabControl1.SelectedTab == tabPage5)
            {
                double.TryParse(TBminnm.Text, out min);
                double.TryParse(TBmaxnm.Text, out max);
                Tmin = Advanced.Tforlambdaseeker(min, false);
                Tmax = Advanced.Tforlambdaseeker(max, true);
                TempMinAdvanced = Tmin;
                TempMaxAdvanced = Tmax;
            }
            LabelMinTemp.Text = "Temp. pocz. " + TempMinAdvanced + "(°C)";
            LabelMaxTemp.Text = "Temp. końc. " + TempMaxAdvanced + "(°C)";
            MessageBox.Show("Sugerowana temperatura początkowa wynosi: " + TempMinAdvanced + "\nTemperatura końcowa wynosi: " + TempMaxAdvanced);
        }

        private void MinTempPlus_Click(object sender, EventArgs e)
        {
            TempMinAdvanced = TempMinAdvanced + 0.1;
            LabelMinTemp.Text = "Temp. pocz. " + TempMinAdvanced + "(°C)";
        }

        private void MinTempMinus_Click(object sender, EventArgs e)
        {
            TempMinAdvanced = TempMinAdvanced - 0.1;
            LabelMinTemp.Text = "Temp. pocz. " + TempMinAdvanced + "(°C)";
        }

        private void Veryadvancedchecker_Click(object sender, EventArgs e)
        {
            int minTV, maxTV;
            double minParameterk, minParameterv, minParameterlambda, maxParameterk, maxParameterv, maxParameterlambda;
            minTV = scalingParameters.SkalNaTemp(TempMinAdvanced);
            maxTV = scalingParameters.SkalNaTemp(TempMaxAdvanced);
            AW.ustawTemp(minTV);         //Trzeba sprawdzic czy przyjmie miliwolty
            if (TempMinAdvanced <= 20)
            {
                AW.ustawPrad(scalingParameters.SkalNaPrad(25));
            }
            if (TempMinAdvanced > 20 && TempMinAdvanced <= 32)
            {
                AW.ustawPrad(scalingParameters.SkalNaPrad(30));
            }
            if (TempMinAdvanced > 32)
            {
                AW.ustawPrad(scalingParameters.SkalNaPrad(35));
            }
            Thread.Sleep(15000);
            minParameterk = Wavecontrol.Readcm();
            minParameterv = Wavecontrol.ReadHZ();
            minParameterlambda = Wavecontrol.ReadWavelenght();
            Thread.Sleep(500);
            AW.ustawTemp(maxTV);
            AW.ustawPrad(scalingParameters.SkalNaPrad(74));
            Thread.Sleep(15000);
            maxParameterk = Wavecontrol.Readcm();
            maxParameterv = Wavecontrol.ReadHZ();
            maxParameterlambda = Wavecontrol.ReadWavelenght();
            MessageBox.Show("Dla " + TempMinAdvanced + "°C zmierzono: " + minParameterk + "cmˉ¹, " + minParameterv + "THz, " + minParameterlambda + "nm." + Environment.NewLine +
                            "Dla " + TempMaxAdvanced + "°C zmierzono: " + maxParameterk + "cmˉ¹, " + maxParameterv + "THz, " + maxParameterlambda + "nm");
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void StabAMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void StabAMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void StabTMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void StabTMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void StabTS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Averages_TextChanged(object sender, EventArgs e)
        {

        }

        private void Averages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TimeAverages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBminTHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBmaxTHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBstepTHz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void CzasvTMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void CzasvVMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBmincm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBmaxcm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBstepcm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void CzasKTMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void CzasKVMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBminnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBmaxnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBstepnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBstepnmTMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TBstepnmVMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        bool dlmarker = false;
        private void DL100Tuning_Click(object sender, EventArgs e)
        {
            if (!dlmarker)
            {
                DL100TUNING.Start();
                Grafrys.PerformClick();
            }
            else
                DL100TUNING.Abort();
            dlmarker = true;
        }
        private void DL100Vtuningf()
        {
            PointPairList PPL1 = new PointPairList();
            PointPairList PPL2 = new PointPairList();
            double TMIN, TMAX, StepT, TPOM, i, j, p, r, IN = 60000;
            double VMIN, VMAX, StepV, VPOM, OSmin, OSmax, POM;
            int x, y;
            SB = new StringBuilder();
            SBloop = new StringBuilder();
            int stoper = Kroktprad;
            double.TryParse(textBox5.Text, out Tempmin);
            double.TryParse(textBox6.Text, out Tempmax);
            double.TryParse(textBox7.Text, out Kroktemp);
            int.TryParse(textBox4.Text, out Kroktprad);
            double.TryParse(TextBox1.Text, out Napięciemin);
            double.TryParse(textBox2.Text, out Napięciemax);
            double.TryParse(textBox3.Text, out Krokprad);
            int.TryParse(textBox8.Text, out Krokttemp);
            TMIN = Convert.ToDouble(Tempmin);
            TMAX = Convert.ToDouble(Tempmax);
            StepT = Convert.ToDouble(Kroktemp);
            VMIN = Convert.ToDouble(Napięciemin);
            VMAX = Convert.ToDouble(Napięciemax);
            StepV = Convert.ToDouble(Krokprad);
            OSmin = VMIN;
            OSmax = VMAX;
            r = (TMAX - TMIN) / StepT;
            p = (VMAX - VMIN) / StepV;
            int stoperV = Kroktprad, stoperT = Krokttemp;
            TPOM = TMIN;
            VPOM = VMIN;
            stopWatch.Start();
            SB.Append("Czas (ms) " + " Temperatura " + " Prąd (mA)");
            Intro();
            for (j = 0; j <= p; j++)
            {
                if (TriggerY.Checked)
                {
                    EWHprzestroj.WaitOne();
                }

                VPOM = VMIN + j * StepV;
                while (pause == true)
                {
                    Thread.Sleep(100);
                }
                y = scalingParameters.SkalNaPrad(VPOM);
                AW.ustawPrad(y);         //Trzeba sprawdzic czy przyjmie miliwolty
                Thread.Sleep(stoperV);
                if (TriggerY.Checked)
                {
                    EWHustawiono.Set();
                }
                while (y != AW.odczytPrad())
                {
                    Thread.Sleep(10);
                }
                Stoper = stopWatch.ElapsedMilliseconds;
                SBloop.Clear();
                SBloop.Append("" + Environment.NewLine);
            }
            EWHendoftuning.Set();
            stopWatch.Stop();
            stopWatch.Reset();
            MessageBox.Show("Przestrajanie zakończone");
        }
        private void button11_Click(object sender, EventArgs e)
        {
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy chcesz wyzerować nadawany prąd i temperaturę?", "Kończenie pracy", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                AW.ustawPrad(0);
                AW.ustawTemp(0);

                Environment.Exit(Environment.ExitCode);
            }
            else if (result == DialogResult.No)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SaveLoop.ShowDialog();
            Task task = Task.Run(() =>
            {
                PointPairList PPL1 = new PointPairList();
                PointPairList PPL2 = new PointPairList();
                double TMIN, TMAX, StepT, TPOM, i, j, p, r, IN = 60000;
                double VMIN, VMAX, StepV, VPOM, OSmin, OSmax, POM;
                int x, y;
                SB = new StringBuilder();
                SBloop = new StringBuilder();
                int stoper = Kroktprad;
                double.TryParse(textBox5.Text, out Tempmin);
                double.TryParse(textBox6.Text, out Tempmax);
                double.TryParse(textBox7.Text, out Kroktemp);
                int.TryParse(textBox4.Text, out Kroktprad);
                double.TryParse(TextBox1.Text, out Napięciemin);
                double.TryParse(textBox2.Text, out Napięciemax);
                double.TryParse(textBox3.Text, out Krokprad);
                int.TryParse(textBox8.Text, out Krokttemp);
                TMIN = Convert.ToDouble(Tempmin);
                TMAX = Convert.ToDouble(Tempmax);
                StepT = Convert.ToDouble(Kroktemp);
                VMIN = Convert.ToDouble(Napięciemin);
                VMAX = Convert.ToDouble(Napięciemax);
                StepV = Convert.ToDouble(Krokprad);
                OSmin = VMIN;
                OSmax = VMAX;
                r = (TMAX - TMIN) / StepT;
                p = (VMAX - VMIN) / StepV;
                int stoperV = Kroktprad, stoperT = Krokttemp;
                TPOM = TMIN;
                VPOM = VMIN;
                stopWatch.Start();
                SB.Append("Czas (ms) " + " Temperatura " + " Prąd (mA)");
                for (j = 0; j <= 3000; j++)
                {
                    if (TriggerY.Checked)
                    {
                        EWHprzestroj.WaitOne();
                    }
                    while (pause == true)
                    {
                        Thread.Sleep(100);
                    }
                    if (j % 2 == 0)
                    {
                        AW.ustawPrad(scalingParameters.SkalNaPrad(VMIN));
                        VPOM = VMIN;
                    }
                    else
                    {
                        AW.ustawPrad(scalingParameters.SkalNaPrad(VMAX));
                        VPOM = VMAX;
                    }
                    Thread.Sleep(stoperV);
                    Stoper = stopWatch.ElapsedMilliseconds;
                    SB.Append(Stoper + "    " + TPOM + "    " + VPOM);
                    SBloop.Append(Stoper + ":" + TPOM + ":" + VPOM + ":");
                    using (StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName, true))
                    {
                        StreamLoop.Write("DFB " + SBloop + Environment.NewLine);
                    }
                    SBloop.Clear();
                    SBloop.Append("" + Environment.NewLine);
                    if (TriggerY.Checked)
                    {
                        EWHustawiono.Set();
                    }
                }
                EWHendoftuning.Set();
                stopWatch.Stop();
                stopWatch.Reset();
                MessageBox.Show("Przestrajanie zakończone");
            });
        }
        private void SeederCheckerFunction()
        {
            obslugaNW ONW = new obslugaNW();
            double TMIN, TMAX, StepT, TPOM, i, j, p, r, IN = 60000;
            double VMIN, VMAX, StepV, VPOM, OSmin, OSmax, POM;
            int x, y, averages, timeaverages;
            SBloop = new StringBuilder();
            int stoper = Kroktprad;
            double.TryParse(textBox5.Text, out Tempmin);
            double.TryParse(textBox6.Text, out Tempmax);
            double.TryParse(textBox7.Text, out Kroktemp);
            int.TryParse(textBox4.Text, out Kroktprad);
            double.TryParse(TextBox1.Text, out Napięciemin);
            double.TryParse(textBox2.Text, out Napięciemax);
            double.TryParse(textBox3.Text, out Krokprad);
            int.TryParse(textBox8.Text, out Krokttemp);
            TMIN = Convert.ToDouble(Tempmin);
            TMAX = Convert.ToDouble(Tempmax);
            StepT = Convert.ToDouble(Kroktemp);
            VMIN = Convert.ToDouble(Napięciemin);
            VMAX = Convert.ToDouble(Napięciemax);
            StepV = Convert.ToDouble(Krokprad);
            int.TryParse(Averages.Text, out averages);
            int.TryParse(TimeAverages.Text, out timeaverages);
            OSmin = VMIN;
            OSmax = VMAX;
            r = (TMAX - TMIN) / StepT;
            p = (VMAX - VMIN) / StepV;
            StreamWriter StreamLoop = new StreamWriter(SaveLoop.FileName);
            int stoperV = Kroktprad, stoperT = Krokttemp;
            TPOM = TMIN;
            VPOM = VMIN;
            stopWatch.Start();
            SBloop.Append("Czas (ms) " + " Temperatura " + " Prąd (mA)" + " Liczba Falowa (cm)");
            SBloop.Append("" + Environment.NewLine);
            for (i = 0; i <= r; i++)
            {
                TPOM = TMIN + i * StepT;
                x = scalingParameters.SkalNaTemp(TPOM);
                AW.ustawTemp(x);         //trzeba sprawdzic stopnie
                Thread.Sleep(stoperT);
                stopWatch.Stop();
                Stoper = stopWatch.ElapsedMilliseconds;
                stopWatch.Start();
                for (j = 0; j <= p; j++)
                {
                    if (TriggerY.Checked)
                    {
                        if (EWHprzestroj.WaitOne())
                        {

                        }
                    }

                    VPOM = VMIN + j * StepV;
                    y = scalingParameters.SkalNaPrad(VPOM);
                    AW.ustawPrad(y);         //Trzeba sprawdzic czy przyjmie miliwolty
                    Thread.Sleep(stoperV);
                    for (int k = 0; k < averages; k++)
                    {
                        Stoper = stopWatch.ElapsedMilliseconds;
                        SBloop.Append(Stoper + ":" + TPOM + ":" + VPOM + ":" + Wavecontrol.Readcm() + ":" + obslugaNW.odczytszerokosci() + ':');
                        var WM = obslugaNW.odczytajPrazkiPierwszyIntenf();
                        foreach (var z in WM)
                        {
                            SBloop.Append(z.ToString() + ":");
                        }
                        SBloop.Append("" + Environment.NewLine);
                        StreamLoop.Write(SBloop);
                        SBloop.Clear();
                        Thread.Sleep(timeaverages);
                    }
                    EWHustawiono.Set();
                }
            }
            stopWatch.Stop();
            stopWatch.Reset();
            StreamLoop.Close();
            MessageBox.Show("Przestrajanie zakończone");
        }
        private void SeederChecker_Click(object sender, EventArgs e)
        {
            SaveLoop.ShowDialog();
            wmtester.Start();
        }

        private void SaveLoop_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            double a;
            a = Laser.Properties.Settings.Default.Dioda2A1LOWcm;
            MessageBox.Show("" + a);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void Check()
        {
            if (Dioda1.Checked)
            {
                Laser.Properties.Settings.Default.ChosenDiode = 1;
                Laser.Properties.Settings.Default.Save();
            }
            if (Dioda2.Checked)
            {
                Laser.Properties.Settings.Default.ChosenDiode = 2;
                Laser.Properties.Settings.Default.Save();
            }
            if (Dioda3.Checked)
            {
                Laser.Properties.Settings.Default.ChosenDiode = 3;
                Laser.Properties.Settings.Default.Save();
            }
        }
        private void Dioda1_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void Dioda2_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void Dioda3_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void MaxTempPlus_Click(object sender, EventArgs e)
        {
            TempMaxAdvanced = TempMaxAdvanced + 0.1;
            LabelMaxTemp.Text = "Max. Temp. " + TempMaxAdvanced + "(°C)";
        }

        private void MaxTempMinus_Click(object sender, EventArgs e)
        {
            TempMaxAdvanced = TempMaxAdvanced - 0.1;
            LabelMaxTemp.Text = "Max. Temp. " + TempMaxAdvanced + "(°C)";
        }

        private void Combofalo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Radiooscylo_CheckedChanged(object sender, EventArgs e)
        {
            if (Radiofalo.Checked)
            {
                Combooscylo.Enabled = false;
                Combofalo.Enabled = true;
                Combooscylo.Text = "-";
                Graphrubber = true;
            }
            else
            {
                Combooscylo.Enabled = true;
                Combofalo.Enabled = false;
                Combofalo.Text = "-";
                Graphrubber = true;
            }
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Zapisz
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            StreamWriter SW = new StreamWriter(saveFileDialog1.FileName);
            //   SW.Write(SBV);
            //SW.Write(SBVproba);
            SW.Write(SB);
            //SBV.Clear();
            //SBT.Clear();
            SW.Close();
            SB.Clear();
        }
        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            StreamWriter SW = new StreamWriter(saveFileDialog2.FileName);
            SW.Write(SBoscyl);
            SW.Close();
            SBoscyl.Clear();
        }
    }
}
