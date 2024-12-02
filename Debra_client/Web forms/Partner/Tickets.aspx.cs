using Debra_client.aspx;
using Debra_client.PartnerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.Web_forms.Partner {
    public partial class Tickets : System.Web.UI.Page {

        PartnerServiceSoapClient Partner_service = new PartnerServiceSoapClient();
        Helper helper = new Helper();

        int EventID;
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                try {
                    EventID = helper.GetURlID(Request.QueryString["EventID"], Request);

                    var ticketsRslt = EventID != 0 ? Partner_service.GetEventTicket(EventID) : null;
                    rptTickets.DataSource = ticketsRslt;
                    rptTickets.DataBind();
                } catch (Exception ex) {
                    helper.SendAlert("Unable to fetch Ticket data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);

                }



            }
        }


        protected void AddTicket_Click(object sender, EventArgs e) {
            EventID = helper.GetURlID(Request.QueryString["EventID"], Request);

            if (EventID != -1) Response.Redirect("CreateTicket.aspx?EventID=" + EventID);
        }


        protected void btnUpdateTicket_Click(object sender, EventArgs e) {
            try {
                string redirectStr = "";

                EventID = helper.GetURlID(Request.QueryString["EventID"], Request);

                Button btnUpdate = (Button)sender;
                int TicketID = Convert.ToInt32(btnUpdate.CommandArgument);
                ViewState["TicketID"] = TicketID;

                redirectStr = EventID != -1 && TicketID != 0 ? "UpdateTicket.aspx?EventID=" + EventID + "&TicketID=" + TicketID : "";

                if (redirectStr != "") Response.Redirect(redirectStr);
                else helper.SendAlert(TicketID.ToString() + EventID.ToString(), this.GetType(), this.ClientScript);

            } catch (Exception ex) {
                helper.SendAlert("Unable to fetch tickets data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }
        }
        protected void btnDeleteTicket_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int ticketID = int.Parse(btn.CommandArgument);
            string message = "";
            try {

                bool result = Partner_service.DeleteTicket(ticketID);
                message = result ? "Ticket Delete successfully" : "Sorry Faild to Delete Ticket";
                helper.SendAlert(message, this.GetType(), this.ClientScript);
                Response.Redirect(Request.RawUrl);

            } catch (Exception ex) {
                helper.SendAlert("Unable to fetch tickets data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }
        }





    }
}