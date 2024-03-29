﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using RestaurantReserv.Models;

namespace RestaurantReserv.Controllers
{
    public class ReservationController : Controller
    {
        private SpicyRestaurantEntities db = new SpicyRestaurantEntities();
        // GET: Reservation
        public ActionResult Index()
        {
            ViewBag.General = db.Generals.First();
            ViewBag.OpeningHours = db.OpeningHours.ToList();
            return View();
        }

        public ActionResult Message(Reservation rsv)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("p103ca@gmail.com");
            mail.From = new MailAddress(rsv.Email);
            mail.Subject = "Resrvation Message | ";
            string Body = "Name : " + rsv.Name + " <br> Email : " + rsv.Email + " <br> Phone : " + rsv.Phone + " <br> People-Number : " + rsv.PeopleNumber + " <br> Time : " + rsv.Time + " <br> Date : " + rsv.Date + " <br> Message : " + rsv.SpecialRequest;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("p103ca@gmail.com", "P103_2017"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);
            Session["mailSended"] = true;
            db.Reservations.Add(rsv);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}