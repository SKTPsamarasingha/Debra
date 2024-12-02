<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Debra_client.Web_forms.Employee.ManageUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Google fonts -->
    <link href="https://fonts.cdnfonts.com/css/raleway-5" rel="stylesheet" />
    <!-- font awesome -->
    <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/CommonStyles.css" />
    <link rel="stylesheet" type="text/css" href="../../css/EmployeeStyles.css" />


</head>
<body>
    <form id="form1" class="main" runat="server">
        <div id="btnContienr" class="Btn-contienr">
            <a href="/Web%20forms/Employee/EmployeeHome.aspx" class="asideBtns EventsFeatures">Home</a>
            <a href="/Web%20forms/Employee/Sales.aspx" class="asideBtns EventsFeatures">Sales</a>
        </div>

        <div class="table-container">
            <div class="userView-container">
                <asp:Button ID="GetEmployee" class="btn-add" runat="server" Text="View Employee" OnClick="Button_Click" />
                <asp:Button ID="GetCutomers" class="btn-add" runat="server" Text="View Customers" OnClick="Button_Click" />
                <asp:Button ID="GetPartners" class="btn-add" runat="server" Text="View Partners" OnClick="Button_Click" />
            </div>

            <%--Partners table--%>
            <div id="PartnersContainer" runat="server">
                <h2>Partners</h2>

                <asp:Repeater ID="rptPartner" runat="server">
                    <HeaderTemplate>

                        <table class="salesTable table-striped">
                            <thead>
                                <tr>
                                    <th>Email</th>
                                    <th>UserType</th>
                                    <th>Company</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Email") %></td>
                            <td><%# Eval("UserType") %></td>
                            <td><%# Eval("companyName") %></td>
                            <td><%# (bool)Eval("status") ? "Active" : "Deactivate" %></td>

                            <td>
                                <asp:Button ID="BtnActivate" runat="server" Text="Active" CssClass="btn-update GetPartners" CommandArgument='<%# Eval("UserID") %>' OnClick="BtnActivate_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnDeactivate" runat="server" Text="Deactivate" CssClass="btn-delete GetPartners" CommandArgument='<%# Eval("UserID") %>' OnClick="BtnDeactivate_Click" />
                            </td>
                            <tr />
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
</table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <%--Customer table--%>
            <div id="CustomerContainer" runat="server">
                <h2>Customers</h2>

                <asp:Repeater ID="rptCustomer" runat="server">
                    <HeaderTemplate>

                        <table class="salesTable table-striped">
                            <thead>
                                <tr>
                                    <th>Email</th>
                                    <th>UserType</th>
                                    <th>First name</th>
                                    <th>Last name</th>
                                    <th>Phone</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Email") %></td>
                            <td><%# Eval("UserType") %></td>
                            <td><%# Eval("firstname") %></td>
                            <td><%# Eval("lastname") %></td>
                            <td><%# Eval("phone") %></td>
                            <td><%# (bool)Eval("status") ? "Active" : "Block" %></td>
                            <td>
                                <asp:Button ID="BtnActivate" runat="server" Text="Active" CssClass="btn-update GetCutomers" CommandArgument='<%# Eval("UserID") %>' OnClick="BtnActivate_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnDeactivate" runat="server" Text="Deactivate" CssClass="btn-delete GetCutomers" CommandArgument='<%# Eval("UserID") %>' OnClick="BtnDeactivate_Click" />
                            </td>
                            <tr />
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
</table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <%--Employee table--%>
            <div id="EmployeeContainer" runat="server">
                <h2>Employee</h2>

                <asp:Repeater ID="rptEmployee" runat="server">
                    <HeaderTemplate>

                        <table class="salesTable table-striped">
                            <thead>
                                <tr>
                                    <th>Email</th>
                                    <th>UserType</th>
                                    <th>First name</th>
                                    <th>Last name</th>
                                    <th>Role</th>
                                    <th>Status</th>
                                    <th>
                                        <asp:Button ID="AddEmployee" class="btn-add" runat="server" Text="Add Employee" OnClick="AddEmployee_Click" />
                                    </th>

                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Email") %></td>
                            <td><%# Eval("UserType") %></td>
                            <td><%# Eval("firstname") %></td>
                            <td><%# Eval("lastname") %></td>
                            <td><%# Eval("role") %></td>
                            <td><%# (bool)Eval("status") ? "Active" : "Deactivate" %></td>


                            <td>
                                <asp:Button ID="BtnActivate" runat="server" Text="Active" CssClass="btn-update GetEmployee" CommandArgument='<%# Eval("UserID") %>' OnClick="BtnActivate_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnDeactivate" runat="server" Text="Deactivate" CssClass="btn-delete GetEmployee" CommandArgument='<%# Eval("UserID") %>' OnClick="BtnDeactivate_Click" />
                            </td>
                            <tr />
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
</table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

        </div>
    </form>
</body>
</html>
