using ModelAoto.Models.Contexts;
using ModelAoto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelAoto.Controllers
{
    public class InvoicesController : Controller
    {
        ModelAotoDbContext db = new ModelAotoDbContext();

        public ActionResult Index()
        {
            var invoices = db.Invoices.ToList();

            return View(invoices);
        }
        [HttpGet]
        public ActionResult Add()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Add(Invoice invoice)
        {
            db.Invoices.Add(invoice);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var invoice = db.Invoices.Find(id);

            return View(invoice);
        }

        [HttpPost]
        public ActionResult Update(Invoice invoice)
        {
            var invoiceToUpdate = db.Invoices.Find(invoice.Id);

            invoiceToUpdate.SerialNumber = invoice.SerialNumber;
            invoiceToUpdate.InvoiceNo = invoice.InvoiceNo;
            invoiceToUpdate.Date=invoice.Date; 
            invoiceToUpdate.Time=invoice.Time;
            invoiceToUpdate.TaxOffice = invoice.TaxOffice;
            invoiceToUpdate.Sender=invoice.Sender;
            invoiceToUpdate.Reciepent=invoice.Reciepent;

            
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        public ActionResult Details(int id)
        {
            var details = db.InvoiceDetails.Where(x => x.Id == id).ToList();


            return View(details);
        }

        [HttpGet]
        public ActionResult NewEntry(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewEntry(InvoiceDetail invoiceDetail)
        {
            db.InvoiceDetails.Add(invoiceDetail);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}