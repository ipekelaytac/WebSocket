using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace websocket.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult ws()
        {
            string exchangeRate = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(exchangeRate);
            string usd = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='USD'] / BanknoteSelling").InnerXml;
            string aud = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='AUD'] / BanknoteSelling").InnerXml;
            string eur = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='EUR'] / BanknoteSelling").InnerXml;
            string chf = xmlDoc.SelectSingleNode("Tarih_Date / Currency[@Kod ='CHF'] / BanknoteSelling").InnerXml;
            ViewBag.usd = usd;
            ViewBag.aud = aud;
            ViewBag.eur = eur;
            ViewBag.chf = chf;
            return View();
        }
    }
}