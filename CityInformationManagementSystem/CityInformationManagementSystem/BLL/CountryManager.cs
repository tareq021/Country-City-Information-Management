using System.Collections.Generic;
using CityInformationManagementSystem.Models;
using CityInformationManagementSystem.DAL;

namespace CityInformationManagementSystem.BLL
{
    public class CountryManager
    {
        CountryGateway gateway = new CountryGateway();
        public List<Country> GetAllCountries()
        {
            List<Country> countryList = gateway.GetAllCountries();
            return countryList;
        }
                
        public string AddCountry(Country aCountry)
        {
            if (gateway.CountryExists(aCountry.CountryName))
            {
                return "Country Already Exists";
                
            }
            else
            {
                int rowAffect = gateway.AddCountry(aCountry); ;
                if (rowAffect > 0)
                {
                    return "Country Saved";
                }
                else
                {
                    return "Country Information Can not be Saved";
                }
                
            }
        }
     
        public List<Country> DisplayAllCountries( string searchKey)
        {
            List < Country > aCountry= gateway.DisplayAllCountries(searchKey);
            return aCountry;
        }
    }
}