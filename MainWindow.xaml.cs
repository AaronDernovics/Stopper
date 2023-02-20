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
using System.Timers;
using System.Threading;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int number = 0;
        public int ?numberzero = 0;

        public int second = 0;
        public int? secondzero = 0;

        public int minute =0;
        public int? minutezero = 0;

        public int hour = 0;
        public int? hourzero = 0;

        public  System.Timers.Timer? aTimer;

        public MainWindow()
        {
            InitializeComponent();
          

        }

        private void ButtonStart(object sender, RoutedEventArgs e)
        {
            
             if(aTimer == null) 
            { 

            Thread thread = new Thread(SetTimer);

            thread.Start();
                btnAdd.Content = "őő";
            }
             else
            {
                aTimer.Stop();
                aTimer = null;
                btnAdd.Content = "u";
            }
  
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
                aTimer= null;
                btnAdd.Content = "u";
            }
            number = 0;
            second = 0;
            minute = 0;

            Stoppertxt.Text = "00:00:00.00";
        }

        public void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(10);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

        }


        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            number++;

            numberzero = number > 9 ? null : 0;

            secondzero = second > 9 ? null : 0;

            minutezero = minute > 9 ? null : 0; 
            
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
               
                    Stoppertxt.Text = $"{hourzero}{hour}:{minutezero}{minute}:{secondzero}{second}.{numberzero}{number}";
                
               if (number >= 99)
               {
                    number = 0;
                    second++;
               }
               if(second >59)
                {
                    minute++;
                    second = 0;
                }

            }));

        }

        private void Stoppertxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}









