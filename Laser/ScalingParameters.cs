using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laser
{
    class ScalingParameters
    {
       

        public int SkalNaTemp(double t)
        {
            double V;
            int POM;
            V = 2993.56 - 200.641 * t - 0.062 * t * t + 0.0008 * t * t * t;
            POM = Convert.ToInt32(V);
            return POM;
        }

        public int SkalNaPrad(double A)
        {
            double V;
            int POM;
            V = 96.0343 + 130.417 * A - 0.0282 * A * A + 0.0004 * A * A * A;
            POM = Convert.ToInt32(V);
            return POM;
        }
        public double Templine(int V)
        {
            return 14.85408 - 0.00495 * V;
        }

        public double Pradline(int V)
        {
            return -0.70252 + 0.00768 * V;
        }


        //##############################################
        //##############################################
        //##############################################
        //##############################################
        //##############################################
        //##############################################


        public double Lowtemplambdatotemp(double lambda)
        {
            double temp;
            temp = (lambda - 778.17056) / 0.05384;
            return temp;
        }
        public double Lowtempktotemp(double k)
        {
            double temp;
            temp = (k - 12850.64502) / -0.88759;
            return temp;
        }
        public double Lowtempfreqtotemp(double freq)
        {
            double temp;
            temp = (freq - 385.25265) / -0.02661;
            return temp;
        }

        //##############################################
        //##############################################

        public double Midtemplambdatotemp(double lambda)
        {
            double temp;
            temp = (lambda - 778.15733) / 0.00391;
            return temp;
        }
        public double Midtempktotemp(double k)
        {
            double temp;
            temp = (k - 12850.83062) / -0.89491;
            return temp;
        }
        public double Midtempfreqtotemp(double freq)
        {
            double temp;
            temp = (freq - 385.25821) / -0.02683;
            return temp;
        }

        //##############################################
        //##############################################

        public double Hightemplambdatotemp(double lambda)
        {
            double temp;
            temp = (lambda - 777.94011) / 0.0616;
            return temp;
        }
        public double Hightempktotemp(double k)
        {
            double temp;
            temp = (k - 12854.36025) / -1.01227;
            return temp;
        }
        public double Hightempfreqtotemp(double freq)
        {
            double temp;
            temp = (freq - 385.36403) / -0.03035;
            return temp;
        }

        //############################################## Problem moze byc tutaj 
        //##############################################

        public double Maxtemplambdatotemp(double lambda)
        {
            double temp;
            temp = 17.98446 * lambda - 13995.80534;
            return temp;
        }
        public double Maxtempktotemp(double k)
        {
            double temp;
            temp = -1.09268 * k + 14040.8148;
            return temp;
        }
        public double Maxtempfreqtotemp(double freq)
        {
            double temp;
            temp = -36.44794 * freq + 14040.8148;
            return temp;
        }

        //##############################################
        //##############################################
        //##############################################
        //##############################################
        //##############################################
        //##############################################

        public double Lowtemptemptolambda(double temp)
        {
        double lambda, A = 0, B = 0, C = 0, D = 0;
        if (Laser.Properties.Settings.Default.ChosenDiode == 1)
        {
            A = Laser.Properties.Settings.Default.Dioda1A1LOWnm;
            B = Laser.Properties.Settings.Default.Dioda1B1LOWnm;
            C = Laser.Properties.Settings.Default.Dioda1C1LOWnm;
            D = Laser.Properties.Settings.Default.Dioda1D1LOWnm;
        }
        if (Laser.Properties.Settings.Default.ChosenDiode == 2)
        {
            A = Laser.Properties.Settings.Default.Dioda2A1LOWnm;
            B = Laser.Properties.Settings.Default.Dioda2B1LOWnm;
            C = Laser.Properties.Settings.Default.Dioda2C1LOWnm;
            D = Laser.Properties.Settings.Default.Dioda2D1LOWnm;
        }
        if (Laser.Properties.Settings.Default.ChosenDiode == 3)
        {
            A = Laser.Properties.Settings.Default.Dioda3A1LOWnm;
            B = Laser.Properties.Settings.Default.Dioda3B1LOWnm;
            C = Laser.Properties.Settings.Default.Dioda3C1LOWnm;
            D = Laser.Properties.Settings.Default.Dioda3D1LOWnm;
        }
        lambda = A* temp * temp* temp+ B* temp * temp + C* temp + D;
        return lambda;
        }

        public double Lowtemptemptok(double temp)
        {
            double k, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1LOWcm;
                B = Laser.Properties.Settings.Default.Dioda1B1LOWcm;
                C = Laser.Properties.Settings.Default.Dioda1C1LOWcm;
                D = Laser.Properties.Settings.Default.Dioda1D1LOWcm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1LOWcm;
                B = Laser.Properties.Settings.Default.Dioda2B1LOWcm;
                C = Laser.Properties.Settings.Default.Dioda2C1LOWcm;
                D = Laser.Properties.Settings.Default.Dioda2D1LOWcm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1LOWcm;
                B = Laser.Properties.Settings.Default.Dioda3B1LOWcm;
                C = Laser.Properties.Settings.Default.Dioda3C1LOWcm;
                D = Laser.Properties.Settings.Default.Dioda3D1LOWcm;
            }
            k = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return k;
        }
        public double Lowtemptemptofreq(double temp)
        {
            double freq, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1LOWTHz;
                B = Laser.Properties.Settings.Default.Dioda1B1LOWTHz;
                C = Laser.Properties.Settings.Default.Dioda1C1LOWTHz;
                D = Laser.Properties.Settings.Default.Dioda1D1LOWTHz;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1LOWTHz;
                B = Laser.Properties.Settings.Default.Dioda2B1LOWTHz;
                C = Laser.Properties.Settings.Default.Dioda2C1LOWTHz;
                D = Laser.Properties.Settings.Default.Dioda2D1LOWTHz;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1LOWTHz;
                B = Laser.Properties.Settings.Default.Dioda3B1LOWTHz;
                C = Laser.Properties.Settings.Default.Dioda3C1LOWTHz;
                D = Laser.Properties.Settings.Default.Dioda3D1LOWTHz;
            }
            freq = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return freq;
        }

        //##############################################
        //##############################################

        public double Midtemptemptolambda (double temp)
        {
            double lambda, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1MIDnm;
                B = Laser.Properties.Settings.Default.Dioda1B1MIDnm;
                C = Laser.Properties.Settings.Default.Dioda1C1MIDnm;
                D = Laser.Properties.Settings.Default.Dioda1D1MIDnm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1MIDnm;
                B = Laser.Properties.Settings.Default.Dioda2B1MIDnm;
                C = Laser.Properties.Settings.Default.Dioda2C1MIDnm;
                D = Laser.Properties.Settings.Default.Dioda2D1MIDnm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1MIDnm;
                B = Laser.Properties.Settings.Default.Dioda3B1MIDnm;
                C = Laser.Properties.Settings.Default.Dioda3C1MIDnm;
                D = Laser.Properties.Settings.Default.Dioda3D1MIDnm;
            }
            lambda = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return lambda;
        }
        public double Midtemptemptok(double temp)
        {
            double k, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1MIDcm;
                B = Laser.Properties.Settings.Default.Dioda1B1MIDcm;
                C = Laser.Properties.Settings.Default.Dioda1C1MIDcm;
                D = Laser.Properties.Settings.Default.Dioda1D1MIDcm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1MIDcm;
                B = Laser.Properties.Settings.Default.Dioda2B1MIDcm;
                C = Laser.Properties.Settings.Default.Dioda2C1MIDcm;
                D = Laser.Properties.Settings.Default.Dioda2D1MIDcm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1MIDcm;
                B = Laser.Properties.Settings.Default.Dioda3B1MIDcm;
                C = Laser.Properties.Settings.Default.Dioda3C1MIDcm;
                D = Laser.Properties.Settings.Default.Dioda3D1MIDcm;
            }
            k = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return k;
        }
        public double Midtemptemptofreq(double temp)
        {
            double freq, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1MIDTHz;
                B = Laser.Properties.Settings.Default.Dioda1B1MIDTHz;
                C = Laser.Properties.Settings.Default.Dioda1C1MIDTHz;
                D = Laser.Properties.Settings.Default.Dioda1D1MIDTHz;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1MIDTHz;
                B = Laser.Properties.Settings.Default.Dioda2B1MIDTHz;
                C = Laser.Properties.Settings.Default.Dioda2C1MIDTHz;
                D = Laser.Properties.Settings.Default.Dioda2D1MIDTHz;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1MIDTHz;
                B = Laser.Properties.Settings.Default.Dioda3B1MIDTHz;
                C = Laser.Properties.Settings.Default.Dioda3C1MIDTHz;
                D = Laser.Properties.Settings.Default.Dioda3D1MIDTHz;
            }
            freq = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return freq;
        }

        //##############################################
        //##############################################

        public double Hightemptemptolambda(double temp)
        {
            double lambda, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1HIGHnm;
                B = Laser.Properties.Settings.Default.Dioda1B1HIGHnm;
                C = Laser.Properties.Settings.Default.Dioda1C1HIGHnm;
                D = Laser.Properties.Settings.Default.Dioda1D1HIGHnm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1HIGHnm;
                B = Laser.Properties.Settings.Default.Dioda2B1HIGHnm;
                C = Laser.Properties.Settings.Default.Dioda2C1HIGHnm;
                D = Laser.Properties.Settings.Default.Dioda2D1HIGHnm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1HIGHnm;
                B = Laser.Properties.Settings.Default.Dioda3B1HIGHnm;
                C = Laser.Properties.Settings.Default.Dioda3C1HIGHnm;
                D = Laser.Properties.Settings.Default.Dioda3D1HIGHnm;
            }
            lambda = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return lambda;
        }
        public double Hightemptemptok(double temp)
        {
            double k, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1HIGHcm;
                B = Laser.Properties.Settings.Default.Dioda1B1HIGHcm;
                C = Laser.Properties.Settings.Default.Dioda1C1HIGHcm;
                D = Laser.Properties.Settings.Default.Dioda1D1HIGHcm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1HIGHcm;
                B = Laser.Properties.Settings.Default.Dioda2B1HIGHcm;
                C = Laser.Properties.Settings.Default.Dioda2C1HIGHcm;
                D = Laser.Properties.Settings.Default.Dioda2D1HIGHcm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1HIGHcm;
                B = Laser.Properties.Settings.Default.Dioda3B1HIGHcm;
                C = Laser.Properties.Settings.Default.Dioda3C1HIGHcm;
                D = Laser.Properties.Settings.Default.Dioda3D1HIGHcm;
            }
            k = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return k;
        }
        public double Hightemptemptofreq(double temp)
        {
            double freq, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1HIGHTHz;
                B = Laser.Properties.Settings.Default.Dioda1B1HIGHTHz;
                C = Laser.Properties.Settings.Default.Dioda1C1HIGHTHz;
                D = Laser.Properties.Settings.Default.Dioda1D1HIGHTHz;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1HIGHTHz;
                B = Laser.Properties.Settings.Default.Dioda2B1HIGHTHz;
                C = Laser.Properties.Settings.Default.Dioda2C1HIGHTHz;
                D = Laser.Properties.Settings.Default.Dioda2D1HIGHTHz;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1HIGHTHz;
                B = Laser.Properties.Settings.Default.Dioda3B1HIGHTHz;
                C = Laser.Properties.Settings.Default.Dioda3C1HIGHTHz;
                D = Laser.Properties.Settings.Default.Dioda3D1HIGHTHz;
            }
            freq = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return freq;
        }

        //############################################## Problem moze byc tutaj 
        //############################################## 
        // TRZEBA TUTAJ POPRAWIC BO COS NIE GRA
        public double Maxtemptemptolambda(double temp)
        {
            double lambda, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1HIGHHnm;
                B = Laser.Properties.Settings.Default.Dioda1B1HIGHHnm;
                C = Laser.Properties.Settings.Default.Dioda1C1HIGHHnm;
                D = Laser.Properties.Settings.Default.Dioda1D1HIGHHnm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1HIGHHnm;
                B = Laser.Properties.Settings.Default.Dioda2B1HIGHHnm;
                C = Laser.Properties.Settings.Default.Dioda2C1HIGHHnm;
                D = Laser.Properties.Settings.Default.Dioda2D1HIGHHnm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1HIGHHnm;
                B = Laser.Properties.Settings.Default.Dioda3B1HIGHHnm;
                C = Laser.Properties.Settings.Default.Dioda3C1HIGHHnm;
                D = Laser.Properties.Settings.Default.Dioda3D1HIGHHnm;
            }
            lambda = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return lambda;
        }
        public double Maxtemptemptok(double temp)
        {
            double k, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1HIGHHcm;
                B = Laser.Properties.Settings.Default.Dioda1B1HIGHHcm;
                C = Laser.Properties.Settings.Default.Dioda1C1HIGHHcm;
                D = Laser.Properties.Settings.Default.Dioda1D1HIGHHcm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1HIGHHcm;
                B = Laser.Properties.Settings.Default.Dioda2B1HIGHHcm;
                C = Laser.Properties.Settings.Default.Dioda2C1HIGHHcm;
                D = Laser.Properties.Settings.Default.Dioda2D1HIGHHcm;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1HIGHHcm;
                B = Laser.Properties.Settings.Default.Dioda3B1HIGHHcm;
                C = Laser.Properties.Settings.Default.Dioda3C1HIGHHcm;
                D = Laser.Properties.Settings.Default.Dioda3D1HIGHHcm;
            }
            k = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return k;
        }
        public double Maxtemptemptofreq(double temp)
        {
            double freq, A = 0, B = 0, C = 0, D = 0;
            if (Laser.Properties.Settings.Default.ChosenDiode == 1)
            {
                A = Laser.Properties.Settings.Default.Dioda1A1HIGHHTHz;
                B = Laser.Properties.Settings.Default.Dioda1B1HIGHHTHz;
                C = Laser.Properties.Settings.Default.Dioda1C1HIGHHTHz;
                D = Laser.Properties.Settings.Default.Dioda1D1HIGHHTHz;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 2)
            {
                A = Laser.Properties.Settings.Default.Dioda2A1HIGHHTHz;
                B = Laser.Properties.Settings.Default.Dioda2B1HIGHHTHz;
                C = Laser.Properties.Settings.Default.Dioda2C1HIGHHTHz;
                D = Laser.Properties.Settings.Default.Dioda2D1HIGHHTHz;
            }
            if (Laser.Properties.Settings.Default.ChosenDiode == 3)
            {
                A = Laser.Properties.Settings.Default.Dioda3A1HIGHHTHz;
                B = Laser.Properties.Settings.Default.Dioda3B1HIGHHTHz;
                C = Laser.Properties.Settings.Default.Dioda3C1HIGHHTHz;
                D = Laser.Properties.Settings.Default.Dioda3D1HIGHHTHz;
            }
            freq = A * temp * temp * temp + B * temp * temp + C * temp + D;
            return freq;
        }
    }


}
