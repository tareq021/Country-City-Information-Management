<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master Page/MainMaster.Master" AutoEventWireup="true" CodeBehind="View Cities.aspx.cs" Inherits="CityInformationManagementSystem.UI.CityUI.ViewCitiesWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
            <nav class="navbar navbar-custom navbar-fixed-top" role="navigation">
                <div class="container" style="background: #333; top: 0px; padding: 0px 10px 0px 20px; position: fixed; width: 100%;">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-main-collapse">
                            <i class="fa fa-bars"></i>
                        </button>
                        <a class="navbar-brand page-scroll" href="../Home/Home.html">
                            <i class="fa fa-play-circle"></i><span class="light" style="font-size: 13px;">Country City Information Management System</span>
                        </a>
                    </div>
                    <div class="collapse navbar-collapse navbar-right navbar-main-collapse">
                        <ul class="nav navbar-nav">

                            <li>
                                <a class="page-scroll " href="../Country/Country entry.aspx">Country Entry</a>
                            </li>
                            <li>
                                <a class="page-scroll " href="../City/City Entry.aspx">City Entry</a>
                            </li>
                            <li>
                                <a class="page-scroll active" href="../City/View Cities.aspx">View Cities</a>
                            </li>
                            <li>
                                <a class="page-scroll" href="../Country/View Countries.aspx">View Countries</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>



            <div class="firstColumnWidth">
                <br />
            </div>

            <div class="secondColumnWidth">
                <fieldset class="fieldSetStyle">
                    <legend class="legendStyle">Search criteria</legend>
                    <div class=" radio" style="width: 25%; float: left;">
                        <asp:RadioButton runat="server" ID="cityNameRadioButton" class="labelGaneral" GroupName="criteria" Text="City Name" />
                    </div>
                    <div style="width: 75%; float: left;">
                        <asp:TextBox runat="server" ID="cityNameTextBox" class="form-control textBoxGaneral"></asp:TextBox>

                        <asp:Label ID="cityNameLabel" class="labelGaneral" runat="server" Text="Label"></asp:Label>

                        <br />
                    </div>

                    <div class="radio" style="width: 25%; float: left;">
                        <asp:RadioButton runat="server" ID="countryRadioButton" class="labelGaneral" GroupName="criteria" Text="Country" />
                    </div>
                    <div style="width: 55%; float: left;">
                        <asp:DropDownList runat="server" ID="countryDropDown" class="form-control textBoxGaneral"></asp:DropDownList>
                        <asp:Label ID="countryLabel" class="labelGaneral" runat="server" Text="Label"></asp:Label>

                    </div>
                    <div style="width: 15%; float: right;">
                        <asp:Button runat="server" ID="searchButton" Text="Search" class="button buttonSave" OnClick="searchButton_Click" />
                    </div>
                </fieldset>
            </div>


            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="fullSize">
                        <br />
                        <br />
                        <asp:GridView runat="server" ID="viewCitiesGridView" AutoGenerateColumns="False"  GridLines="Vertical" HeaderStyle-HorizontalAlign="Center" BorderColor="#cccccc" Style="width: 100%;" AllowPaging="True" PageSize="3" OnPageIndexChanging="PageIndexChange">
                            <AlternatingRowStyle BackColor="#a3c2c2" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#3d5c5c" Font-Bold="True" ForeColor="White" CssClass="gridViewHeaderStyle" />
                            <PagerStyle BackColor="#d1e0e0" HorizontalAlign="Center" />
                            <RowStyle BackColor="#e0ebeb" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#ff4d4d" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            <Columns>
                                <asp:TemplateField HeaderText="SL#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="City Name">
                                    <ItemTemplate>
                                        <%#Eval("CityName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="About">
                                    <ItemTemplate>
                                        <%#Eval("CityAbout") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No. of dwellers">
                                    <ItemTemplate>
                                        <%#Eval("NoOfDwellers") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Location">
                                    <ItemTemplate>
                                        <%#Eval("CityLocation") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Weather">
                                    <ItemTemplate>
                                        <%#Eval("CityWeather") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Country">
                                    <ItemTemplate>
                                        <%#Eval("CityCountry") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="About Country">
                                    <ItemTemplate>
                                        <%#Eval("CountryAbout") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" CssClass="cssPager" Font-Size="Medium" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
<%--            <script>

                $(document).ready(function () {
                    var cityRadio = $('#<%= cityNameRadioButton.ClientID  %>');
                    var countryRadio = $('#<%= countryRadioButton.ClientID  %>');
                    var cityText = $('#<%= cityNameTextBox.ClientID  %>');
                    var countryDropDown = $('#<%= countryDropDown.ClientID  %>');
                    var seacrhButton = $('#<%= searchButton.ClientID  %>');

                    cityText.removeAttr('disabled');
                    countryDropDown.attr('disabled', true);


                    $(cityRadio).click(function (e) {

                        if (this.checked) {
                            cityText.removeAttr('disabled');
                            countryDropDown.attr('disabled', true);
                        }
                        else {
                            countryDropDown.removeAttr('disabled');
                            cityText.attr('disabled', true);
                        }
                    });

                    $(countryRadio).click(function (e) {

                        if (this.checked) {
                            countryDropDown.removeAttr('disabled');
                            cityText.attr('disabled', true);
                        }
                        else {
                            cityText.removeAttr('disabled');
                        }
                    });
                });

                var prm = Sys.WebForms.PageRequestManager.getInstance();

                prm.add_endRequest(function () {

                    var cityRadio = $('#<%= cityNameRadioButton.ClientID  %>');
            var countryRadio = $('#<%= countryRadioButton.ClientID  %>');
            var cityText = $('#<%= cityNameTextBox.ClientID  %>');
            var countryDropDown = $('#<%= countryDropDown.ClientID  %>');

            cityText.removeAttr('disabled');
            countryDropDown.attr('disabled', true);
            cityRadio.attr('checked', true);
            $(cityRadio).click(function (e) {

                if (this.checked) {
                    cityText.removeAttr('disabled');
                    countryDropDown.attr('disabled', true);
                }
                else {
                    countryDropDown.removeAttr('disabled');
                    cityText.attr('disabled', true);
                }
            });

            $(countryRadio).click(function (e) {

                if (this.checked) {
                    countryDropDown.removeAttr('disabled');
                    cityText.attr('disabled', true);
                }
                else {
                    cityText.removeAttr('disabled');
                }
            });
        });


            </script>--%>
      

</asp:Content>
