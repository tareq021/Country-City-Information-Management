using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityInformationManagementSystem.Models
{
    public class Country
    {
        public string CountryName { get; set; }
        public string CountryAbout { get; set; }
        public int NoOfCities { get; set; }
        public int NoOfCityDwellers { get; set; }

        public Country(string name, string about)
        {
            CountryName = name;
            CountryAbout = about;
        }

        public Country(string name, string about, int noOfCities, int noOfDwellers)
        {
            CountryName = name;
            CountryAbout = about;
            NoOfCities = noOfCities;
            NoOfCityDwellers = noOfDwellers;

        }

        public Country()
        {

        }  
    }
}