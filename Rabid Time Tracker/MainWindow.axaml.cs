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
        TimeSpan _currentSesssion;
        TimeSpan _currentTimer;
        Timer _timer;

        public MainWindow()
        {
            InitializeComponent();

            btn_pause_resume.IsEnabled = _clockRunning;
            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
        }

        void ToggleTimer(bool paused)
        {
            if (_clockRunning)
            {
                if (!paused)
                    _currentTimer = TimeSpan.Zero;
                
                _timer.Start();                
                UpdateLbls();
            }
            else
            {
                _timer.Stop();
            }
        }

        void UpdateLbls()
        {
            Dispatcher.UIThread.InvokeAsync(new Action(() =>
            {
                lbl_currentSession.Text = _currentSesssion.ToString("c");
                lbl_currentTimer.Text = _currentTimer.ToString("c");
            }));
        }

        private void _timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            _currentSesssion = _currentSesssion.Add(new TimeSpan(0, 0, 1));
            _currentTimer = _currentTimer.Add(new TimeSpan(0, 0, 1));

            UpdateLbls();            
        }

        public void OnStartStopClicked(object sender, RoutedEventArgs e)
        {
            _clockRunning = !_clockRunning;
            if (_clockRunning)
                btn_start_stop.Content = "Stop";
            else
                btn_start_stop.Content = "Start";

            btn_pause_resume.IsEnabled = _clockRunning;
            ToggleTimer(false);            
        }

        public void OnPauseResumeClicked(object sender, RoutedEventArgs e)
        {
            _clockRunning = !_clockRunning;
            if (_clockRunning)
                btn_pause_resume.Content = "Pause";
            else
                btn_pause_resume.Content = "Resume";

            ToggleTimer(true);
        }
    }
}
