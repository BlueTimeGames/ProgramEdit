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
    /// Interaction logic for SponsorEdit.xaml
    /// </summary>
    public partial class SponsorEdit : Window
    {
        List<Sponsor> sponsors;
        string database;
        public SponsorEdit(string databaseName)
        {
            database = databaseName;
            sponsors = new List<Sponsor>();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AddData(0);
        }

        private void AddData(int v)
        {
            sponsors.Clear();
            SponsorsList.Items.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("select id_sponsor, name, monthly_payment, renew_bonus, min_team_strength, success_payment from sponsor;", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int success = (int)(reader.GetFloat(5) * 100);
                    sponsors.Add(new Sponsor(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), success));
                }
                reader.Close();
            }
            for (int i = 0; i < sponsors.Count; i++)
            {
                SponsorsList.Items.Add(sponsors.ElementAt(i).Name);
            }
            if (v != -1)
            {
                SponsorsList.SelectedIndex = v;
            }
            else if (SponsorsList.Items.Count > 0)
            {
                SponsorsList.SelectedIndex = 0;
            }
        }

        private void SponsorsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SponsorsList.SelectedIndex > -1)
            {
                Name.Text = sponsors.ElementAt(SponsorsList.SelectedIndex).Name;
                MonthlyPayment.Text = sponsors.ElementAt(SponsorsList.SelectedIndex).MonthlyPayment.ToString();
                RenewBonus.Text = sponsors.ElementAt(SponsorsList.SelectedIndex).RenewBonus.ToString();
                MinReputation.Text = sponsors.ElementAt(SponsorsList.SelectedIndex).MinTeamStrength.ToString();
                SuccessPayment.Text = sponsors.ElementAt(SponsorsList.SelectedIndex).SuccessPayment.ToString();
                Saved.Visibility = Visibility.Hidden;
            }
        }

        private void UpdateSponsor_Click(object sender, RoutedEventArgs e)
        {
            double success = double.Parse(SuccessPayment.Text) / 100;
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("update sponsor set name='" + Name.Text + "',monthly_payment=" + MonthlyPayment.Text + ",renew_bonus=" + RenewBonus.Text + ",min_team_strength=" + MinReputation.Text + ", success_payment=" + success.ToString().Replace(',','.') + " where id_sponsor= " + sponsors.ElementAt(SponsorsList.SelectedIndex).IdSponsor + "; ", conn);
                command.ExecuteReader();
            }
            Saved.Visibility = Visibility.Visible;
            AddData(SponsorsList.SelectedIndex);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("delete from sponsor where id_sponsor=" + sponsors.ElementAt(SponsorsList.SelectedIndex).IdSponsor + ";", conn);
                command.ExecuteReader();
            }
            Saved.Visibility = Visibility.Visible;
            AddData(0);
        }

        private void AddNewSponsor_Click(object sender, RoutedEventArgs e)
        {
            double success = int.Parse(SuccessPayment.Text) / 100;
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\" + database + ";"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("insert into sponsor (name,monthly_payment,renew_bonus,min_team_strength,success_payment) values ('" + Name.Text + "'," + MonthlyPayment.Text + "," + RenewBonus.Text + "," + MinReputation.Text + "," + success + ");", conn);
                command.ExecuteReader();
            }
            Saved.Visibility = Visibility.Visible;
            AddData(SponsorsList.SelectedIndex);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
