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
        public ICollection<Student> Students { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Students = Service.Read().ToList();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Students)));
        }
    }
}
