using CityInformationManagementSystem.BLL;
using CityInformationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace CityInformationManagementSystem.UI.CityUI
{
    public partial class ViewCitiesWebForm : System.Web.UI.Page
    {
        CityManager manager = new CityManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "View Cities";
                cityNameLabel.Visible = false;
                countryLabel.Visible = false;
                viewCitiesGridView.Visible = true;

                if (!IsPostBack)
                {
                    List<Country> countryList = manager.GetAllCountries();
                    countryDropDown.DataSource = countryList;
                    countryDropDown.DataTextField = "CountryName";
                    countryDropDown.DataValueField = "CountryName";
                    countryDropDown.DataBind();
                    cityNameRadioButton.Checked = true;
                }

                SearchingName();

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
                SearchingName();
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("<script>alert('Error!')</script>");
            }

        }

        public void SearchingName()
        {

            if (cityNameRadioButton.Checked == true && cityNameTextBox.Text == "")
            {
                List<City> cityList = manager.DisplayAllCities(cityNameTextBox.Text);
                viewCitiesGridView.DataSource = cityList;
                viewCitiesGridView.DataBind();
            }

            else if (cityNameRadioButton.Checked == true)
            {
                countryRadioButton.Checked = false;

                string searchKey = cityNameTextBox.Text;
                List<City> cityList = manager.DisplayAllCities(searchKey);
                if (cityList.Count == 0)
                {
                    cityNameLabel.Visible = true;
                    cityNameLabel.Text = "City name with keyword: " + searchKey + " is not found!";
                }
                viewCitiesGridView.DataSource = cityList;
                viewCitiesGridView.DataBind();
            }
            if (countryRadioButton.Checked == true)
            {
                cityNameRadioButton.Checked = false;
                string searchKey = countryDropDown.SelectedValue;
                List<City> cityList = manager.DisplayAllCountries(searchKey);
                if (searchKey == "")
                {
                    countryLabel.Visible = true;
                    countryLabel.Text = "Country name with keyword: " + searchKey + " is not found!";
                }
                else
                {
                    if (cityList.Count == 0)
                    {
                        countryLabel.Visible = true;
                        viewCitiesGridView.Visible = false;
                        countryLabel.Text = "No City Available of the selected country";
                    }
                    else if (cityList.Count != 0)
                    {
                        viewCitiesGridView.Visible = true;
                        List<City> countryList = manager.DisplayAllCountries(searchKey);
                        viewCitiesGridView.DataSource = countryList;
                        viewCitiesGridView.DataBind();
                    }

                }

            }
        }


        protected void PageIndexChange(object sender, GridViewPageEventArgs e)
        {
            try
            {
                viewCitiesGridView.PageIndex = e.NewPageIndex;
                viewCitiesGridView.DataBind();
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("<script>alert('Error!')</script>");
            }
        }

    }
}