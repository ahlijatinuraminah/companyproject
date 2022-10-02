using CompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProject.Controllers
{
    public class KaryawanController : Controller
    {
        // GET: Karyawan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(JqueryDataTableParam param)
        {
            try
            {
                
                using (DatabaseContext _context = new DatabaseContext())
                {
                    // Getting all data karyawan
                    var dataKaryawan = (from temp in _context.Karyawan
                                        select new
                                        {
                                            temp.Id,
                                            temp.Nama,
                                            temp.TanggalLahir,
                                            temp.JumlahAnak,                                            
                                            TanggalLahirString = SqlFunctions.DateName("day", temp.TanggalLahir) + " " + SqlFunctions.DateName("month", temp.TanggalLahir) + " " + SqlFunctions.DateName("year", temp.TanggalLahir),
                                            Umur = DateTime.Now.Year - temp.TanggalLahir.Year
                                        });



                    //Search    
                    if (!string.IsNullOrEmpty(param.sSearch))
                    {
                        dataKaryawan = dataKaryawan.Where(m => m.Nama.ToLower().Contains(param.sSearch.ToLower())
                                                    || m.TanggalLahirString.ToString().ToLower().Contains(param.sSearch.ToLower())
                                                    || m.JumlahAnak.ToString().Contains(param.sSearch)
                                                    || m.Umur.ToString().Contains(param.sSearch)
                        );
                    }

                    dataKaryawan = dataKaryawan.OrderBy(c => c.Id);                    
                    var displayResult = dataKaryawan.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
                    
                    var totalRecords = dataKaryawan.Count();
                    
                    
                    return Json(new
                    {
                        param.sEcho,
                        iTotalRecords = totalRecords,
                        iTotalDisplayRecords = totalRecords,
                        aaData = displayResult
                    }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    
    }
}