using Avalonia.Controls;
using System;

namespace Rabid_Time_Tracker
{
    public partial class Window_Projects : Window
    {
        public Window_Projects()
        {
            InitializeComponent();
        }

        private void Btn_new_Clicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DatabaseManager.Instance.Insert(new Project()
            {
                Name = projectName.Text,
                Description = projectDescription.Text,
                Started = DateTime.Now,
            });
            LoadProjects();
        }
        private void Btn_update_Clicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
        private void Btn_delete_Clicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }

        void LoadProjects()
        {
            projectList.Items = DatabaseManager.Instance.Projects_GetAll();
        }
    }
}
