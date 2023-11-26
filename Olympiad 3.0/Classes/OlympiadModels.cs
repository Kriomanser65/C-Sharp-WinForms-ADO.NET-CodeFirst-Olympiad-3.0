using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Olympiad_3._0.Classes
{
    public class OlympicGame
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public bool IsWinter { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string GameName { get; set; }
        public string SportType { get; set; }
        public ICollection<Sport> Sports { get; set; }
        public ICollection<CountryMedalStanding> MedalStandings { get; set; }
    }

    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Medal> Medals { get; set; }
        public ICollection<OlympicGame> OlympicGames { get; set; }
        public ICollection<Athlete> Athletes { get; set; }
    }

    public class Athlete
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public ICollection<Medal> Medals { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Athlete> Athletes { get; set; }
        public ICollection<CountryMedalStanding> MedalStandings { get; set; }
    }

    public class Medal
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int AthleteId { get; set; }
        public Athlete Athlete { get; set; }
        public int OlympicGameId { get; set; }
        public OlympicGame OlympicGame { get; set; }
    }

    public class CountryMedalStanding
    {
        public int Id { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Bronze { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int OlympicGameId { get; set; }
        public OlympicGame OlympicGame { get; set; }
    }
}
