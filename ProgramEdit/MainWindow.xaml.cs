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

namespace ProgramEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoadDatabases();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditMenu win2 = new EditMenu("../../../../EsportManager/EsportManager/bin/Debug/" + Databases.SelectedItem.ToString() + ".cem");
            this.Close();
            win2.ShowDialog();
        }

        private void LoadDatabases()
        {
            string[] files = System.IO.Directory.GetFiles("../../../../EsportManager/EsportManager/bin/Debug", "*.cem");
            for (int i = 0; i < files.Length; i++)
            {
                Databases.Items.Add((files[i].Remove(files[i].Length - 4)).Substring(50));
            }
        }
    }
}
