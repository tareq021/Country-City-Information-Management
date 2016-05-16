using CityInformationManagementSystem.BLL;
using CityInformationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace CityInformationManagementSystem.UI.CityUI
{
    public partial class CityEntryWebForm : System.Web.UI.Page
    {
        CityManager manager = new CityManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "City Entry";

                List<City> cityList = manager.GetAllCities();
                cityEntryGridView.DataSource = cityList;
                cityEntryGridView.DataBind();

                if (!IsPostBack)
                {
                    List<Country> countryList = manager.GetAllCountries();
                    countryDropDown.DataSource = countryList;
                    countryDropDown.DataTextField = "CountryName";
                    countryDropDown.DataValueField = "CountryName";
                    countryDropDown.DataBind();
                }

            }
            catch (Exception ex)
            {
                string exception = "Error ! <br />" + "Details: " + ex.Message;
                HttpContext.Current.Response.Write("<script>alert('" + exception + "')</script>");
            }


        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                City aCity = new City();
                aCity.CityName = cityNameTextBox.Text;
                aCity.CityAbout = aboutText.InnerText;
                aCity.NoOfDwellers = Convert.ToInt32(noOfDwellersTextBox.Text);
                aCity.CityLocation = locationTextBox.Text;
                aCity.CityWeather = weatherTextBox.Text;
                aCity.CityCountry = countryDropDown.SelectedValue;

                string saveInfoMessage = manager.SaveCity(aCity);
                HttpContext.Current.Response.Write("<script>alert('" + saveInfoMessage + "')</script>");
                List<City> cityList = manager.GetAllCities();
                cityEntryGridView.DataSource = cityList;
                cityEntryGridView.DataBind();

                cityNameTextBox.Text = "";
                aboutText.InnerText = "";
                noOfDwellersTextBox.Text = "";
                locationTextBox.Text = "";
                weatherTextBox.Text = "";
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
                cityEntryGridView.PageIndex = e.NewPageIndex;
                cityEntryGridView.DataBind();
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("<script>alert('Error!')</script>");
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}