using CompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProject.Controllers
{
    public class KendaraanPerusahaanController : Controller
    {
        // GET: KendaraanPerusahaan
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
                    // Getting all data kendaraab
                    var dataKendaraan = (from temp in _context.KendaraanPerusahaan
                                        select new
                                        {
                                            temp.Id,
                                            temp.Tipe,
                                            temp.Warna,
                                            temp.JumlahRoda,
                                            TanggalBeliString = SqlFunctions.DateName("day", temp.TanggalBeli) + " " + SqlFunctions.DateName("month", temp.TanggalBeli) + " " + SqlFunctions.DateName("year", temp.TanggalBeli)                                           
                                        });



                    //Search    
                    if (!string.IsNullOrEmpty(param.sSearch))
                    {
                        dataKendaraan = dataKendaraan.Where(m => m.Tipe.ToLower().Contains(param.sSearch.ToLower())
                                                    || m.Warna.ToLower().Contains(param.sSearch.ToLower())
                                                    || m.TanggalBeliString.ToString().ToLower().Contains(param.sSearch.ToLower())
                                                    || m.JumlahRoda.ToString().Contains(param.sSearch)
                                                    
                        );
                    }

                    dataKendaraan = dataKendaraan.OrderBy(c => c.Id);
                    var displayResult = dataKendaraan.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

                    var totalRecords = dataKendaraan.Count();


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

        public ActionResult GetDataTipe()
        {
            try
            {

                using (DatabaseContext _context = new DatabaseContext())
                {
                    // Getting all data kendaraab
                    var dataTipe = (from temp in _context.KendaraanPerusahaan
                                    select new
                                    {
                                        temp.Tipe
                                    }).ToList().Distinct();
                                         



                    return Json(dataTipe);

                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}