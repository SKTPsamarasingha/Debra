using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Debra_service.Models;
using Debra_service.DB_Layer;
namespace Debra_service.App_Logic {
    public class EventLogic {
        public bool CreateEvent(int partnerid, string eventName, string venue, string imgUrl, DateTime dateTime) {
            Event newEvent = new Event();

            newEvent.PartnerID = partnerid;
            newEvent.EventName = eventName;
            newEvent.Venue = venue;
            newEvent.ImageUrl = imgUrl;
            newEvent.DateTime = dateTime;

            bool result = new EventDataLogic().CreateEvent(newEvent);

            return result;
        }


        public List<Event> GetAllEvents() {
            List<Event> eventList = new EventDataLogic().GetAllEvents();
            return eventList;
        }
        public List<Event> GetPartnersEvents(int partnerid) {
            List<Event> eventList = new EventDataLogic().GetPartnersEvents(partnerid);
            return eventList;
        }

        public List<Event> GetEventByID(int eventID) {

            List<Event> List = new EventDataLogic().GetEventByID(eventID);
            return List;

        }

        public List<Event> GetEventByStatus(bool status) {


            List<Event> eventList = new EventDataLogic().GetEventByStatus(status);

            return eventList;
        }




        public bool DeleteEvent(int eventid) {

            bool result = new EventDataLogic().DeleteEvent(eventid);

            return result;

        }

        public bool UpdateEvent(int eventid, string eventname, string venue, string imageurl, DateTime dateTime) {

            Event updateEvent = new Event();

            updateEvent.EventID = eventid;
            updateEvent.EventName = eventname;
            updateEvent.Venue = venue;
            updateEvent.ImageUrl = imageurl;
            updateEvent.DateTime = dateTime;


            bool result = new EventDataLogic().UpdateEvent(updateEvent);

            return result;

        }



        // Employee logics

        public bool AccepteEvent(int eventid, bool isaccepted, decimal cocommission) {

            Event accepteEvent = new Event();
            accepteEvent.EventID = eventid;
            accepteEvent.IsAccepted = isaccepted;
            accepteEvent.Commission = cocommission;

            bool result = new EventDataLogic().AccepteEvent(accepteEvent);
            return result;
        }

        public List<Event> GetNewEvents() {

            List<Event> events = new EventDataLogic().GetNewEvents();
            return events;
        }

        public List<Event> GetPurchase(int CustomreID) {
            List<Event> events = new EventDataLogic().GetPurchase(CustomreID);
            return events;
        }

    }


}