using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PRUEBAS_LOGIN.Models;
using PRUEBAS_LOGIN.Permisos;

namespace PRUEBAS_LOGIN.Controllers
{


    [ValidarSesion]
    public class HomeController : Controller



   public static string cadena = @"Data Source=TOYYODABD.mssql.somee.com;Initial Catalog=TOYYODABD;User ID=ragcorp_SQLLogin_2;Password=msuzuk1rjq;Persist Security Info=False;";
    public static pais cMain;

    {
        public ActionResult Index()
        {

            pais c = new pais();
            cMain = new pais();
            c.pais = cMain.pais = FillList();
            ViewBag.LblCountry = "";
            return View();
        }

    [HttpPost]
    public ActionResult Index(Countries country)
    {
        var g = cMain.countries;
        var selectedCountry = g.Find(p => p.Value == country.id.ToString());
        country.countries = FillList();
        ViewBag.LblCountry = "You selected " + selectedCountry.Text.ToString();
        return View(country);
    }

    public List<SelectListItem> FillList()
    {
        var list = new List<SelectListItem>();
        try
        {
            using (SqlConnection c = new SqlConnection(cadena))
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("select * from tblCountries", c);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        list.Add(new SelectListItem { Text = reader["Country"].ToString(), Value = reader["Id"].ToString() });
                    }
                }
                else
                {
                    list.Add(new SelectListItem { Text = "No records found", Value = "0" });
                }

                c.Close();
            }
        }
        catch (Exception ex)
        {
            list.Add(new SelectListItem { Text = ex.Message.ToString(), Value = "0" });
        }

        return list;
    }
}
}



        public ActionResult About()
        {
            ViewBag.Message = "TOY YODA.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sucursales.";

            return View();
        }
        
        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("Login", "Acceso");
        }




    }
}