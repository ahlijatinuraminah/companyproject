using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyProject.Models
{
    [Table("Karyawan")]
    public class Karyawan
    {
        [Key]
        public int? Id { get; set; }

        public string Nama { get; set; }

        [DataType(DataType.Date)]
        public DateTime TanggalLahir { get; set; }

        public int JumlahAnak { get; set; }
    }
}