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
    public partial class EditMenu : Window
    {
        string database;
        public EditMenu(string databaseName)
        {
            database = databaseName;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Coach_Click(object sender, RoutedEventArgs e)
        {
            CoachEdit win2 = new CoachEdit(database);
            win2.ShowDialog();
        }

        private void Sponsor_Click(object sender, RoutedEventArgs e)
        {
            SponsorEdit win2 = new SponsorEdit(database);
            win2.ShowDialog();
        }

        private void Team_Click(object sender, RoutedEventArgs e)
        {
            TeamEdit win2 = new TeamEdit(database);
            win2.ShowDialog();
        }

        private void Section_Click(object sender, RoutedEventArgs e)
        {
            GameEdit win2 = new GameEdit(database);
            win2.ShowDialog();
        }

        private void Player_Click(object sender, RoutedEventArgs e)
        {
            PlayerEdit win2 = new PlayerEdit(database);
            win2.ShowDialog();
        }

        private void Tournament_Click(object sender, RoutedEventArgs e)
        {
            TournamentEdit win2 = new TournamentEdit(database);
            win2.ShowDialog();
        }
    }
}
