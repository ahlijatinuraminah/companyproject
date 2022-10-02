using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyProject.Models
{
    [Table("KendaraanPerusahaan")]
    public class KendaraanPerusahaan
    {
        [Key]
        public int? Id { get; set; }

        public string Tipe { get; set; }

        public string Warna { get; set; }

        [DataType(DataType.Date)]
        public DateTime TanggalBeli { get; set; }

        public int JumlahRoda { get; set; }
    }
}