using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace ProgramEdit
{
    /// <summary>
    /// Interaction logic for TeamEdit.xaml
    /// </summary>
    public partial class TeamEdit : Window
    {
        string database;
        string comText1 = "";
        string comText2;
        List<Team> teams;
        List<City> cities;
        public TeamEdit(string databaseName)
        {
            database = databaseName;
            teams = new List<Team>();
            cities = new List<City>();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AddData(0);
        }

        private void AddData(int v)
        {
            teams.Clear();
            cities.Clear();
            City.Items.Clear();
            TeamsList.Items.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_team, name, shortcut, id_city, budget, reputation from team order by name collate nocase;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teams.Add(new Team(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)));
                }
                reader.Close();
                command = new SQLiteCommand("select id_city, name from city", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cities.Add(new City(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();
            }
            for (int i = 0; i < teams.Count; i++)
            {
                TeamsList.Items.Add(teams.ElementAt(i).Name);
            }
            for (int i = 0; i < cities.Count; i++)
            {
                City.Items.Add(cities.ElementAt(i).Name);
            }
            if (v != -1)
            {
                TeamsList.SelectedIndex = v;
            }
            else if (TeamsList.Items.Count > 0)
            {
                TeamsList.SelectedIndex = 0;
            }
            
        }

        private void TeamsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamsList.SelectedIndex > -1)
            {
                Name.Text = teams.ElementAt(TeamsList.SelectedIndex).Name;
                Shortcut.Text = teams.ElementAt(TeamsList.SelectedIndex).Shortcut;
                Budget.Text = teams.ElementAt(TeamsList.SelectedIndex).Budget.ToString();
                Reputation.Text = teams.ElementAt(TeamsList.SelectedIndex).Reputation.ToString();
                for (int i = 0; i < cities.Count; i++)
                {
                    if (cities.ElementAt(i).IdCity == teams.ElementAt(TeamsList.SelectedIndex).IdCity)
                    {
                        City.SelectedIndex = i;
                    }
                }
            }
        }

        private void UpdateTeam_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("update team set name='" + Name.Text + "', shortcut='" + Shortcut.Text + "', id_city=" + cities.ElementAt(City.SelectedIndex).IdCity + ", budget=" + Budget.Text +", reputation=" + Reputation.Text +" where id_team=" + teams.ElementAt(TeamsList.SelectedIndex).IdTeam + ";", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("select last_insert_rowid()", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32(0);
                reader.Close();
                if (comText1 != "")
                {
                    command = new SQLiteCommand(comText1 + teams.ElementAt(TeamsList.SelectedIndex).IdTeam + comText2, conn);
                    command.ExecuteReader();
                }

            }
            AddData(TeamsList.SelectedIndex);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNewTeam_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("insert into team (name, shortcut, id_city, budget, reputation) values ('" + Name.Text + "', '" + Shortcut.Text + "', " + cities.ElementAt(City.SelectedIndex).IdCity + "," + Budget.Text + "," + Reputation.Text + ");", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("select last_insert_rowid()", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32(0);
                reader.Close();
                if (comText1 != "")
                {
                    command = new SQLiteCommand(comText1 + id + comText2, conn);
                    command.ExecuteReader();
                }
                
            }
            AddData(TeamsList.SelectedIndex);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select count(*) from tournament_token join teamxsection on teamxsection.id_teamxsection=tournament_token.id_teamxsection where teamxsection.id_team=" + teams.ElementAt(TeamsList.SelectedIndex).IdTeam + ";", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                int num = reader.GetInt32(0);
                reader.Close();
                if (num > 0)
                {
                    MessageBox.Show("Tento tým nelze odstranit. Je nominován nejméně do jednoho turnaje", "Chyba", MessageBoxButton.OK);
                    return;
                } else
                {
                    command = new SQLiteCommand("select id_teamxsection from teamxsection where id_team=" + teams.ElementAt(TeamsList.SelectedIndex).IdTeam + ";", conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        command = new SQLiteCommand("update player set id_teamxsection=NULL where id_teamxsection=" + reader.GetInt32(0) + ";", conn); ;
                        command.ExecuteReader();
                    }
                    command = new SQLiteCommand("delete from teamxsection where id_team=" + teams.ElementAt(TeamsList.SelectedIndex).IdTeam + ";", conn);
                    command.ExecuteReader();
                    command = new SQLiteCommand("delete from team where id_team=" + teams.ElementAt(TeamsList.SelectedIndex).IdTeam + ";", conn);
                    command.ExecuteReader();
                }
            }
            AddData(0);
        }

        private void AddSections_Click(object sender, RoutedEventArgs e)
        {
            AddSection win2 = new AddSection(database, teams.ElementAt(TeamsList.SelectedIndex).IdTeam, teams.ElementAt(TeamsList.SelectedIndex).IdCity);
            win2.ShowDialog();
            comText1 = win2.com1;
            comText2 = win2.com2;
        }
    }
}
