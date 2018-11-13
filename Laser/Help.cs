using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laser
{
    class Help
    {
        public bool AllConditions(double a,double b, double c, double d)
        {
            if(ToLowV(a) == true && ToHighV(b) == true && ToLowT(c) == true && ToHighT(d) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPrad(double a, double b)
        {
            if(ToLowV(a) == true && ToHighV(b) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckTemp(double a, double b)
        {
            if (ToLowT(a) == true && ToHighT(b) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ToLowV(double x)
        {
            int checkD = Laser.Properties.Settings.Default.ChecklistDiode;
            double V;
            switch (checkD)
            {
                case 1:
                    V = Laser.Properties.Settings.Default.Dioda1MinV;
                    if(x >= V)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    V = Laser.Properties.Settings.Default.Dioda2MinV;
                    if (x >= V)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    V = Laser.Properties.Settings.Default.Dioda3MinV;
                    if (x >= V)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }

        }

        public bool ToHighV(double x)
        {
            int checkD = Laser.Properties.Settings.Default.ChecklistDiode;
            double V;
            switch (checkD)
            {
                case 1:
                    V = Laser.Properties.Settings.Default.Dioda1MaxV;
                    if(x <= V)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    V = Laser.Properties.Settings.Default.Dioda2MaxV;
                    if (x <= V)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    V = Laser.Properties.Settings.Default.Dioda3MaxV;
                    if (x <= V)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

        public bool ToLowT(double x)
        {
            int checkD = Laser.Properties.Settings.Default.ChecklistDiode;
            double T;
            switch (checkD)
            {
                case 1:
                    T = Laser.Properties.Settings.Default.Dioda1MinT;
                    if (x >= T)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    T = Laser.Properties.Settings.Default.Dioda2MinT;
                    if (x >= T)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    T = Laser.Properties.Settings.Default.Dioda3MinT;
                    if (x >= T)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

        public bool ToHighT(double x)
        {
            int checkD = Laser.Properties.Settings.Default.ChecklistDiode;
            double T;
            switch (checkD)
            {
                case 1:
                    T = Laser.Properties.Settings.Default.Dioda1MaxT;
                    if (x <= T)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    T = Laser.Properties.Settings.Default.Dioda2MaxT;
                    if (x <= T)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    T = Laser.Properties.Settings.Default.Dioda3MaxV;
                    if (x <= T)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
    }
}
