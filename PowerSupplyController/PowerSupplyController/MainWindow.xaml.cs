using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using.System.Threading;


namespace PowerSupplyController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {


        int clickcount1;
        int clickcount2;

        System.IO.Ports.SerialPort PSport = new System.IO.Ports.SerialPort();





        public MainWindow()
        {
            InitializeComponent();
        }

        private void OutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(clickcount2 == 1))
            {
                clickcount2++;
            }
            else
            {
                clickcount2 = 0;
            }

            switch (clickcount2)
            {
                case 0:
                    try
                    {


                        PSport.Write("OUT0");
                        Thread.Sleep(10);

                    }
                    catch
                    {

                    }

                    break;
            }
        }

        private void CntBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(clickcount1 == 1))
            {
                clickcount1++;
            }
            else
            {
                clickcount1 = 0;
            }

            switch (clickcount1)
            {
                case 1:
                    OutBtn.IsEnabled = true;
                    Voltslider.IsEnabled = true;

                    string pn = PortBox.SelectedValue.ToString();
                    PSport.PortName = pn;
                    try
                    {
                        if (PSport.IsOpen == false)
                        {
                            PSport.Open();
                        }
                    }
                    catch
            }
        }

        private void Voltslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
                double vout = (Voltslider.Value);
                vout = Math.Round(vout, 2);
                VoltLabel.Content = vout + " V";
                try
                {
                    PSport.Write\("VSET1:" + vout);
                }
                catch
                {

                }
                ThreadStaticAttribute.Sleep(100);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OutBtn.IsEnabled = false;
            Voltslider.IsEnabled = false;
        }
    }
}
