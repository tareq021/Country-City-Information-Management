using CityInformationManagementSystem.BLL;
using CityInformationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace CityInformationManagementSystem.UI.CountryUI
{
    public partial class ViewCountriesWebForm : System.Web.UI.Page
    {
      
        CountryManager manager = new CountryManager();
        Country aCountry = new Country();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "View Countries";
                SerchingCountryName();
               
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("<script>alert('Error!')</script>");
            }
        }      

        protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                SerchingCountryName();
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("<script>alert('Error!')</script>");
            }
        }

        protected void PageIndexChange(object sender, GridViewPageEventArgs e)
        {
            try
            {
                viewCountriesGridView.PageIndex = e.NewPageIndex;
                viewCountriesGridView.DataBind();
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("<script>alert('Error!')</script>");
            }
        }


        public void SerchingCountryName()
        {
            if (countryNameTextBox.Text == "")
            {
                List<Country> countryList = manager.DisplayAllCountries("");
                viewCountriesGridView.DataSource = countryList;
                viewCountriesGridView.DataBind();
            }

            else if (countryNameTextBox.Text != "")
            {
                string searchKey = countryNameTextBox.Text;
                List<Country> countryList = manager.DisplayAllCountries(searchKey);
                if (countryList.Count == 0)
                {
                    countryNameLabel.Text = "Country name with keyword: " + searchKey + " is not found!";
                    viewCountriesGridView.Visible = false;
                }
                else
                {
                    countryNameLabel.Text = "";
                    viewCountriesGridView.Visible = true;
                    viewCountriesGridView.DataSource = countryList;
                    viewCountriesGridView.DataBind();
                }
               
            }
        }
    }
}