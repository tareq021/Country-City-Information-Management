using CityInformationManagementSystem.BLL;
using CityInformationManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace CityInformationManagementSystem.UI.CountryUI
{
    public partial class CountryEntryWebForm : System.Web.UI.Page
    {
        CountryManager manager = new CountryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "Country Entry";
                

                List<Country> countryList = manager.GetAllCountries();
                countryEntryGridView.DataSource = countryList;
                countryEntryGridView.DataBind();
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("<script>alert('Error!')</script>");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Country aCountry = new Country();
                aCountry.CountryName = countryNameTextBox.Text;
                aCountry.CountryAbout = aboutText.InnerText;

                string saveInfoMessage = manager.AddCountry(aCountry);
                HttpContext.Current.Response.Write("<script>alert('" + saveInfoMessage + "')</script>");
                List<Country> countryList = manager.GetAllCountries();
                countryEntryGridView.DataSource = countryList;
                countryEntryGridView.DataBind();

                countryNameTextBox.Text = "";
                aboutText.InnerText = "";
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
                countryEntryGridView.PageIndex = e.NewPageIndex;
                countryEntryGridView.DataBind();
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("<script>alert('Error!')</script>");
            }
        }
    }
}