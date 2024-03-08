using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Settimana_18_Esercizio_Finale.Models;

namespace Settimana_18_Esercizio_Finale.Controllers
{
    public class HomeController : Controller
    {
        /*
            Pagina Index della Home, la pagina in cui tutto viene gestito
         */

        public ActionResult Index()
        {
            if (Session["Account"] == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        /*
            Pagina Login della Home
         */

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Dipendente d)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Dipendenti WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", d.Username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader.GetString(2) != d.Password)
                    {
                        ViewBag.Errore = "Password Sbagliata";
                        return View();
                    }
                    else
                    {
                        this.Session["Account"] = "true";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.Errore = "Username non trovato";
                    return View();
                }
            }
            catch
            {
                ViewBag.Errore = "Errore nella Login, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        /*
         
            Pagina Logout della Home, non si carica mai ma elimina l'account inserito
         
         */

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
