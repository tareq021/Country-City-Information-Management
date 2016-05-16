using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using CityInformationManagementSystem.Models;
using System.Data.SqlClient;

namespace CityInformationManagementSystem.DAL
{
    public class CityGateway
    {
        SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS; Database=CountryCityDB; Integrated Security=true;");
        public List<City> GetAllCities()
        {
            List<City> cityList = new List<City>();

            string query = "SELECT * FROM City ORDER BY CityName";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string cityName = reader["CityName"].ToString();
                string dweller=reader["CityDweller"].ToString();
                int cityDwellers = (dweller != "") ? Convert.ToInt32(dweller) : 0;
                string cityCountry = reader["CityCountry"].ToString();
                City aCity = new City(cityName, cityDwellers, cityCountry);

                cityList.Add(aCity);
            }

            connection.Close();

            return cityList;
        }

        public int SaveCity(City aCity)
        {
            string query = "INSERT INTO City (CityName, CityAbout, CityDweller, CityLocation, CityWeather, CityCountry)VALUES('" + aCity.CityName + "','" + aCity.CityAbout + "','" + aCity.NoOfDwellers + "','" + aCity.CityLocation + "','" + aCity.CityWeather + "','" + aCity.CityCountry + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected;
        }

        public bool CityExists(City aCity)
        {
            bool isCityExists = false;

            string query = "SELECT * FROM City WHERE CityName = @CityName AND CityCountry= @CityCountry";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("CityName", aCity.CityName));
            command.Parameters.Add(new SqlParameter("CityCountry", aCity.CityCountry));

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isCityExists = true;
            }

            connection.Close();
            return isCityExists;
        }

        public List<City> DisplayAllCities(string searchKey)
        {
            List<City> cityList = new List<City>();

            string query = "";
            string like = "";
            if (searchKey == "")
            {
                query = "select * from viewCities order by CityName;";
            }
            else if (searchKey != "")
            {
                like = "%" + searchKey + "%";
                query = "SELECT * FROM viewCities WHERE CityName LIKE @like order by CityName;";
            }

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("like", like));
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string cityName = reader["CityName"].ToString();
                string cityAbout = reader["CityAbout"].ToString();
                string dweller = reader["CityDwellers"].ToString();
                int cityDweller = (dweller != "") ? Convert.ToInt32(dweller) : 0;
                string cityLocation = reader["CityLocation"].ToString();
                string cityWeather = reader["CityWeather"].ToString();
                string countryName = reader["CountryName"].ToString();
                string countryAbout = reader["CountryAbout"].ToString();


                City aCity = new City(cityName, cityAbout, cityDweller, cityLocation, cityWeather, countryName, countryAbout);

                cityList.Add(aCity);
            }

            connection.Close();

            return cityList;
        }

        public List<City> DisplayAllCountries(string searchKey)
        {
            List<City> cityList = new List<City>();

            string query = "";
            if (searchKey != "")
            {
                query = "SELECT * FROM viewCities WHERE CountryName = @searchKey ORDER BY CityName;";
            }

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("searchKey", searchKey));
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string cityName = reader["CityName"].ToString();
                string cityAbout = reader["CityAbout"].ToString();
                string dweller = reader["CityDwellers"].ToString();
                int cityDweller = (dweller != "") ? Convert.ToInt32(dweller) : 0;
                string cityLocation = reader["CityLocation"].ToString();
                string cityWeather = reader["CityWeather"].ToString();
                string countryName = reader["CountryName"].ToString();
                string countryAbout = reader["CountryAbout"].ToString();


                City aCity = new City(cityName, cityAbout, cityDweller, cityLocation, cityWeather, countryName,
                    countryAbout);

                cityList.Add(aCity);
            }

            connection.Close();

            return cityList;

        }

    }
}