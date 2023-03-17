using Avalonia.Controls;
using System;

namespace Rabid_Time_Tracker
{
    public partial class CreateOpenDBFile : Window
    {
        public enum Result
        {
            None,
            OpenLast,
            CreateNew,
            OpenExisting,
        }

        Result r = Result.None;

        public CreateOpenDBFile()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            CanResize = false;
            Closing += CreateOpenDBFile_Closing;            

            btn_create.Click += Btn_create_Click;
            btn_existing.Click += Btn_existing_Click;
            btn_last.Click += Btn_last_Click;
        }

        private void CreateOpenDBFile_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {            
            if (r == Result.None)
                e.Cancel = true;
        }

        private void Btn_create_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            r = Result.CreateNew;   
            Close(Result.CreateNew);
        }
        private void Btn_existing_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            r = Result.OpenExisting;
            Close(Result.OpenExisting);
        }

        private void Btn_last_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            r = Result.OpenLast;
            Close(Result.OpenLast);
        }
    }
}
