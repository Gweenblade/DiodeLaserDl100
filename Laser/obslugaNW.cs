using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wlmData;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Laser
{
    [Serializable]
    public class WMrezult
    {
       


        public double[] frequency;
        public double[] szerokosc;
        public double FRQ;
        public WMrezult(int x)
        {
            frequency=new double[x];
            szerokosc = new double[x]; 
        }

        public short[] prazki1;
        public short[] prazki2;

        public List<short[]> tablicaPrazkow1;
        public List<short[]> tablicaPrazkow2;


        public double LICZFRQ()
        {
            FRQ = MEAN(frequency);
            return FRQ;
        }
        private double MEAN(double[] inp)
        {
            double sumka=0;
            for(int i=0;i<inp.Length;i++)
            {
                sumka+=inp[i];
            }            
            return sumka / inp.Length;
        }

    }

    class obslugaNW
    {
        static double swmlength;

        [DllImport("wtyczka.dll")]
        public static extern void prazki1(short[] tab);
        [DllImport("wtyczka.dll")]
        public static extern void prazki2(short[] tab);



        public static short[] odczytajPrazkiPierwszyIntenf()
        {
            short[] p1 = new short[2048];
            prazki1(p1);
            return p1;
        }



        public static short[] odczytajPrazkiDrugiIntenf()
        {
            short[] p2 = new short[2048];
            prazki2(p2);
            return p2;
        }

        public static double odczytNowegoWMcm(bool podwajamy) ///odczyt w THz zmieniony na cm^-1  jeśli argument true to wynik podwajamy
        {

            try
            {
                swmlength = (wlmData.WLM.GetFrequency(0) / (0.299792458));
                

                if (podwajamy == true)
                {
                    swmlength = 2 * swmlength;  //podwajamy
                }


               
                return (swmlength * 10);
                
            }
            catch (Exception ex)
            {
                return -1;           
            }



        }

        public static double odczytNowegoWMnm() ///odczyt w THz zmieniony na cm^-1  jeśli argument true to wynik podwajamy
        {

            try
            {
                swmlength = wlmData.WLM.GetWavelength(0);
                
                return swmlength; 
               
            }
            catch (Exception ex)
            {
                return -1;
            }



        }

        static public void aktywujWM()
        {
            WLM.ControlWLM(WLM.cCtrlWLMShow, 0, 0);   
           
        }

        static public double[] odczytwielokrotnycm(int ile,int mssleepTime)
        {
            
            double[] x=new double[ile];
            try{
            for(int i=0;i<ile;i++)
            {
                x[i] = odczytNowegoWMcm(false);
                Thread.Sleep(mssleepTime);
            }
            }
            catch(Exception EX)
            {
               
            }
            return x;
            
        }

        static public WMrezult odczytwielokrotnycmZszerokoscia(int ile, int mssleepTime)
        {
            WMrezult temp = new WMrezult(ile);
            //double[] x = new double[ile];
            try
            {
                for (int i = 0; i < ile; i++)
                {
                    temp.frequency[i] = odczytNowegoWMcm(false);
                    Thread.Sleep(10);
                    temp.szerokosc[i] = odczytszerokosci(); ;
                    Thread.Sleep(mssleepTime);
                }
            }
            catch (Exception EX)
            {

            }
            return temp;

        }


        public static double odczytszerokosci() ///odczyt w THz zmieniony na cm^-1  jeśli argument true to wynik podwajamy
        {
            try
            {
               
                double temp = (wlmData.WLM.GetLinewidth(WLM.cReturnFrequency, 0)) ;

                return temp;
            }
            catch
            {
                return -200.0;
            }



        }

        static public double odczytUSREDNIONYcm(int ile, int mssleepTime)
        {
            double[] x = new double[ile];
            
            for (int i = 0; i < ile; i++)
            {
                double temp = odczytNowegoWMcm(false);
                if (temp >= 0)
                {
                    x[i] = temp;
                }
                else
                {
                    int iterator=0;
                    while (iterator < 5 && temp < 0)
                    {
                        Thread.Sleep(mssleepTime);
                        iterator++;
                        temp = odczytNowegoWMcm(false);
                    }
                    x[i] = temp;
                    if (temp < 0) //nie udało się wczytać
                    {
                        DialogResult DR= MessageBox.Show("Problem z wczytaniem długości fali. Najpewniej wiązka źle pada na Wavemeter. Błąd " + temp.ToString()+"Czy ponowić pomiar po rozwiązaniu problemu???","Problem",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (DR == DialogResult.Yes)
                        {
                            i = 0;
                        }
                    }
                }
               
                Thread.Sleep(mssleepTime);
            }
            double sumka = 0;
            for (int i = 0; i < ile; i++)
            {
                sumka += x[i];
            }
            return sumka / ile;

        }




    }
       
   
}
