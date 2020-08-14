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
    /// Interaction logic for PlayerEdit.xaml
    /// </summary>
    public partial class PlayerEdit : Window
    {
        string database;
        List<Nation> nations;
        List<Section> sections;
        List<PositionType> positions;
        List<Team> teams;
        List<TeamXSection> teamxsections;
        List<Player> players;
        public PlayerEdit(string databaseName)
        {
            database = databaseName;
            players = new List<Player>();
            nations = new List<Nation>();
            sections = new List<Section>();
            positions = new List<PositionType>();
            teams = new List<Team>();
            teamxsections = new List<TeamXSection>();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AddData(0);
        }

        private void AddData(int v)
        {
            players.Clear();
            nations.Clear();
            sections.Clear();
            teams.Clear();
            PlayersList.Items.Clear();
            Nation.Items.Clear();
            Game.Items.Clear();
            Team.Items.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_player, name, surname, nick, id_nation, player.id_teamxsection, value, salary, contractEnd, individualSkill, teamplaySkill, individualPotencial, teamplayPotencial, player.id_section, id_position, id_team from player join teamxsection on player.id_teamxsection=teamxsection.id_teamxsection where id_player<700 order by nick", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    players.Add(new Player(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetString(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14), reader.GetInt32(15)));
                }
                reader.Close();
                command = new SQLiteCommand("select id_nation, name from nation", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nations.Add(new Nation(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();
                command = new SQLiteCommand("select id_section, name from section", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sections.Add(new Section(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();
                command = new SQLiteCommand("select id_team, name from team", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teams.Add(new Team(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();
            }
            for (int i = 0; i < players.Count; i++)
            {
                PlayersList.Items.Add(players.ElementAt(i).Nick);
            }
            for (int i = 0; i < nations.Count; i++)
            {
                Nation.Items.Add(nations.ElementAt(i).Name);
            }
            for (int i = 0; i < teams.Count; i++)
            {
                Team.Items.Add(teams.ElementAt(i).Name);
            }
            for (int i = 0; i < sections.Count; i++)
            {
                Game.Items.Add(sections.ElementAt(i).Name);
            }
            if (v != -1)
            {
                PlayersList.SelectedIndex = v;
            }
            else if (PlayersList.Items.Count > 0)
            {
                PlayersList.SelectedIndex = 0;
            }
        }

        private void PlayersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            positions.Clear(); 
            teamxsections.Clear(); 
            Position.Items.Clear(); 
            Section.Items.Clear();
            Name.Text = players.ElementAt(PlayersList.SelectedIndex).Name;
            Surname.Text = players.ElementAt(PlayersList.SelectedIndex).Surname;
            Nick.Text = players.ElementAt(PlayersList.SelectedIndex).Nick;
            Value.Text = players.ElementAt(PlayersList.SelectedIndex).Value.ToString();
            IndiSkill.Text = players.ElementAt(PlayersList.SelectedIndex).IndividualSkill.ToString();
            IndiPoten.Text = players.ElementAt(PlayersList.SelectedIndex).IndividualPotencial.ToString();
            TeamSkill.Text = players.ElementAt(PlayersList.SelectedIndex).TeamplaySkill.ToString();
            TeamPoten.Text = players.ElementAt(PlayersList.SelectedIndex).TeamplayPotencial.ToString();
            Salary.Text = players.ElementAt(PlayersList.SelectedIndex).Salary.ToString();
            for (int i = 0; i < nations.Count; i++)
            {
                if (nations.ElementAt(i).IdNation== players.ElementAt(PlayersList.SelectedIndex).Nation)
                {
                    Nation.SelectedIndex = i;
                }
            }
            for (int i = 0; i < sections.Count; i++)
            {
                if (sections.ElementAt(i).IdSection == players.ElementAt(PlayersList.SelectedIndex).Section)
                {
                    Game.SelectedIndex = i;
                }
            }
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams.ElementAt(i).IdTeam == players.ElementAt(PlayersList.SelectedIndex).IdTeam)
                {
                    Team.SelectedIndex = i;
                }
            }
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_position_type, name from position_type where id_section=" + players.ElementAt(PlayersList.SelectedIndex).Section + ";", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    positions.Add(new PositionType(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            for (int i = 0; i < positions.Count; i++)
            {
                Position.Items.Add(positions.ElementAt(i).Name);
                if (positions.ElementAt(i).IdPosition == players.ElementAt(PlayersList.SelectedIndex).Position)
                {
                    Position.SelectedIndex = i;
                }
            }
        }

        private void AddNewPlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdatePlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("delete from player where id_player=" + players.ElementAt(PlayersList.SelectedIndex).IdPlayer +";", conn);
                command.ExecuteReader();
            }
            AddData(0);
        }

        private void Game_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            positions.Clear();
            Position.Items.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_position_type, name from position_type where id_section=" + sections.ElementAt(Game.SelectedIndex).IdSection + ";", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    positions.Add(new PositionType(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            for (int i = 0; i < positions.Count; i++)
            {
                Position.Items.Add(positions.ElementAt(i).Name);
                if (positions.ElementAt(i).IdPosition == players.ElementAt(PlayersList.SelectedIndex).Position)
                {
                    Position.SelectedIndex = i;
                }
            }
        }


        private void Team_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Section.Items.Clear(); 
            teamxsections.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select teamxsection.id_teamxsection, section.id_section, name from section join teamxsection on teamxsection.id_section=section.id_section where id_team=" + teams.ElementAt(Team.SelectedIndex).IdTeam + " and teamxsection.id_section=" + sections.ElementAt(Game.SelectedIndex).IdSection + " order by section.id_section;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                int sectionBefore = -1;
                while (reader.Read())
                {
                    if (sectionBefore == reader.GetInt32(1))
                    {
                        //je to B tým
                        teamxsections.Add(new TeamXSection(reader.GetInt32(0), reader.GetInt32(1), "B tým"));
                    }
                    else
                    {
                        //je to A tým
                        teamxsections.Add(new TeamXSection(reader.GetInt32(0), reader.GetInt32(1), "A tým"));
                    }

                    sectionBefore = reader.GetInt32(1);
                }
                reader.Close();
            }
            for (int i = 0; i < teamxsections.Count; i++)
            {
                Section.Items.Add(teamxsections.ElementAt(i).Name);
                if (teamxsections.ElementAt(i).IdTeamXSection == players.ElementAt(PlayersList.SelectedIndex).TeamXSection)
                {
                    Section.SelectedIndex = i;
                }
            }
        }
    }
}
