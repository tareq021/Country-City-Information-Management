using System.Collections.Generic;
using CityInformationManagementSystem.Models;
using CityInformationManagementSystem.DAL;

namespace CityInformationManagementSystem.BLL
{
    public class CityManager
    {
        CityGateway gateway = new CityGateway();
        CountryManager manager = new CountryManager();

        public List<Country> GetAllCountries()
        {
            List<Country> countryList = manager.GetAllCountries();
            return countryList;
        }
        public List<City> GetAllCities()
        {
            List<City> cityList = gateway.GetAllCities();
            return cityList;
        }

        public string SaveCity(City aCity)
        {

            if (gateway.CityExists(aCity))
            {
                return "City Already Exists";
            }
            else
            {
                int rowAffected = gateway.SaveCity(aCity);
                if (rowAffected > 0)
                {
                    return "City Saved";
                }
                else
                {
                    return "City Can Not Be Saved";
                }
            }
        }

        public List<City> DisplayAllCities(string searchKey)
        {
            List<City> aCity = gateway.DisplayAllCities(searchKey);
            return aCity;
        }

        public List<City> DisplayAllCountries(string searchKey)
        {
            List<City> aCity = gateway.DisplayAllCountries(searchKey);
            return aCity;
        }
    }
}