<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/UI/Master Page/MainMaster.Master" AutoEventWireup="true" CodeBehind="Country Entry.aspx.cs" Inherits="CityInformationManagementSystem.UI.CountryUI.CountryEntryWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Country Entry
    </title>


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
                        <a class="page-scroll active" href="../Country/Country entry.aspx">Country Entry</a>
                    </li>
                    <li>
                        <a class="page-scroll " href="../City/City Entry.aspx">City Entry</a>
                    </li>
                    <li>
                        <a class="page-scroll " href="../City/View Cities.aspx">View Cities</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="../Country/View Countries.aspx">View Countries</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>


    <div class="firstColumnWidth">
        <asp:Label runat="server" CssClass="labelGaneral" ID="nameLabel" Text="Name"></asp:Label>
    </div>
    <div class="secondColumnWidth">
        <asp:TextBox runat="server" ID="countryNameTextBox" class="form-control textBoxGaneral"></asp:TextBox>
        <asp:RequiredFieldValidator ID="CountryNameValidator" runat="server" ControlToValidate="countryNameTextBox" Display="Dynamic" ErrorMessage="* Please provide Country Name!" ForeColor="#ff3300"></asp:RequiredFieldValidator>
    </div>

    <div class="firstColumnWidth">
        <br />
        <asp:Label runat="server" CssClass="labelGaneral" ID="aboutLabel" Text="About"></asp:Label>
    </div>
    <div class="secondColumnWidth">
        <br />
        <textarea id="aboutText" runat="server" style="width: 100%; height: 200px"></textarea>
    </div>


    <div class="firstColumnWidth">
        <br />
    </div>
    <div class="secondColumnWidth">
        <br />
        <asp:Button runat="server" ID="saveButton" Text="Save" class="button buttonSave" OnClick="saveButton_Click" />
        <asp:Button runat="server" ID="cancelButton" Text="Cancel" class="button buttonCancel" OnClientClick="window.location.href='../Home/Home.html';return false;" />
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="fullSize">
                <br />
                <br />
                <asp:GridView runat="server" ID="countryEntryGridView" AutoGenerateColumns="False" GridLines="Vertical" HeaderStyle-HorizontalAlign="Center" BorderColor="#cccccc" Style="width: 100%; " AllowPaging="True" PageSize="3" OnPageIndexChanging="PageIndexChange">
                    <AlternatingRowStyle BackColor="#a3c2c2" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#3d5c5c" Font-Bold="True" ForeColor="White" />
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

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("CountryName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="About">
                            <ItemTemplate>
                                <%#Eval("CountryAbout") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings FirstPageText="&amp;&amp;lt;&amp;lt;&amp;" LastPageText="&amp;gt; &amp; &amp;gt;" PreviousPageText="&amp;&amp;lt;&amp;" />
                    <PagerStyle HorizontalAlign="Center" CssClass="cssPager" Font-Size="Medium" />
                </asp:GridView>
                <br />
                <br />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="../tinymce/js/tinymce/tinymce.min.js"></script>
    <script>
        tinyMCE.init({

            selector: '#<%=aboutText.ClientID%>',
            theme: "modern",

            plugins: [
                 "advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker",
                 "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
                 "save table contextmenu directionality emoticons template paste textcolor"
            ],
            content_css: "css/content.css",
            toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons",
            style_formats: [
                 { title: 'Bold text', inline: 'b' },
                 { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
                 { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
                 { title: 'Example 1', inline: 'span', classes: 'example1' },
                 { title: 'Example 2', inline: 'span', classes: 'example2' },
                 { title: 'Table styles' },
                 { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
            ]
        });
    </script>
</asp:Content>
