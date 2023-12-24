using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModelAoto.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public char SerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Sender { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Reciepent { get; set; }
        public bool Status { get; set; }


        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }
}