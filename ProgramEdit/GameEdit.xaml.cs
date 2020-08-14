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
    /// Interaction logic for GameEdit.xaml
    /// </summary>
    public partial class GameEdit : Window
    {
        List<Section> sections;
        string database;
        public GameEdit(string databaseName)
        {
            database = databaseName;
            sections = new List<Section>();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AddData(0);
        }

        private void AddData(int v)
        {
            sections.Clear();
            GamesList.Items.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_section, name, shortcut, position_required, n_o_players from section;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Section s = new Section(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3) == 1, reader.GetInt32(4));
                    SQLiteCommand command2 = new SQLiteCommand("select id_position_type, name from position_type where id_section=" + reader.GetInt32(0) + " order by id_position_in_game;", conn);
                    SQLiteDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        s.Positions.Add(new PositionType(reader2.GetInt32(0), reader2.GetString(1)));
                    }
                    sections.Add(s);
                }
                reader.Close();
            }
            for (int i = 0; i < sections.Count; i++)
            {
                GamesList.Items.Add(sections.ElementAt(i).Name);
            }
            if (v != -1)
            {
                GamesList.SelectedIndex = v;
            }
            else if (GamesList.Items.Count > 0)
            {
                GamesList.SelectedIndex = 0;
            }
        }

        private void GamesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Positions.Text = "";
            
            if (GamesList.SelectedIndex > -1)
            {
                Positions.MaxLines = sections.ElementAt(GamesList.SelectedIndex).NumOfPlayers - 1;
                Name.Text = sections.ElementAt(GamesList.SelectedIndex).Name;
                Shortcut.Text = sections.ElementAt(GamesList.SelectedIndex).Shortcut;
                PositionRequired.IsChecked = sections.ElementAt(GamesList.SelectedIndex).PositionRequired;
                NumOfPlayers.Text = sections.ElementAt(GamesList.SelectedIndex).NumOfPlayers.ToString();
                for (int i = 0; i < sections.ElementAt(GamesList.SelectedIndex).Positions.Count; i++)
                {
                    Positions.Text += sections.ElementAt(GamesList.SelectedIndex).Positions.ElementAt(i).Name + '\n';
                }
                Saved.Visibility = Visibility.Hidden;
            }
            
        }

        private void UpdateGame_Click(object sender, RoutedEventArgs e)
        {
            int required = 0;
            if (PositionRequired.IsChecked.Value)
            {
                required = 1;
            }
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("update section set name='" + Name.Text + "',shortcut='" + Shortcut.Text + "',position_required=" + required + ",n_o_players=" + NumOfPlayers.Text + " where id_section= " + sections.ElementAt(GamesList.SelectedIndex).IdSection + "; ", conn);
                command.ExecuteReader();
                for (int i = 0; i < Positions.LineCount; i++)
                {
                    command = new SQLiteCommand("update position_type set name='" + Positions.GetLineText(i).Trim() + "' where id_section=" + sections.ElementAt(GamesList.SelectedIndex).IdSection + " and id_position_in_game=" + (i+1) + ";", conn);
                    command.ExecuteReader();
                }
            }
            Saved.Visibility = Visibility.Visible;
            AddData(GamesList.SelectedIndex);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("delete from position_type where id_section=" + sections.ElementAt(GamesList.SelectedIndex).IdSection + ";", conn);
                command.ExecuteReader(); 
                command = new SQLiteCommand("delete from coach where id_section=" + sections.ElementAt(GamesList.SelectedIndex).IdSection + ";", conn);
                command.ExecuteReader(); 
                command = new SQLiteCommand("delete from player where id_section=" + sections.ElementAt(GamesList.SelectedIndex).IdSection + ";", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("select id_tournament from tournament where id_section=" + sections.ElementAt(GamesList.SelectedIndex).IdSection + ";", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    command = new SQLiteCommand("delete from tournament_token where id_tournament_from=" + reader.GetInt32(0) + " or id_tournament_to=" + reader.GetInt32(0) + ";", conn);
                    command.ExecuteReader();
                }
                reader.Close();
                command = new SQLiteCommand("delete from tournament where id_section=" + sections.ElementAt(GamesList.SelectedIndex).IdSection + ";", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("delete from teamxsection where id_section=" + sections.ElementAt(GamesList.SelectedIndex).IdSection + ";", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("delete from section where id_section=" + sections.ElementAt(GamesList.SelectedIndex).IdSection + ";", conn);
                command.ExecuteReader();
            }
            Saved.Visibility = Visibility.Visible;
            AddData(0);
        }

        private void AddNewGame_Click(object sender, RoutedEventArgs e)
        {
            int required = 0;
            if (PositionRequired.IsChecked.Value)
            {
                required = 1;
            }
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("insert into section (name,shortcut,position_required,match_types,n_o_players) values ('" + Name.Text + "','" + Shortcut.Text + "'," + required + ",1," + NumOfPlayers.Text + ");", conn);
                command.ExecuteReader();
                command = new SQLiteCommand("select last_insert_rowid()",conn);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                for (int i = 0; i < Positions.LineCount; i++)
                {
                    command = new SQLiteCommand("insert into position_type (id_section,name,id_position_in_game) values (" + reader.GetInt32(0) + ",'" + Positions.GetLineText(i).Trim() + "'," + (i+1) + ");", conn);
                    command.ExecuteReader();
                }
                reader.Close();
            }
            Saved.Visibility = Visibility.Visible;
            AddData(GamesList.SelectedIndex);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
