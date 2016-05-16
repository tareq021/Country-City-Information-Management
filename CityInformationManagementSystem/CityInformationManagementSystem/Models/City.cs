using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityInformationManagementSystem.Models
{
    public class City
    {
        public string CityName { get; set; }
        public string CityAbout { get; set; }
        public int NoOfDwellers { get; set; }
        public string CityLocation { get; set; }
        public string CityWeather { get; set; }
        public string CityCountry { get; set; }
        public string CountryAbout { get; set; }

        public City(string cityName, int cityDwellers, string cityCountry)
        {
            CityName = cityName;
            NoOfDwellers = cityDwellers;
            CityCountry = cityCountry;
        }

        public City(string cityName,string cityAbout, int cityDwellers, string cityLocation, string cityWeather, string countryName, string countryAbout )
        {
            CityName = cityName;
            CityAbout = cityAbout;
            NoOfDwellers = cityDwellers;
            CityLocation = cityLocation;
            CityWeather = cityWeather;
            CityCountry = countryName;
            CountryAbout = countryAbout;
        }

        public City()
        {
        }

       
    }
}