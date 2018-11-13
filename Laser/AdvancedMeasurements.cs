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
    class AdvancedMeasurements
    {
        ScalingParameters scalingParameters;
        obsługaAdWina AW;
        private ADwin.Driver.ADwinSystem aDwinSystem1; //BLAD moze byc tutaj

        public double ktolambda(double a)
         {
            double lambda;
            lambda = 1 / a;
            lambda = lambda * Math.Pow(1/10, 7);
            return lambda;
         }

        public double Etolambda(double a)
        {
            double lambda;
            double Plank, c;
            c = 299792458;
            Plank = 4.135667662 * Math.Pow(1/10, 15);
            lambda = c * Plank/ a;
            return lambda;
        }

        public double vtolambda(double a)
        {
            double lambda, c;
            c = 299792458;
            lambda = c / a;
            lambda = lambda * Math.Pow(1 / 10, 9);
            return lambda;
        }

        public double lambdatok(double b)
        {
            double k;
            k = 1 / b;
            k = k * Math.Pow(10, 7);
            return k;
        }

        public double lambdatoE(double b)
        {
            double E;
            double Plank, c;
            c = 299792458;
            Plank = 4.135667662 * Math.Pow(1 / 10, 15);
            E = c * Plank / b;
            return E;
        }

        public double lambdatov(double b)
        {
            double v, c;
            c = 299792458;
            v = c / b;
            v = v * Math.Pow(10, 9);
            return v;
        }

        public void Freq(double min, double max, double step, int timestepT, int timestepV)
        {
        double Lambdamin, Lambdamax, Lambdastep;
            Lambdamin = vtolambda(min);
            Lambdamax = vtolambda(max);
            Lambdastep = vtolambda(step);
        }

        public void Energy()
        {
            double min, max, step;
            int timestepT, TimestepV;
            // double Lambdamin, Lambdamax, Lambdastep;
            //  Lambdamin = Etolambda(min);
            //  Lambdamax = Etolambda(max);
            //    Lambdastep = Etolambda(step);
            Wavelenghtnm(1, 2, 3, 4, 5);
        }

        public void Wavek(double min, double max, double step, int timestepT, int timestepV)
        {
            double Lambdamin, Lambdamax, Lambdastep;
            Lambdamin = ktolambda(min);
            Lambdamax = ktolambda(max);
            Lambdastep = ktolambda(step);
        }
        public void Wavelenghtnm(double min, double max, double step, int timestepT, int timestepV)
        {
            double POM = 0, MIN = 0, MAX = 0, STEP = 0;
            switch (Laser.Properties.Settings.Default.ScalingParameter)
            {
                case 1:
                    MIN = ktolambda(min);
                    MAX = ktolambda(max);
                    STEP = ktolambda(step);
                    break;
                case 2:
                    MIN = Etolambda(min);
                    MAX = Etolambda(max);
                    STEP = Etolambda(step);
                    break;
                case 3:
                    MIN = min;
                    MAX = max;
                    STEP = step;
                    break;
                case 4:
                    MIN = vtolambda(min);
                    MAX = vtolambda(max);
                    STEP = vtolambda(step);
                    break;
            }
        }

        public double Tforkseeker(double k, bool halp)
        {
            double PomT = 4, dk = 0, dkpom = 100000, k1 =0;
            scalingParameters = new ScalingParameters();
            while (true)
            {
                if(PomT <= 20 && halp == false)
                {
                    k1 = scalingParameters.Lowtemptemptok(PomT);
                }
                if (PomT > 20 && PomT <=32 && halp == false)
                {
                    k1 = scalingParameters.Midtemptemptok(PomT);
                }
                if (PomT > 32 && halp == false)
                {
                    k1 = scalingParameters.Hightemptemptok(PomT);
                }
                if (halp == true)
                {
                    k1 = scalingParameters.Maxtemptemptok(PomT);
                }
                //k1 = apomT + b
                dk = Math.Abs(k - k1);
                if (dk > dkpom)
                {
                    break;
                }
                else
                {
                    if(PomT <=20)
                    {

                    }
                    PomT = PomT + 0.1;
                    dkpom = dk;
                }
                if (PomT > 40)
                {
                    break;
                }
            }
            PomT = Math.Round(PomT, 1);
            return PomT;
        }

        public double Tforlambdaseeker(double lambda, bool halp)
        {
            double PomT = 4, dlambda = 0, dlambdapom = 100000, lambda1 = 0;
            scalingParameters = new ScalingParameters();
            while (true)
            {
                //k1 = apomT + b
                if (PomT <= 20 && halp == false)
                {
                    lambda1 = scalingParameters.Lowtemptemptolambda(PomT);
                }
                if (PomT > 20 && PomT <= 32 && halp == false)
                {
                    lambda1 = scalingParameters.Midtemptemptolambda(PomT);
                }
                if (PomT > 32 && halp == false)
                {
                    lambda1 = scalingParameters.Hightemptemptolambda(PomT);
                }
                if (halp == true)
                {
                    lambda1 = scalingParameters.Maxtemptemptolambda(PomT);
                }
                dlambda = Math.Abs(lambda - lambda1);
                if (dlambda > dlambdapom)
                {
                    break;
                }
                else
                {
                    PomT = PomT + 0.1;
                    dlambdapom = dlambda;
                }
                if (PomT > 40)
                {
                    break;
                }
            }
            return PomT;
        }

        public double TforHzseeker(double freq, bool halp)
        {
            double PomT = 4, dfreq = 0, dfreqpom = 100000, freq1 = 0;
            scalingParameters = new ScalingParameters();
            while (true)
            {
                if (PomT <= 20 && halp == false)
                {
                    freq1 = scalingParameters.Lowtemptemptofreq(PomT);
                }
                if (PomT > 20 && PomT <= 32 && halp == false)
                {
                    freq1 = scalingParameters.Midtemptemptofreq(PomT);
                }
                if (PomT > 32 && halp == false)
                {
                    freq1 = scalingParameters.Hightemptemptofreq(PomT);
                }
                if (halp == true)
                {
                    freq1 = scalingParameters.Maxtemptemptofreq(PomT);
                }
                //k1 = apomT + b
                dfreq = Math.Abs(freq - freq1);
                if (dfreq > dfreqpom)
                {
                    break;
                }
                else
                {
                    PomT = PomT + 0.1;
                    dfreqpom = dfreq;
                }

                if(PomT > 40)
                {
                    break;
                }
            }
            return PomT;
        }

        
        //##############################################
        //##############################################
        //##############################################
        //##############################################
        //##############################################
        //##############################################
        //##############################################
        //##############################################
        //##############################################
        public double CurrentAmmountPerStep(double temp)
        {
            if (temp <= 20)
                return 49;
            if (temp > 20 && temp <= 32)
                return 44;
            if (temp > 32 && temp <= 40)
                return 39;
            else
                return 0;

        }

    }
}