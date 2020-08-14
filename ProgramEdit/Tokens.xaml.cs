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
    /// Interaction logic for Tokens.xaml
    /// </summary>
    public partial class Tokens : Window
    {
        List<TeamXSection> sectionsList;
        string databaseName;
        int tournamentID;
        public Tokens(string database, int tourID, int teams)
        {
            tournamentID = tourID;
            sectionsList = new List<TeamXSection>();
            databaseName = database;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SetComponents(teams);
            AddTeams();
            SetValues();
        }

        private void SetComponents(int numOfTeams)
        {
            if (numOfTeams < 20)
            {
                Token20.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 19)
            {
                Token19.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 18)
            {
                Token18.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 17)
            {
                Token17.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 16)
            {
                Token16.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 15)
            {
                Token15.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 14)
            {
                Token14.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 13)
            {
                Token13.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 12)
            {
                Token12.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 11)
            {
                Token11.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 10)
            {
                Token10.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 9)
            {
                Token9.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 8)
            {
                Token8.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 7)
            {
                Token7.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 6)
            {
                Token6.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 5)
            {
                Token5.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 4)
            {
                Token4.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 3)
            {
                Token3.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 2)
            {
                Token2.Visibility = Visibility.Hidden;
            }
            if (numOfTeams < 1)
            {
                Token1.Visibility = Visibility.Hidden;
            }
        }

        private void SetValues()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select teamxsection.id_teamxsection, section.id_section, team.name, team.id_team from section join teamxsection on teamxsection.id_section=section.id_section join team on team.id_team=teamxsection.id_team where teamxsection.id_section=" + 1 + " order by team.id_team;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
            }
        }

        private void AddTeams()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + databaseName + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select teamxsection.id_teamxsection, section.id_section, team.name, team.id_team from section join teamxsection on teamxsection.id_section=section.id_section join team on team.id_team=teamxsection.id_team where teamxsection.id_section=" + 1 + " order by team.id_team;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                int teamBefore = -1;
                while (reader.Read())
                {
                    if (teamBefore == reader.GetInt32(3))
                    {
                        //je to B tým
                        sectionsList.Add(new TeamXSection(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2) + " B"));
                    }
                    else
                    {
                        //je to A tým
                        sectionsList.Add(new TeamXSection(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
                    }

                    teamBefore = reader.GetInt32(3);
                }
                reader.Close();
            }
            if (sectionsList.Count > 0)
            {
                for (int i = 0; i < sectionsList.Count; i++)
                {
                    Token1.Items.Add(sectionsList.ElementAt(i).Name);
                    Token2.Items.Add(sectionsList.ElementAt(i).Name);
                    Token3.Items.Add(sectionsList.ElementAt(i).Name);
                    Token4.Items.Add(sectionsList.ElementAt(i).Name);
                    Token5.Items.Add(sectionsList.ElementAt(i).Name);
                    Token6.Items.Add(sectionsList.ElementAt(i).Name);
                    Token7.Items.Add(sectionsList.ElementAt(i).Name);
                    Token8.Items.Add(sectionsList.ElementAt(i).Name);
                    Token9.Items.Add(sectionsList.ElementAt(i).Name);
                    Token10.Items.Add(sectionsList.ElementAt(i).Name);
                    Token11.Items.Add(sectionsList.ElementAt(i).Name);
                    Token12.Items.Add(sectionsList.ElementAt(i).Name);
                    Token13.Items.Add(sectionsList.ElementAt(i).Name);
                    Token14.Items.Add(sectionsList.ElementAt(i).Name);
                    Token15.Items.Add(sectionsList.ElementAt(i).Name);
                    Token16.Items.Add(sectionsList.ElementAt(i).Name);
                    Token17.Items.Add(sectionsList.ElementAt(i).Name);
                    Token18.Items.Add(sectionsList.ElementAt(i).Name);
                    Token19.Items.Add(sectionsList.ElementAt(i).Name);
                    Token20.Items.Add(sectionsList.ElementAt(i).Name);
                }
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
