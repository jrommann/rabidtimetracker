using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System;
using System.Timers;

namespace Rabid_Time_Tracker
{
    public partial class MainWindow : Window
    {
        bool _clockRunning = false;
        Session _currentSesssion;
        Timer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _currentSesssion = new Session(DateTime.Now);            

            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
        }

        #region -> first page
        public void OnStartTrackingClicked(object sender, RoutedEventArgs e)
        {
            grid_project.IsVisible = false;
            grid_Tracking.IsVisible = true;

            OnStartStopClicked(sender, e);
        }
        #endregion

        #region -> second page / timer       

        void UpdateLbls()
        {
            Dispatcher.UIThread.InvokeAsync(new Action(() =>
            {
                lbl_currentSession.Text = TimeSpan.FromSeconds(_currentSesssion.Seconds).ToString("c");
                lbl_currentTimer.Text = TimeSpan.FromSeconds(_currentSesssion.CurrentPeriod.Seconds).ToString("c");
            }));
        }

        private void _timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            _currentSesssion.AddSecond();

            UpdateLbls();            
        }

        public void OnStartStopClicked(object sender, RoutedEventArgs e)
        {
            _clockRunning = !_clockRunning;
            if (_clockRunning)
            {
                btn_start_stop.Content = "Stop";
                _timer.Start();
                lbl_note.Text = textbox_note.Text;

                //create new period                
                _currentSesssion.AddPeriod(0, lbl_note.Text);
            }
            else
            {
                btn_start_stop.Content = "Start";
                grid_project.IsVisible = true;
                grid_Tracking.IsVisible = false;
                _timer.Stop();
            }

            UpdateLbls();
        }
        #endregion
    }
}
