using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laser
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            label1.Text = "Pamietaj! Równanie skalujące jest postaci X = AT³ + BT² + CT + D";
            label12.Text = "T - Temperatura (°C), X - Liczba falowa (cmˉ¹) LUB Długość fali (nm) LUB Częstotliwość (THz)";
            label122.Text = "Pamietaj! Równanie skalujące jest postaci X = AT³ + BT² + CT + D";
            label121.Text = "T - Temperatura (°C), X - Liczba falowa (cmˉ¹) LUB Długość fali (nm) LUB Częstotliwość (THz)";
            label40.Text = "Pamietaj! Równanie skalujące jest postaci X = AT³ + BT² + CT + D";
            label39.Text = "T - Temperatura (°C), X - Liczba falowa (cmˉ¹) LUB Długość fali (nm) LUB Częstotliwość (THz)";
            {
                Dioda1A1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1LOWcm;
                Dioda1B1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1LOWcm;
                Dioda1C1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1LOWcm;
                Dioda1D1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1LOWcm;
                //###
                Dioda1A1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1LOWnm;
                Dioda1B1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1LOWnm;
                Dioda1C1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1LOWnm;
                Dioda1D1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1LOWnm;
                //###
                Dioda1A1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1A1LOWTHz;
                Dioda1B1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1B1LOWTHz;
                Dioda1C1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1C1LOWTHz;
                Dioda1D1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1D1LOWTHz;
                //###
                //###
                Dioda1A1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1MIDcm;
                Dioda1B1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1MIDcm;
                Dioda1C1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1MIDcm;
                Dioda1D1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1MIDcm;
                //###
                Dioda1A1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1MIDnm;
                Dioda1B1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1MIDnm;
                Dioda1C1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1MIDnm;
                Dioda1D1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1MIDnm;
                //###
                Dioda1A1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1A1MIDTHz;
                Dioda1B1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1B1MIDTHz;
                Dioda1C1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1C1MIDTHz;
                Dioda1D1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1D1MIDTHz;
                //###
                //###
                Dioda1A1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHcm;
                Dioda1B1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHcm;
                Dioda1C1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHcm;
                Dioda1D1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHcm;
                //###
                Dioda1A1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHnm;
                Dioda1B1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHnm;
                Dioda1C1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHnm;
                Dioda1D1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHnm;
                //###
                Dioda1A1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHTHz;
                Dioda1B1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHTHz;
                Dioda1C1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHTHz;
                Dioda1D1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHTHz;
                //###
                //###
                Dioda1A1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHHcm;
                Dioda1B1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHHcm;
                Dioda1C1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHHcm;
                Dioda1D1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHHcm;
                //###
                Dioda1A1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHHnm;
                Dioda1B1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHHnm;
                Dioda1C1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHHnm;
                Dioda1D1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHHnm;
                //###
                Dioda1A1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHHTHz;
                Dioda1B1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHHTHz;
                Dioda1C1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHHTHz;
                Dioda1D1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHHTHz;
            }




            {
                Dioda2A1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda2A1LOWcm;
                Dioda2B1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda2B1LOWcm;
                Dioda2C1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda2C1LOWcm;
                Dioda2D1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda2D1LOWcm;
                //###
                Dioda2A1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda2A1LOWnm;
                Dioda2B1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda2B1LOWnm;
                Dioda2C1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda2C1LOWnm;
                Dioda2D1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda2D1LOWnm;
                //###
                Dioda2A1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2A1LOWTHz;
                Dioda2B1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2B1LOWTHz;
                Dioda2C1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2C1LOWTHz;
                Dioda2D1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2D1LOWTHz;
                //###
                //###
                Dioda2A1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda2A1MIDcm;
                Dioda2B1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda2B1MIDcm;
                Dioda2C1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda2C1MIDcm;
                Dioda2D1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda2D1MIDcm;
                //###
                Dioda2A1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda2A1MIDnm;
                Dioda2B1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda2B1MIDnm;
                Dioda2C1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda2C1MIDnm;
                Dioda2D1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda2D1MIDnm;
                //###
                Dioda2A1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2A1MIDTHz;
                Dioda2B1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2B1MIDTHz;
                Dioda2C1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2C1MIDTHz;
                Dioda2D1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2D1MIDTHz;
                //###
                //###
                Dioda2A1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda2A1HIGHcm;
                Dioda2B1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda2B1HIGHcm;
                Dioda2C1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda2C1HIGHcm;
                Dioda2D1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda2D1HIGHcm;
                //###
                Dioda2A1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda2A1HIGHnm;
                Dioda2B1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda2B1HIGHnm;
                Dioda2C1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda2C1HIGHnm;
                Dioda2D1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda2D1HIGHnm;
                //###
                Dioda2A1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2A1HIGHTHz;
                Dioda2B1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2B1HIGHTHz;
                Dioda2C1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2C1HIGHTHz;
                Dioda2D1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2D1HIGHTHz;
                //###
                //###
                Dioda2A1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda2A1HIGHHcm;
                Dioda2B1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda2B1HIGHHcm;
                Dioda2C1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda2C1HIGHHcm;
                Dioda2D1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda2D1HIGHHcm;
                //###
                Dioda2A1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda2A1HIGHHnm;
                Dioda2B1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda2B1HIGHHnm;
                Dioda2C1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda2C1HIGHHnm;
                Dioda2D1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda2D1HIGHHnm;
                //###
                Dioda2A1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2A1HIGHHTHz;
                Dioda2B1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2B1HIGHHTHz;
                Dioda2C1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2C1HIGHHTHz;
                Dioda2D1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda2D1HIGHHTHz;
            }

            {
                Dioda3A1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda3A1LOWcm;
                Dioda3B1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda3B1LOWcm;
                Dioda3C1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda3C1LOWcm;
                Dioda3D1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda3D1LOWcm;
                //###
                Dioda3A1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda3A1LOWnm;
                Dioda3B1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda3B1LOWnm;
                Dioda3C1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda3C1LOWnm;
                Dioda3D1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda3D1LOWnm;
                //###
                Dioda3A1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3A1LOWTHz;
                Dioda3B1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3B1LOWTHz;
                Dioda3C1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3C1LOWTHz;
                Dioda3D1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3D1LOWTHz;
                //###
                //###
                Dioda3A1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda3A1MIDcm;
                Dioda3B1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda3B1MIDcm;
                Dioda3C1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda3C1MIDcm;
                Dioda3D1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda3D1MIDcm;
                //###
                Dioda3A1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda3A1MIDnm;
                Dioda3B1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda3B1MIDnm;
                Dioda3C1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda3C1MIDnm;
                Dioda3D1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda3D1MIDnm;
                //###
                Dioda3A1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3A1MIDTHz;
                Dioda3B1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3B1MIDTHz;
                Dioda3C1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3C1MIDTHz;
                Dioda3D1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3D1MIDTHz;
                //###
                //###
                Dioda3A1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda3A1HIGHcm;
                Dioda3B1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda3B1HIGHcm;
                Dioda3C1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda3C1HIGHcm;
                Dioda3D1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda3D1HIGHcm;
                //###
                Dioda3A1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda3A1HIGHnm;
                Dioda3B1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda3B1HIGHnm;
                Dioda3C1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda3C1HIGHnm;
                Dioda3D1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda3D1HIGHnm;
                //###
                Dioda3A1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3A1HIGHTHz;
                Dioda3B1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3B1HIGHTHz;
                Dioda3C1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3C1HIGHTHz;
                Dioda3D1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3D1HIGHTHz;
                //###
                //###
                Dioda3A1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda3A1HIGHHcm;
                Dioda3B1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda3B1HIGHHcm;
                Dioda3C1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda3C1HIGHHcm;
                Dioda3D1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda3D1HIGHHcm;
                //###
                Dioda3A1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda3A1HIGHHnm;
                Dioda3B1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda3B1HIGHHnm;
                Dioda3C1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda3C1HIGHHnm;
                Dioda3D1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda3D1HIGHHnm;
                //###
                Dioda3A1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3A1HIGHHTHz;
                Dioda3B1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3B1HIGHHTHz;
                Dioda3C1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3C1HIGHHTHz;
                Dioda3D1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda3D1HIGHHTHz;
            }


            int ChecklistD = Laser.Properties.Settings.Default.ChecklistDiode;
            switch (ChecklistD)
            {
                case 1:
                    {
                        radioButton1.Checked = true;
                        double TMAXBorder = Laser.Properties.Settings.Default.Dioda1MaxT;
                        double TMinBorder = Laser.Properties.Settings.Default.Dioda1MinT;
                        double VMAXBorder = Laser.Properties.Settings.Default.Dioda1MaxV;
                        double VMinBorder = Laser.Properties.Settings.Default.Dioda1MinV;
                        break;
                    }
                case 2:
                    {
                        radioButton2.Checked = true;
                        double TMAXBorder = Laser.Properties.Settings.Default.Dioda2MaxT;
                        double TMinBorder = Laser.Properties.Settings.Default.Dioda2MinT;
                        double VMAXBorder = Laser.Properties.Settings.Default.Dioda2MaxV;
                        double VMinBorder = Laser.Properties.Settings.Default.Dioda2MinV;
                        break;
                    }
                case 3:
                    {
                        radioButton3.Checked = true;
                        double TMAXBorder = Laser.Properties.Settings.Default.Dioda3MaxT;
                        double TMinBorder = Laser.Properties.Settings.Default.Dioda3MinT;
                        double VMAXBorder = Laser.Properties.Settings.Default.Dioda3MaxV;
                        double VMinBorder = Laser.Properties.Settings.Default.Dioda3MinV;
                        break;
                    }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Dioda1A1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1LOWcm;
            Dioda1B1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1LOWcm;
            Dioda1C1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1LOWcm;
            Dioda1D1LOWcm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1LOWcm;
            //###
            Dioda1A1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1LOWnm;
            Dioda1B1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1LOWnm;
            Dioda1C1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1LOWnm;
            Dioda1D1LOWnm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1LOWnm;
            //###
            Dioda1A1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1A1LOWTHz;
            Dioda1B1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1B1LOWTHz;
            Dioda1C1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1C1LOWTHz;
            Dioda1D1LOWTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1D1LOWTHz;
            //###
            //###
            Dioda1A1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1MIDcm;
            Dioda1B1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1MIDcm;
            Dioda1C1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1MIDcm;
            Dioda1D1MIDcm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1MIDcm;
            //###
            Dioda1A1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1MIDnm;
            Dioda1B1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1MIDnm;
            Dioda1C1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1MIDnm;
            Dioda1D1MIDnm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1MIDnm;
            //###
            Dioda1A1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1A1MIDTHz;
            Dioda1B1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1B1MIDTHz;
            Dioda1C1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1C1MIDTHz;
            Dioda1D1MIDTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1D1MIDTHz;
            //###
            //###
            Dioda1A1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHcm;
            Dioda1B1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHcm;
            Dioda1C1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHcm;
            Dioda1D1HIGHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHcm;
            //###
            Dioda1A1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHnm;
            Dioda1B1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHnm;
            Dioda1C1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHnm;
            Dioda1D1HIGHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHnm;
            //###
            Dioda1A1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHTHz;
            Dioda1B1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHTHz;
            Dioda1C1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHTHz;
            Dioda1D1HIGHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHTHz;
            //###
            //###
            Dioda1A1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHHcm;
            Dioda1B1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHHcm;
            Dioda1C1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHHcm;
            Dioda1D1HIGHHcm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHHcm;
            //###
            Dioda1A1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHHnm;
            Dioda1B1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHHnm;
            Dioda1C1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHHnm;
            Dioda1D1HIGHHnm.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHHnm;
            //###
            Dioda1A1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1A1HIGHHTHz;
            Dioda1B1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1B1HIGHHTHz;
            Dioda1C1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1C1HIGHHTHz;
            Dioda1D1HIGHHTHz.Text = "" + Laser.Properties.Settings.Default.Dioda1D1HIGHHTHz;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Niepotrzebne
            Check();
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Niepotrzebnee
            Check();
          
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //Niepotrzebne
            Check();
        }

        void Check()
        {
            if (radioButton1.Checked)
            {
                Laser.Properties.Settings.Default.ChecklistDiode = 1;
                DiodeMaxTControl.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda1MaxT);
                DiodeMinTcontrol.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda1MinT);
                DiodeMaxVControl.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda1MaxV);
                DiodeMinVControl.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda1MinV);
                Laser.Properties.Settings.Default.Save();
            }
            if (radioButton2.Checked)
            {
                Laser.Properties.Settings.Default.ChecklistDiode = 2;
                DiodeMaxTControl.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda2MaxT);
                DiodeMinTcontrol.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda2MinT);
                DiodeMaxVControl.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda2MaxV);
                DiodeMinVControl.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda2MinV);
                Laser.Properties.Settings.Default.Save();
            }
            if (radioButton3.Checked)
            {
                Laser.Properties.Settings.Default.ChecklistDiode = 3;
                DiodeMaxTControl.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda3MaxT);
                DiodeMinTcontrol.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda3MinT);
                DiodeMaxVControl.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda3MaxV);
                DiodeMinVControl.Text = Convert.ToString(Laser.Properties.Settings.Default.Dioda3MinV);
                Laser.Properties.Settings.Default.Save();
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            //Niepotrzebne
            int ChecklistD = Laser.Properties.Settings.Default.ChecklistDiode;
            double helpTmin, helpTmax, helpVmin, helpVmax;
            switch (ChecklistD)
            {
                case 1:
                    {
                        double.TryParse(DiodeMaxTControl.Text, out helpTmax);
                        double.TryParse(DiodeMinTcontrol.Text, out helpTmin);
                        double.TryParse(DiodeMaxVControl.Text, out helpVmax);
                        double.TryParse(DiodeMinVControl.Text, out helpVmin);
                        Laser.Properties.Settings.Default.Dioda1MaxT = helpTmax;
                        Laser.Properties.Settings.Default.Dioda1MinT = helpTmin;
                        Laser.Properties.Settings.Default.Dioda1MaxV = helpVmax;
                        Laser.Properties.Settings.Default.Dioda1MinV = helpVmin;
                        Laser.Properties.Settings.Default.Save();
                        break;
                    }
                case 2:
                    {
                        double.TryParse(DiodeMaxTControl.Text, out helpTmax);
                        double.TryParse(DiodeMinTcontrol.Text, out helpTmin);
                        double.TryParse(DiodeMaxVControl.Text, out helpVmax);
                        double.TryParse(DiodeMinVControl.Text, out helpVmin);
                        Laser.Properties.Settings.Default.Dioda2MaxT = helpTmax;
                        Laser.Properties.Settings.Default.Dioda2MinT = helpTmin;
                        Laser.Properties.Settings.Default.Dioda2MaxV = helpVmax;
                        Laser.Properties.Settings.Default.Dioda2MinV = helpVmin;
                        Laser.Properties.Settings.Default.Save();
                        break;
                    }
                case 3:
                    {
                        double.TryParse(DiodeMaxTControl.Text, out helpTmax);
                        double.TryParse(DiodeMinTcontrol.Text, out helpTmin);
                        double.TryParse(DiodeMaxVControl.Text, out helpVmax);
                        double.TryParse(DiodeMinVControl.Text, out helpVmin);
                        Laser.Properties.Settings.Default.Dioda3MaxT = helpTmax;
                        Laser.Properties.Settings.Default.Dioda3MinT = helpTmin;
                        Laser.Properties.Settings.Default.Dioda3MaxV = helpVmax;
                        Laser.Properties.Settings.Default.Dioda3MinV = helpVmin;
                        Laser.Properties.Settings.Default.Save();
                        break;
                    }
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Check();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            int ChecklistD = Laser.Properties.Settings.Default.ChecklistDiode;
            double helpTmin, helpTmax, helpVmin, helpVmax;
            switch (ChecklistD)
            {
                case 1:
                    {
                        double.TryParse(DiodeMaxTControl.Text, out helpTmax);
                        double.TryParse(DiodeMinTcontrol.Text, out helpTmin);
                        double.TryParse(DiodeMaxVControl.Text, out helpVmax);
                        double.TryParse(DiodeMinVControl.Text, out helpVmin);
                        Laser.Properties.Settings.Default.Dioda1MaxT = helpTmax;
                        Laser.Properties.Settings.Default.Dioda1MinT = helpTmin;
                        Laser.Properties.Settings.Default.Dioda1MaxV = helpVmax;
                        Laser.Properties.Settings.Default.Dioda1MinV = helpVmin;
                        Laser.Properties.Settings.Default.Save();
                        break;
                    }
                case 2:
                    {
                        double.TryParse(DiodeMaxTControl.Text, out helpTmax);
                        double.TryParse(DiodeMinTcontrol.Text, out helpTmin);
                        double.TryParse(DiodeMaxVControl.Text, out helpVmax);
                        double.TryParse(DiodeMinVControl.Text, out helpVmin);
                        Laser.Properties.Settings.Default.Dioda2MaxT = helpTmax;
                        Laser.Properties.Settings.Default.Dioda2MinT = helpTmin;
                        Laser.Properties.Settings.Default.Dioda2MaxV = helpVmax;
                        Laser.Properties.Settings.Default.Dioda2MinV = helpVmin;
                        Laser.Properties.Settings.Default.Save();
                        break;
                    }
                case 3:
                    {
                        double.TryParse(DiodeMaxTControl.Text, out helpTmax);
                        double.TryParse(DiodeMinTcontrol.Text, out helpTmin);
                        double.TryParse(DiodeMaxVControl.Text, out helpVmax);
                        double.TryParse(DiodeMinVControl.Text, out helpVmin);
                        Laser.Properties.Settings.Default.Dioda3MaxT = helpTmax;
                        Laser.Properties.Settings.Default.Dioda3MinT = helpTmin;
                        Laser.Properties.Settings.Default.Dioda3MaxV = helpVmax;
                        Laser.Properties.Settings.Default.Dioda3MinV = helpVmin;
                        Laser.Properties.Settings.Default.Save();
                        break;
                    }
            }
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            Check();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            Check();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            Graphics l = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            Pen o = new Pen(Color.Red, 2);
//gora
            l.DrawLine(o, 20, 10, 480, 10);
            l.DrawLine(o, 20, 50, 480, 50);
            l.DrawLine(o, 20, 10, 20, 50);
            l.DrawLine(o, 480, 10, 480, 50);
            //dól
            l.DrawLine(p, 20, 60, 480, 60);
            l.DrawLine(p, 20, 115, 480, 115);
            l.DrawLine(p, 20, 170, 480, 170);
            l.DrawLine(p, 20, 225, 480, 225);
            l.DrawLine(p, 20, 280, 480, 280);
            l.DrawLine(p, 20, 60, 20, 280);
            l.DrawLine(p, 111, 60, 111, 280);
            l.DrawLine(p, 202, 60, 202, 280);
            l.DrawLine(p, 293, 60, 293, 280);
            l.DrawLine(p, 384, 60, 384, 280);
            l.DrawLine(p, 480, 60, 480, 280);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Zapisz1_Click(object sender, EventArgs e)
        {
            double a;
            
            double.TryParse(Dioda1A1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1LOWcm = a;
            double.TryParse(Dioda1B1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1LOWcm = a;
            double.TryParse(Dioda1C1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1LOWcm = a;
            double.TryParse(Dioda1D1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1LOWcm = a;
            //###
            double.TryParse(Dioda1A1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1LOWnm = a;
            double.TryParse(Dioda1B1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1LOWnm = a;
            double.TryParse(Dioda1C1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1LOWnm = a;
            double.TryParse(Dioda1D1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1LOWnm = a;
            //###
            double.TryParse(Dioda1A1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1LOWTHz = a;
            double.TryParse(Dioda1B1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1LOWTHz = a;
            double.TryParse(Dioda1C1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1LOWTHz = a;
            double.TryParse(Dioda1D1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1LOWTHz = a;
            //###
            //###
            double.TryParse(Dioda1A1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1MIDcm = a;
            double.TryParse(Dioda1B1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1MIDcm = a;
            double.TryParse(Dioda1C1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1MIDcm = a;
            double.TryParse(Dioda1D1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1MIDcm = a;
            //###
            double.TryParse(Dioda1A1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1MIDnm = a;
            double.TryParse(Dioda1B1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1MIDnm = a;
            double.TryParse(Dioda1C1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1MIDnm = a;
            double.TryParse(Dioda1D1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1MIDnm = a;
            //###/
            double.TryParse(Dioda1A1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1MIDTHz = a;
            double.TryParse(Dioda1B1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1MIDTHz = a;
            double.TryParse(Dioda1C1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1MIDTHz = a;
            double.TryParse(Dioda1D1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1MIDTHz = a;
            //###
            //###
            double.TryParse(Dioda1A1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1HIGHcm = a;
            double.TryParse(Dioda1B1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1HIGHcm = a;
            double.TryParse(Dioda1C1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1HIGHcm = a;
            double.TryParse(Dioda1D1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1HIGHcm = a;
            //###
            double.TryParse(Dioda1A1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1HIGHnm = a;
            double.TryParse(Dioda1B1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1HIGHnm = a;
            double.TryParse(Dioda1C1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1HIGHnm = a;
            double.TryParse(Dioda1D1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1HIGHnm = a;
            //###
            double.TryParse(Dioda1A1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1HIGHTHz = a;
            double.TryParse(Dioda1B1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1HIGHTHz = a;
            double.TryParse(Dioda1C1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1HIGHTHz = a;
            double.TryParse(Dioda1D1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1HIGHTHz = a;
            //###
            //###
            double.TryParse(Dioda1A1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1HIGHHcm = a;
            double.TryParse(Dioda1B1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1HIGHHcm = a;
            double.TryParse(Dioda1C1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1HIGHHcm = a;
            double.TryParse(Dioda1D1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1HIGHHcm = a;
            //###
            double.TryParse(Dioda1A1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1HIGHHnm = a;
            double.TryParse(Dioda1B1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1HIGHHnm = a;
            double.TryParse(Dioda1C1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1HIGHHnm = a;
            double.TryParse(Dioda1D1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1HIGHHnm = a;
            //###
            double.TryParse(Dioda1A1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1A1HIGHHTHz = a;
            double.TryParse(Dioda1B1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1B1HIGHHTHz = a;
            double.TryParse(Dioda1C1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1C1HIGHHTHz = a;
            double.TryParse(Dioda1D1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda1D1HIGHHTHz = a;

            

            //###################################################
            //###################################################
            //###################################################
            //###################################################
            //###################################################
            //###################################################

            double.TryParse(Dioda2A1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1LOWcm = a;
            double.TryParse(Dioda2B1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1LOWcm = a;
            double.TryParse(Dioda2C1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1LOWcm = a;
            double.TryParse(Dioda2D1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1LOWcm = a;
            //###
            double.TryParse(Dioda2A1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1LOWnm = a;
            double.TryParse(Dioda2B1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1LOWnm = a;
            double.TryParse(Dioda2C1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1LOWnm = a;
            double.TryParse(Dioda2D1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1LOWnm = a;
            //###
            double.TryParse(Dioda2A1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1LOWTHz = a;
            double.TryParse(Dioda2B1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1LOWTHz = a;
            double.TryParse(Dioda2C1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1LOWTHz = a;
            double.TryParse(Dioda2D1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1LOWTHz = a;
            //###
            //###
            double.TryParse(Dioda2A1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1MIDcm = a;
            double.TryParse(Dioda2B1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1MIDcm = a;
            double.TryParse(Dioda2C1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1MIDcm = a;
            double.TryParse(Dioda2D1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1MIDcm = a;
            //###
            double.TryParse(Dioda2A1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1MIDnm = a;
            double.TryParse(Dioda2B1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1MIDnm = a;
            double.TryParse(Dioda2C1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1MIDnm = a;
            double.TryParse(Dioda2D1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1MIDnm = a;
            //###/
            double.TryParse(Dioda2A1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1MIDTHz = a;
            double.TryParse(Dioda2B1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1MIDTHz = a;
            double.TryParse(Dioda2C1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1MIDTHz = a;
            double.TryParse(Dioda2D1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1MIDTHz = a;
            //###
            //###
            double.TryParse(Dioda2A1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1HIGHcm = a;
            double.TryParse(Dioda2B1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1HIGHcm = a;
            double.TryParse(Dioda2C1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1HIGHcm = a;
            double.TryParse(Dioda2D1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1HIGHcm = a;
            //###
            double.TryParse(Dioda2A1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1HIGHnm = a;
            double.TryParse(Dioda2B1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1HIGHnm = a;
            double.TryParse(Dioda2C1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1HIGHnm = a;
            double.TryParse(Dioda2D1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1HIGHnm = a;
            //###
            double.TryParse(Dioda2A1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1HIGHTHz = a;
            double.TryParse(Dioda2B1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1HIGHTHz = a;
            double.TryParse(Dioda2C1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1HIGHTHz = a;
            double.TryParse(Dioda2D1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1HIGHTHz = a;
            //###
            //###
            double.TryParse(Dioda2A1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1HIGHHcm = a;
            double.TryParse(Dioda2B1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1HIGHHcm = a;
            double.TryParse(Dioda2C1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1HIGHHcm = a;
            double.TryParse(Dioda2D1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1HIGHHcm = a;
            //###
            double.TryParse(Dioda2A1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1HIGHHnm = a;
            double.TryParse(Dioda2B1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1HIGHHnm = a;
            double.TryParse(Dioda2C1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1HIGHHnm = a;
            double.TryParse(Dioda2D1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1HIGHHnm = a;
            //###
            double.TryParse(Dioda2A1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2A1HIGHHTHz = a;
            double.TryParse(Dioda2B1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2B1HIGHHTHz = a;
            double.TryParse(Dioda2C1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2C1HIGHHTHz = a;
            double.TryParse(Dioda2D1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda2D1HIGHHTHz = a;

            //###################################################
            //###################################################
            //###################################################
            //###################################################
            //###################################################
            //###################################################

            double.TryParse(Dioda3A1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1LOWcm = a;
            double.TryParse(Dioda3B1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1LOWcm = a;
            double.TryParse(Dioda3C1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1LOWcm = a;
            double.TryParse(Dioda3D1LOWcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1LOWcm = a;
            //###
            double.TryParse(Dioda3A1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1LOWnm = a;
            double.TryParse(Dioda3B1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1LOWnm = a;
            double.TryParse(Dioda3C1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1LOWnm = a;
            double.TryParse(Dioda3D1LOWnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1LOWnm = a;
            //###
            double.TryParse(Dioda3A1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1LOWTHz = a;
            double.TryParse(Dioda3B1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1LOWTHz = a;
            double.TryParse(Dioda3C1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1LOWTHz = a;
            double.TryParse(Dioda3D1LOWTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1LOWTHz = a;
            //###
            //###
            double.TryParse(Dioda3A1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1MIDcm = a;
            double.TryParse(Dioda3B1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1MIDcm = a;
            double.TryParse(Dioda3C1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1MIDcm = a;
            double.TryParse(Dioda3D1MIDcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1MIDcm = a;
            //###
            double.TryParse(Dioda3A1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1MIDnm = a;
            double.TryParse(Dioda3B1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1MIDnm = a;
            double.TryParse(Dioda3C1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1MIDnm = a;
            double.TryParse(Dioda3D1MIDnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1MIDnm = a;
            //###/
            double.TryParse(Dioda3A1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1MIDTHz = a;
            double.TryParse(Dioda3B1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1MIDTHz = a;
            double.TryParse(Dioda3C1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1MIDTHz = a;
            double.TryParse(Dioda3D1MIDTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1MIDTHz = a;
            //###
            //###
            double.TryParse(Dioda3A1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1HIGHcm = a;
            double.TryParse(Dioda3B1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1HIGHcm = a;
            double.TryParse(Dioda3C1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1HIGHcm = a;
            double.TryParse(Dioda3D1HIGHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1HIGHcm = a;
            //###
            double.TryParse(Dioda3A1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1HIGHnm = a;
            double.TryParse(Dioda3B1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1HIGHnm = a;
            double.TryParse(Dioda3C1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1HIGHnm = a;
            double.TryParse(Dioda3D1HIGHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1HIGHnm = a;
            //###
            double.TryParse(Dioda3A1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1HIGHTHz = a;
            double.TryParse(Dioda3B1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1HIGHTHz = a;
            double.TryParse(Dioda3C1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1HIGHTHz = a;
            double.TryParse(Dioda3D1HIGHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1HIGHTHz = a;
            //###
            //###
            double.TryParse(Dioda3A1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1HIGHHcm = a;
            double.TryParse(Dioda3B1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1HIGHHcm = a;
            double.TryParse(Dioda3C1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1HIGHHcm = a;
            double.TryParse(Dioda3D1HIGHHcm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1HIGHHcm = a;
            //###
            double.TryParse(Dioda3A1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1HIGHHnm = a;
            double.TryParse(Dioda3B1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1HIGHHnm = a;
            double.TryParse(Dioda3C1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1HIGHHnm = a;
            double.TryParse(Dioda3D1HIGHHnm.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1HIGHHnm = a;
            //###
            double.TryParse(Dioda3A1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3A1HIGHHTHz = a;
            double.TryParse(Dioda3B1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3B1HIGHHTHz = a;
            double.TryParse(Dioda3C1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3C1HIGHHTHz = a;
            double.TryParse(Dioda3D1HIGHHTHz.Text, out a);
            Laser.Properties.Settings.Default.Dioda3D1HIGHHTHz = a;

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics l = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            Pen o = new Pen(Color.Red, 2);
            //gora
            l.DrawLine(o, 20, 10, 480, 10);
            l.DrawLine(o, 20, 50, 480, 50);
            l.DrawLine(o, 20, 10, 20, 50);
            l.DrawLine(o, 480, 10, 480, 50);
            //dól
            l.DrawLine(p, 20, 60, 480, 60);
            l.DrawLine(p, 20, 115, 480, 115);
            l.DrawLine(p, 20, 170, 480, 170);
            l.DrawLine(p, 20, 225, 480, 225);
            l.DrawLine(p, 20, 280, 480, 280);
            l.DrawLine(p, 20, 60, 20, 280);
            l.DrawLine(p, 111, 60, 111, 280);
            l.DrawLine(p, 202, 60, 202, 280);
            l.DrawLine(p, 293, 60, 293, 280);
            l.DrawLine(p, 384, 60, 384, 280);
            l.DrawLine(p, 480, 60, 480, 280);
        }

        private void tabPage4_Paint(object sender, PaintEventArgs e)
        {
            Graphics l = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            Pen o = new Pen(Color.Red, 2);
            //gora
            l.DrawLine(o, 20, 10, 480, 10);
            l.DrawLine(o, 20, 50, 480, 50);
            l.DrawLine(o, 20, 10, 20, 50);
            l.DrawLine(o, 480, 10, 480, 50);
            //dól
            l.DrawLine(p, 20, 60, 480, 60);
            l.DrawLine(p, 20, 115, 480, 115);
            l.DrawLine(p, 20, 170, 480, 170);
            l.DrawLine(p, 20, 225, 480, 225);
            l.DrawLine(p, 20, 280, 480, 280);
            l.DrawLine(p, 20, 60, 20, 280);
            l.DrawLine(p, 111, 60, 111, 280);
            l.DrawLine(p, 202, 60, 202, 280);
            l.DrawLine(p, 293, 60, 293, 280);
            l.DrawLine(p, 384, 60, 384, 280);
            l.DrawLine(p, 480, 60, 480, 280);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Laser.Properties.Settings.Default.Dioda1D1HIGHcm;
            MessageBox.Show("" + a);
        }

        private void Dioda1A1LOWcm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
