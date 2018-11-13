using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADwin;
using System.Windows.Forms;

namespace Laser
{
    public class obsługaAdWina
    {
        ADwin.Driver.ADwinSystem aDwinSystem1;
        public obsługaAdWina(ADwin.Driver.ADwinSystem sterownik)
        {
            aDwinSystem1 = sterownik;
        }
        public bool inicjalizuj()
        {
            //try
            {
              //  string process = "test.t91";
                string process3 = "proces3.T91";
                aDwinSystem1.Boot(ADwin.Driver.ProcessorType.T9); // Change to Processor you want to use
                aDwinSystem1.Processes[1].Load(process3); // load process
                aDwinSystem1.Processes[1].Start();
                return true;
            }
            // catch
            {
                // MessageBox.Show("problem z inicjalizacją");
                return false;
            }
        }

        public int odczytPrad()
        {
            return aDwinSystem1.Pars[1].Value;
        }
        public bool ustawPrad(int ile)
        {
            if (ile >= -10000 && ile <= 10000)
            {
                aDwinSystem1.Pars[1].Value = ile;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int odczytTemp()
        {
            return aDwinSystem1.Pars[2].Value;
        }
        public bool ustawTemp(int ile)
        {
            if (ile >= -10000 && ile <= 10000)
            {
                aDwinSystem1.Pars[2].Value = ile;
                return true;
            }
            else
            {
                return false;
            }
        }
        //textBox1.Text = aDwinSystem1.Pars[1].Value.ToString();

    }
}
