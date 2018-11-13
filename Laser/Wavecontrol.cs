using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wlmData;

namespace Laser
{
    class Wavecontrol
    {
        public static double Readcm()
        {
            return 10 * WLM.GetFrequency(0) / (0.299792458);
        }

        public static double ReadHZ()
        {
            return 10 * WLM.GetFrequency(0) / 10.0;
        }

        public static double ReadWavelenght()
        {
            return  WLM.GetWavelength(0);
        }
        public static double ReadEnergy()
        {
            return 4.135667662 * Math.Pow(1 / 10, 15) * 10 * WLM.GetFrequency(0) / 10.0;
        }
    }
}
