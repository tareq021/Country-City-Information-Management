using System;
using System.Collections.Generic;
using CityInformationManagementSystem.Models;
using System.Data.SqlClient;

namespace CityInformationManagementSystem.DAL
{
    public class CountryGateway
    {
        SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS; Database=CountryCityDB; Integrated Security=true;");
                
        public List<Country> GetAllCountries()
        {
            List<Country> countryList = new List<Country>();
            
            string query = "SELECT * FROM Country ORDER BY CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string countryName = reader["CountryName"].ToString();
                string CountryAbout = reader["CountryAbout"].ToString();
                Country aCountry = new Country(countryName,CountryAbout);

                countryList.Add(aCountry);
            }

            connection.Close();

            return countryList;
        }

        public bool CountryExists(string country)
        {
            bool isCountryExsits = false;
            string query = "SELECT * FROM Country WHERE CountryName = @country";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("country", country));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isCountryExsits = true;
            }
            connection.Close();

            return isCountryExsits;
        }
    
        public int AddCountry(Country aCountry)
        {
            string query = "INSERT INTO Country (CountryName, CountryAbout)VALUES(@CountryName,@CountryAbout);";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("CountryName", aCountry.CountryName));
            command.Parameters.Add(new SqlParameter("CountryAbout", aCountry.CountryAbout));
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected;
        }

        public List<Country> DisplayAllCountries(string searchKey)
        {
            List<Country> countryList = new List<Country>();

            string query = "";
            string like = "";
            if (searchKey == "")
            {
                query = "select * from viewCountries order by Name;";
            }
            else if (searchKey != "")
            {
                like = "%" + searchKey + "%";
                query = "SELECT * FROM viewCountries WHERE Name LIKE @like  order by Name ";
            }

            

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("like", like));
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string countryName = reader["Name"].ToString();
                string countryAbout = reader["About"].ToString();
                int noOfCities = Convert.ToInt32(reader["No. of cities"].ToString());
                int noOfDwellers = Convert.ToInt32(reader["NoOfCityDwellers"].ToString());

                Country aCountry = new Country(countryName, countryAbout, noOfCities, noOfDwellers);

                countryList.Add(aCountry);
            }

            connection.Close();

            return countryList;
        }        
    }
}
