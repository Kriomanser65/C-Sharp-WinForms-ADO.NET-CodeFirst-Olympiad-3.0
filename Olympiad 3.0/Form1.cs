using Olympiad_3._0.Classes;
using Olympiad_3._0.ContextClases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Olympiad_3._0
{
    public partial class Form1 : Form
    {
        private OlympicContext db = new OlympicContext();
        List<string> entities = new List<string>()
        {
            "Athlete", "Country", "CountryMedalStanding", "Medal", "OlympicGame", "Sport"
        };
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = entities;
            comboBox1.DisplayMember = "Value";
            FormBorderStyle = FormBorderStyle.FixedSingle; /*dont resize Form1 Olympiad Program 2.0 */
        }
        private void PopulateDataGridView(string tableName)
        {
            if (tableName == "Athlete")
            {
                dataGridView1.DataSource = db.Athletes.ToList();
            }
            else if (tableName == "Country")
            {
                dataGridView1.DataSource = db.Countries.ToList();
            }
            else if (tableName == "Medal")
            {
                dataGridView1.DataSource = db.Medals.ToList();
            }
            else if (tableName == "OlympicGame")
            {
                dataGridView1.DataSource = db.OlympicGames.ToList();
            }
            else if (tableName == "Sport")
            {
                dataGridView1.DataSource = db.Sports.ToList();
            }
        }
        private void UpdateDataGrid()
        {
            string selectedEntity = comboBox1.SelectedItem.ToString();
            if (selectedEntity == "Country")
            {
                dataGridView1.DataSource = db.Countries.ToList();
            }
            else if (selectedEntity == "Athlete")
            {
                dataGridView1.DataSource = db.Athletes.ToList();
            }
            else if (selectedEntity == "OlympicGame")
            {
                dataGridView1.DataSource = db.OlympicGames.ToList();
            }
            else if (selectedEntity == "Medal")
            {
                dataGridView1.DataSource = db.Medals.ToList();
            }
            else if (selectedEntity == "Sport")
            {
                dataGridView1.DataSource = db.Sports.ToList();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            FormCollection openForms = Application.OpenForms;
            foreach (Form form in openForms)
            {
                form.Close();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string selectedEntity = comboBox1.SelectedItem.ToString();
            if (selectedEntity == "Country")
            {
                AddCountry();
            }
            else if (selectedEntity == "CountryMedalStanding")
            {
                AddCountryMedalStanding();
            }
            else if (selectedEntity == "OlympicGame")
            {
                AddOlympicGame();
            }
            else if (selectedEntity == "Sport")
            {
                AddSport();
            }
            else if (selectedEntity == "Medal")
            {
                AddMedal();
            }
            else if (selectedEntity == "AddAthlete")
            {
                AddAthlete();
            }
        }
        private void AddCountry()
        {
            string newCountryName = "New Country Name";
            Country newCountry = new Country
            {
                Name = newCountryName
            };
            db.Countries.Add(newCountry);
            db.SaveChanges();
            UpdateDataGrid();
        }

        private void AddCountryMedalStanding()
        {
            int newGold = 1;
            int newSilver = 2;
            int newBronze = 3;
            int newCountryId = 1;
            int newOlympicGameId = 1;
            CountryMedalStanding newCountryMedalStanding = new CountryMedalStanding
            {
                Gold = newGold,
                Silver = newSilver,
                Bronze = newBronze,
                CountryId = newCountryId,
                OlympicGameId = newOlympicGameId
            };
            db.CountryMedalStandings.Add(newCountryMedalStanding);
            db.SaveChanges();
            UpdateDataGrid();
        }

        private void AddOlympicGame()
        {
            int newYear = 2023;
            string newCountry = "Country Name";
            string newCity = "City Name";
            string newGameName = "Game Name";
            string newSportType = "Sport Type";
            OlympicGame newOlympicGame = new OlympicGame
            {
                Year = newYear,
                Country = newCountry,
                City = newCity,
                GameName = newGameName,
                SportType = newSportType
            };
            db.OlympicGames.Add(newOlympicGame);
            db.SaveChanges();
            UpdateDataGrid();
        }

        private void AddSport()
        {
            string newSportName = "Sport Name";
            Sport newSport = new Sport
            {
                Name = newSportName
            };
            db.Sports.Add(newSport);
            db.SaveChanges();
            UpdateDataGrid();
        }

        private void AddMedal()
        {
            int newType = 1;
            int newSportId = 1;
            int newAthleteId = 1;
            int newOlympicGameId = 1;
            Medal newMedal = new Medal
            {
                Type = newType,
                SportId = newSportId,
                AthleteId = newAthleteId,
                OlympicGameId = newOlympicGameId
            };
            db.Medals.Add(newMedal);
            db.SaveChanges();
            UpdateDataGrid();
        }

        private void AddAthlete()
        {
            string newFullName = "New Full Name";
            DateTime newBirthDate = new DateTime(2000, 1, 1);
            int newCountryId = 1;
            int newSportId = 1;
            Athlete newAthlete = new Athlete
            {
                FullName = newFullName,
                BirthDate = newBirthDate,
                CountryId = newCountryId,
                SportId = newSportId
            };
            db.Athletes.Add(newAthlete);
            db.SaveChanges();
            UpdateDataGrid();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            {
                string selectedEntity = comboBox1.SelectedItem.ToString();
                if (selectedEntity == "Country")
                {
                    EditCountry();
                }
                else if (selectedEntity == "Athlete")
                {
                    EditAthlete();
                }
                else if (selectedEntity == "MedalCountryStanding")
                {
                    EditCountryMedalStanding();
                }
                else if (selectedEntity == "EditOlympicGame")
                {
                    EditOlympicGame();
                }
                else if (selectedEntity == "EditSport")
                {
                    EditSport();
                }
                else if (selectedEntity == "EditMedal")
                {
                    EditMedal();
                }
            }
        }
        private void EditCountry()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int countryIdToEdit = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                string newCountryName = "New Name";
                Country countryToEdit = db.Countries.FirstOrDefault(c => c.Id == countryIdToEdit);
                if (countryToEdit != null)
                {
                    countryToEdit.Name = newCountryName;
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Edit.");
            }
        }
        private void EditAthlete()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int athleteIdToEdit = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                string newFullName = "New Full Name";
                DateTime newBirthDate = new DateTime(2000, 1, 1);
                int newCountryId = 1;
                int newSportId = 1;
                Athlete athleteToEdit = db.Athletes.FirstOrDefault(a => a.Id == athleteIdToEdit);
                if (athleteToEdit != null)
                {
                    athleteToEdit.FullName = newFullName;
                    athleteToEdit.BirthDate = newBirthDate;
                    athleteToEdit.CountryId = newCountryId;
                    athleteToEdit.SportId = newSportId;
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Edit.");
            }
        }
        private void EditCountryMedalStanding()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int countryMedalStandingIdToEdit = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                int newGold = 10;
                int newSilver = 5;
                int newBronze = 3;
                int newCountryId = 1;
                int newOlympicGameId = 1;
                CountryMedalStanding countryMedalStandingToEdit = db.CountryMedalStandings.FirstOrDefault(c => c.Id == countryMedalStandingIdToEdit);
                if (countryMedalStandingToEdit != null)
                {
                    countryMedalStandingToEdit.Gold = newGold;
                    countryMedalStandingToEdit.Silver = newSilver;
                    countryMedalStandingToEdit.Bronze = newBronze;
                    countryMedalStandingToEdit.CountryId = newCountryId;
                    countryMedalStandingToEdit.OlympicGameId = newOlympicGameId;
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Edit.");
            }
        }
        private void EditOlympicGame()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int olympicGameIdToEdit = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                int newYear = 2024;
                string newCountry = "New Country";
                string newCity = "New City";
                string newGameName = "New Game Name";
                string newSportType = "New Sport Type";
                OlympicGame olympicGameToEdit = db.OlympicGames.FirstOrDefault(o => o.Id == olympicGameIdToEdit);
                if (olympicGameToEdit != null)
                {
                    olympicGameToEdit.Year = newYear;
                    olympicGameToEdit.Country = newCountry;
                    olympicGameToEdit.City = newCity;
                    olympicGameToEdit.GameName = newGameName;
                    olympicGameToEdit.SportType = newSportType;
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Edit.");
            }
        }
        private void EditSport()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int sportIdToEdit = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                string newSportName = "New Sport Name";
                Sport sportToEdit = db.Sports.FirstOrDefault(s => s.Id == sportIdToEdit);
                if (sportToEdit != null)
                {
                    sportToEdit.Name = newSportName;
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Edit.");
            }
        }
        private void EditMedal()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int medalIdToEdit = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                int newType = 1;
                int newSportId = 1;
                int newAthleteId = 1;
                int newOlympicGameId = 1;
                Medal medalToEdit = db.Medals.FirstOrDefault(m => m.Id == medalIdToEdit);
                if (medalToEdit != null)
                {
                    medalToEdit.Type = newType;
                    medalToEdit.SportId = newSportId;
                    medalToEdit.AthleteId = newAthleteId;
                    medalToEdit.OlympicGameId = newOlympicGameId;
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Виберіть рядок для редагування.");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string selectedEntity = comboBox1.SelectedItem.ToString();

            switch (selectedEntity)
            {
                case "Country":
                    DeleteCountry();
                    break;
                case "Athlete":
                    DeleteAthlete();
                    break;
                case "Sport":
                    DeleteSport();
                    break;
                case "OlympicGame":
                    DeleteOlympicGame();
                    break;
                case "Medal":
                    DeleteMedal();
                    break;
                case "CountryMedalStanding":
                    DeleteCountryMedalStanding();
                    break;
                default:
                    break;
            }
        }
        private void DeleteCountry()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int countryIdToDelete = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                Country countryToDelete = db.Countries.FirstOrDefault(c => c.Id == countryIdToDelete);
                if (countryToDelete != null)
                {
                    db.Countries.Remove(countryToDelete);
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Delete.");
            }
        }

        private void DeleteAthlete()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int athleteIdToDelete = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                Athlete athleteToDelete = db.Athletes.FirstOrDefault(a => a.Id == athleteIdToDelete);
                if (athleteToDelete != null)
                {
                    db.Athletes.Remove(athleteToDelete);
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Delete.");
            }
        }
        private void DeleteMedal()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int medalIdToDelete = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                Medal medalToDelete = db.Medals.FirstOrDefault(m => m.Id == medalIdToDelete);
                if (medalToDelete != null)
                {
                    db.Medals.Remove(medalToDelete);
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Delete.");
            }
        }

        private void DeleteOlympicGame()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int olympicGameIdToDelete = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                OlympicGame olympicGameToDelete = db.OlympicGames.FirstOrDefault(o => o.Id == olympicGameIdToDelete);
                if (olympicGameToDelete != null)
                {
                    db.OlympicGames.Remove(olympicGameToDelete);
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Delete.");
            }
        }

        private void DeleteSport()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int sportIdToDelete = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                Sport sportToDelete = db.Sports.FirstOrDefault(s => s.Id == sportIdToDelete);
                if (sportToDelete != null)
                {
                    db.Sports.Remove(sportToDelete);
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Delete.");
            }
        }

        private void DeleteCountryMedalStanding()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int countryMedalStandingIdToDelete = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                CountryMedalStanding countryMedalStandingToDelete = db.CountryMedalStandings.FirstOrDefault(cms => cms.Id == countryMedalStandingIdToDelete);
                if (countryMedalStandingToDelete != null)
                {
                    db.CountryMedalStandings.Remove(countryMedalStandingToDelete);
                    db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Enter Line for Delete.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.OlympicGames.ToList();
            PopulateDataGridView("Athlete");
            PopulateDataGridView("Country");
            PopulateDataGridView("Medal");
            PopulateDataGridView("Sport");
            PopulateDataGridView("OlympicGame");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                string selectedEntity = comboBox1.SelectedItem.ToString();
                PopulateDataGridView(selectedEntity);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
