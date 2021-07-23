using Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        IStudentsService Service = new StudentsService();
        public IEnumerable<Student> Students { get; set; }
        public Student SelectedStudent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            RefreshButton.IsEnabled = false;
            try
            {
                Students = await Service.ReadAsync();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Students)));
            }
            finally
            {
                RefreshButton.IsEnabled = true;
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteButton.IsEnabled = false;
            try
            {
                if (SelectedStudent == null)
                return;

                await Service.DeleteAsync(SelectedStudent.Id);
                await Refresh();
            }
            finally
            {
                DeleteButton.IsEnabled = true;
            }
        }
        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            var window = new StudentWindow(SelectedStudent);
            if(window.ShowDialog() == true)
                await Service.UpdateAsync(SelectedStudent.Id, SelectedStudent);
        }
    }
}
