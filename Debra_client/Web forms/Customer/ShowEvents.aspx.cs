using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Debra_client.CustomerService;
using Debra_client.Web_forms.Partner;


namespace Debra_client.aspx.Customer {
    public partial class Events : System.Web.UI.Page {
        CustomerServiceSoapClient CustomerService = new CustomerServiceSoapClient();
        List<Event> events = new List<Event>();
        Helper helper = new Helper();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                try {

                    var eventRslt = CustomerService.GetEventByStatus(true);
                    events = eventRslt != null ? eventRslt.ToList() : null;



                    renderEvent(events);
                } catch (Exception ex) {
                    helper.SendAlert("Unable to fetch event data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
                }
            }
        }

        protected void UserAccount_Click(object sender, EventArgs e) {
            Response.Redirect("~/Web forms/Customer/CustomerHome.aspx");

        }

        protected void SearchBtn_Click(object sender, EventArgs e) {
            string input = txtSrchInput.Text.Trim().ToLower();
            string msg = "";

            try {
                if (string.IsNullOrEmpty(input)) helper.SendAlert("Please Enter A Event Name", this.GetType(), this.ClientScript);


                var events = CustomerService.GetEventByStatus(true).ToList();
                Event srchEvnt = new Event();


                if (events.Count < 0 && events == null) {
                    msg = "Sorry! we dont have the any events at the moment";
                }
                srchEvnt = events.FirstOrDefault(evt => evt.EventName.ToLower() == input);

                if (srchEvnt != null) {
                    events.Clear();
                    events.Add(srchEvnt);
                } else {
                    msg = "Sorry! Looks like we dont have that event yet!";
                }

                if (msg != "") helper.SendAlert(msg, this.GetType(), this.ClientScript);
                renderEvent(events);

            } catch (Exception ex) {
                helper.SendAlert("Unable to fetch event data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }

        }

        private void renderEvent(List<Event> events) {

            try {
                if (events.Count > 0) {
                    foreach (var evt in events) {
                        string cardHtml = $@"
           <div class='card'>
    <img src='{evt.ImageUrl}' class='card-img-top' alt='Event Image'>
    <div class='card-body'>
        <h5 class='card-title'>{evt.EventName}</h5>
        <p class='card-text'>{evt.Venue}</p>
        <p class='card-text'>{evt.DateTime.ToString("MMMM dd, yyyy HH:mm")}</p>
    </div>
        <a href='BuyTicket.aspx?EventID={evt.EventID}' class='btn btn-primary'>Buy Tickets</a>

</div>
";
                        Literal cardLiteral = new Literal();
                        cardLiteral.Text = cardHtml;

                        CardContainer.Controls.Add(cardLiteral);
                    }
                } else {
                    string msg = "There is no any event at moment, Please try again later.";
                    helper.SendAlert(msg, this.GetType(), this.ClientScript);
                }
            } catch (Exception ex) {

                helper.SendAlert("Unable to fetch event data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);

            }

        }

    }
}

