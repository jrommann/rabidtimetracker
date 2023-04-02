using Avalonia.Controls;
using System;

namespace Rabid_Time_Tracker
{
    public partial class Window_Projects : Window
    {
        Project _current = null;

        public Window_Projects()
        {
            InitializeComponent();

            projectList.SelectionChanged += ProjectList_SelectionChanged;
            LoadProjects();
        }

        private void ProjectList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            _current = projectList.SelectedItem as Project;
            projectName.Text = _current?.Name;
            projectDescription.Text = _current?.Description;
        }

        private void Btn_new_Clicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _current = new Project()
            {
                Name = projectName.Text,
                Description = projectDescription.Text,
                Started = DateTime.Now,
            };
            DatabaseManager.Instance.Insert(_current);
            LoadProjects();
        }
        private void Btn_update_Clicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _current.Name = projectName.Text;
            _current.Description = projectDescription.Text;
            DatabaseManager.Instance.Update(_current);
            LoadProjects();
        }
        private void Btn_delete_Clicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DatabaseManager.Instance.Delete(_current);
            _current = null;
            projectName.Text = "";
            projectDescription.Text = "";
            LoadProjects();
        }

        void LoadProjects()
        {
            projectList.Items = DatabaseManager.Instance.Projects_GetAll();
        }
    }
}
