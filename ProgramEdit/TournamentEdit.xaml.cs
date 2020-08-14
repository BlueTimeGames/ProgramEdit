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
    /// Interaction logic for TournamentEdit.xaml
    /// </summary>
    public partial class TournamentEdit : Window
    {
        List<Tournament> tournaments;
        List<Section> sections;
        List<City> cities;
        string database;
        public TournamentEdit(string databaseName)
        {
            tournaments = new List<Tournament>();
            sections = new List<Section>();
            cities = new List<City>();
            database = databaseName;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Sys.Items.Add("Single round robin");
            Sys.Items.Add("Double round robin");
            Sys.Items.Add("Single elimination");
            Sys.Items.Add("King of the hill");
            Sys.Items.Add("Triple round robin");
            PPDividing.Items.Add("Žádný prize pool");
            PPDividing.Items.Add("Rovnoměrně");
            PPDividing.Items.Add("Padající déšť");
            AddData(0);
        }

        private void AddData(int v)
        {
            tournaments.Clear();
            cities.Clear();
            sections.Clear();
            TournamentsList.Items.Clear();
            City.Items.Clear();
            Section.Items.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_tournament, tournament.name, tournament.shortcut, n_of_teams, system, start_date, end_date, playing_days, prize_pool, pp_teams, pp_dividing, tournament.id_city, city.name, token_value, tournament.id_section, section.name, games_best_of, open_reg from tournament join city on tournament.id_city=city.id_city join section on tournament.id_section=section.id_section where playing_days is not null", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tournaments.Add(new Tournament(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), new City(reader.GetInt32(11), reader.GetString(12)), reader.GetInt32(13), new Section(reader.GetInt32(14), reader.GetString(15)), reader.GetInt32(16), reader.GetInt32(17)==1));
                }
                reader.Close();
                command = new SQLiteCommand("select id_section, name from section", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sections.Add(new Section(reader.GetInt32(0), reader.GetString(1)));
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
            for (int i = 0; i < tournaments.Count; i++)
            {
                TournamentsList.Items.Add(tournaments.ElementAt(i).Name);
            }
            for (int i = 0; i < cities.Count; i++)
            {
                City.Items.Add(cities.ElementAt(i).Name);
            }
            for (int i = 0; i < sections.Count; i++)
            {
                Section.Items.Add(sections.ElementAt(i).Name);
            }
            if (v != -1)
            {
                TournamentsList.SelectedIndex = v;
            }
            else if (TournamentsList.Items.Count > 0)
            {
                TournamentsList.SelectedIndex = 0;
            }
        }

        private void TournamentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TournamentsList.SelectedIndex > -1)
            {
                Name.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).Name;
                Shortcut.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).Shortcut;
                Sys.SelectedIndex = tournaments.ElementAt(TournamentsList.SelectedIndex).System - 1;
                StartDate.SelectedDate = new DateTime(int.Parse(tournaments.ElementAt(TournamentsList.SelectedIndex).StartDate.Substring(0, 4)), int.Parse(tournaments.ElementAt(TournamentsList.SelectedIndex).StartDate.Substring(5, 2)), int.Parse(tournaments.ElementAt(TournamentsList.SelectedIndex).StartDate.Substring(8, 2)));
                EndDate.SelectedDate = new DateTime(int.Parse(tournaments.ElementAt(TournamentsList.SelectedIndex).EndDate.Substring(0, 4)), int.Parse(tournaments.ElementAt(TournamentsList.SelectedIndex).EndDate.Substring(5, 2)), int.Parse(tournaments.ElementAt(TournamentsList.SelectedIndex).EndDate.Substring(8, 2)));
                Mo.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).PlayingDays.Substring(0,1);
                Tu.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).PlayingDays.Substring(1, 1);
                We.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).PlayingDays.Substring(2, 1);
                Th.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).PlayingDays.Substring(3, 1);
                Fr.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).PlayingDays.Substring(4, 1);
                Sa.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).PlayingDays.Substring(5, 1);
                Su.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).PlayingDays.Substring(6, 1);
                NumOfTeams.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).NumOfTeams.ToString();
                PrizePool.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).PrizePool.ToString();
                PPTeams.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).PPTeams.ToString();
                PPDividing.SelectedIndex = tournaments.ElementAt(TournamentsList.SelectedIndex).PPDividing;
                TokenValue.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).TokenValue.ToString();
                BestOf.Text = tournaments.ElementAt(TournamentsList.SelectedIndex).BestOf.ToString();
                for (int i = 0; i < sections.Count; i++)
                {
                    if (sections.ElementAt(i).IdSection == tournaments.ElementAt(TournamentsList.SelectedIndex).Section.IdSection)
                    {
                        Section.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < cities.Count; i++)
                {
                    if (cities.ElementAt(i).IdCity == tournaments.ElementAt(TournamentsList.SelectedIndex).City.IdCity)
                    {
                        City.SelectedIndex = i;
                    }
                }
                Saved.Visibility = Visibility.Hidden;
            }
        }

        private void AddNewTournament_Click(object sender, RoutedEventArgs e)
        {
            string dayString = StartDate.SelectedDate.Value.Day.ToString();
            if (dayString.Length == 1)
            {
                dayString = "0" + dayString;
            }
            string monthString = StartDate.SelectedDate.Value.Month.ToString();
            if (monthString.Length == 1)
            {
                monthString = "0" + monthString;
            }
            string start = StartDate.SelectedDate.Value.Year + "-" + monthString + "-" + dayString;
            dayString = EndDate.SelectedDate.Value.Day.ToString();
            if (dayString.Length == 1)
            {
                dayString = "0" + dayString;
            }
            monthString = EndDate.SelectedDate.Value.Month.ToString();
            if (monthString.Length == 1)
            {
                monthString = "0" + monthString;
            }
            string end = EndDate.SelectedDate.Value.Year + "-" + monthString + "-" + dayString;
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("insert into tournament (name, shortcut, n_of_teams, system, start_date, end_date, playing_days, prize_pool, pp_teams, pp_dividing, id_city, token_value, id_section, drawn, games_best_of, open_reg) values ('" + Name.Text + "', '" + Shortcut.Text + "', " + NumOfTeams.Text + "," + (Sys.SelectedIndex + 1) +",'" + start + "', '" + end + "','" + Mo.Text + Tu.Text + We.Text + Th.Text + Fr.Text + Sa.Text + Su.Text + "'," + PrizePool.Text + "," + PPTeams.Text + "," + PPDividing.SelectedIndex + "," + cities.ElementAt(City.SelectedIndex).IdCity + "," + TokenValue.Text + "," + sections.ElementAt(Section.SelectedIndex).IdSection + ", 0, " + BestOf.Text + ", 1);", conn);
                command.ExecuteReader();
            }
            AddData(TournamentsList.SelectedIndex);
        }

        private void UpdateTournament_Click(object sender, RoutedEventArgs e)
        {
            string dayString = StartDate.SelectedDate.Value.Day.ToString();
            if (dayString.Length == 1)
            {
                dayString = "0" + dayString;
            }
            string monthString = StartDate.SelectedDate.Value.Month.ToString();
            if (monthString.Length == 1)
            {
                monthString = "0" + monthString;
            }
            string start = StartDate.SelectedDate.Value.Year + "-" + monthString + "-" + dayString;
            dayString = EndDate.SelectedDate.Value.Day.ToString();
            if (dayString.Length == 1)
            {
                dayString = "0" + dayString;
            }
            monthString = EndDate.SelectedDate.Value.Month.ToString();
            if (monthString.Length == 1)
            {
                monthString = "0" + monthString;
            }
            string end = EndDate.SelectedDate.Value.Year + "-" + monthString + "-" + dayString;
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("update tournament set name='" + Name.Text + "',shortcut='" + Shortcut.Text + "',n_of_teams=" + NumOfTeams.Text + ",system=" + (Sys.SelectedIndex + 1) + ", start_date='" + start + "', end_date='" + end + "', playing_days='" + Mo.Text + Tu.Text + We.Text + Th.Text + Fr.Text + Sa.Text + Su.Text + "', prize_pool=" + PrizePool.Text + ", pp_teams=" + PPTeams.Text + ", pp_dividing=" + PPDividing.SelectedIndex + ", id_city=" + cities.ElementAt(City.SelectedIndex).IdCity + ", token_value=" + TokenValue.Text + ", id_section=" + sections.ElementAt(Section.SelectedIndex).IdSection + ", drawn=0, games_best_of=" + BestOf.Text + " where id_tournament= " + tournaments.ElementAt(TournamentsList.SelectedIndex).IdTournament + "; ", conn);
                command.ExecuteReader();
            }
            AddData(TournamentsList.SelectedIndex);
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
                SQLiteCommand command = new SQLiteCommand("delete from tournament_token where id_tournament_from=" + tournaments.ElementAt(TournamentsList.SelectedIndex).IdTournament + " or id_tournament_to=" + tournaments.ElementAt(TournamentsList.SelectedIndex).IdTournament + ";", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("delete from tournament where id_tournament=" + tournaments.ElementAt(TournamentsList.SelectedIndex).IdTournament + ";", conn);
                command.ExecuteReader();
            }
            AddData(0);
        }

        private void AddTokens_Click(object sender, RoutedEventArgs e)
        {
            Tokens win2 = new Tokens(database,tournaments.ElementAt(TournamentsList.SelectedIndex).IdTournament, int.Parse(NumOfTeams.Text));
            win2.ShowDialog();
        }
    }
}
