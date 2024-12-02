using Debra_client.aspx;
using Debra_client.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Debra_client.Web_forms.Users {
    public partial class UserRegister : Page {
        UserServiceSoapClient user_service = new UserServiceSoapClient();

        Helper helper = new Helper();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Partner_Form.Visible = false;
                Customer_Form.Visible = false;
                RegisterBtn.Visible = false;
                BackBtn.Visible = false;
            } else {
                // Restore form visibility after postback based on ViewState
                if (ViewState["CurrentForm"] != null) {
                    string currentForm = ViewState["CurrentForm"].ToString();
                    if (currentForm == "Partner") {
                        Partner_Form.Visible = true;
                        Customer_Form.Visible = false;
                    } else if (currentForm == "Customer") {
                        Customer_Form.Visible = true;
                        Partner_Form.Visible = false;
                    }

                }
            }
        }
        protected void BackBtn_Click(object sender, EventArgs e) {
            Response.Redirect(Request.RawUrl);
        }

        protected void PartnerForm_Click(object sender, EventArgs e) {
            txtPEmail.Text = "";
            txtPPassword.Text = "";
            textCompanyName.Text = "";

            RegisterBtn.Visible = true;
            BackBtn.Visible = true;
            Customer_Form.Visible = false;
            Partner_Form.Visible = true;
            CustomerFormBtn.Visible = false;
            PartnerFormBtn.Visible = false;


            ViewState["CurrentForm"] = "Partner";
        }

        protected void CustomerForm_Click(object sender, EventArgs e) {
            txtCEmail.Text = "";
            txtCPassword.Text = "";
            textfirstName.Text = "";
            textLastName.Text = "";
            textPhone.Text = "";

            RegisterBtn.Visible = true;
            BackBtn.Visible = true;

            Partner_Form.Visible = false;
            Customer_Form.Visible = true;
            PartnerFormBtn.Visible = false;
            CustomerFormBtn.Visible = false;

            ViewState["CurrentForm"] = "Customer";
        }

        protected void Register_Click(object sender, EventArgs e) {
            if (ViewState["CurrentForm"] == null) {
                ShowAlert("Invalid form state.");
                return;
            }

            string currentForm = ViewState["CurrentForm"].ToString();
            User user = null;
            List<string> validationErrors = new List<string>();

            switch (currentForm) {
                case "Partner":
                    user = ValidatePartnerForm(validationErrors);
                    break;
                case "Customer":
                    user = ValidateCustomerForm(validationErrors);
                    break;
                default:
                    ShowAlert("Unknown form type.");
                    return;
            }

            if (user != null && !validationErrors.Any()) {
                bool result = user_service.CreateUser(user);
                ShowAlert($"User registered successfully: {user.Email} ({user.UserType})");
                Response.Redirect("~/Web%20forms/Users/UserLogin.aspx");
            } else {
                ShowAlert($"Registration failed: {string.Join(" ", validationErrors)}");
            }
        }

        private User ValidatePartnerForm(List<string> errors) {
            string email = ValidateField(txtPEmail.Text, helper.ValidateEmail, "Email", errors);
            string password = ValidateField(txtPPassword.Text, helper.ValidatePassword, "Password", errors);
            string companyName = ValidateField(textCompanyName.Text, helper.ValidateString, "Company Name", errors);

                  
            if (!errors.Any()) {
                return new Debra_client.UserService.Partner {
                    UserType = "Partner",
                    Email = email,
                    Password = password,
                    CompanyName = companyName
                };
            }

            return null;
        }

        private User ValidateCustomerForm(List<string> errors) {
            string email = ValidateField(txtCEmail.Text, helper.ValidateEmail, "Email", errors);
            string password = ValidateField(txtCPassword.Text, helper.ValidatePassword, "Password", errors);
            string firstName = ValidateField(textfirstName.Text, helper.ValidateString, "First Name", errors);
            string lastName = ValidateField(textLastName.Text, helper.ValidateString, "Last Name", errors);
            string phone = ValidateField(textPhone.Text, helper.ValidatePhoneNumber, "Phone", errors);

            if (!errors.Any()) {
                return new Debra_client.UserService.Customer {
                    UserType = "Customer",
                    Email = email,
                    Password = password,
                    Firstname = firstName,
                    Lastname = lastName,
                    Phone = phone
                };
            }

            return null;
        }

        private string ValidateField(string value, Func<string, bool> validator, string fieldName, List<string> errors) {
            if (validator(value)) {
                return value;
            }

            errors.Add($"Invalid {fieldName}. {value}");
            return null;
        }

        private void ShowAlert(string message) {
            helper.SendAlert(message, this.GetType(), this.ClientScript);
        }

    }



}

