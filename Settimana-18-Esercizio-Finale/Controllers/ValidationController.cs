using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Settimana_18_Esercizio_Finale.Models;

namespace Settimana_18_Esercizio_Finale.Controllers
{
    public class ValidationController : Controller
    {
        /*
            controllo che verifica che la tipologia abbia un valore valido, cioè "singola" o "doppia"
         */
        public ActionResult CheckTipologiaCamera(string tipologia)
        {
            if (tipologia == "singola" || tipologia == "doppia")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        /*
            controllo che verifica che l'IdPrenotaizone abbia un valore valido, cioè già esistente
         */

        public ActionResult CheckIdPrenotazione(int IdPrenotazione)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Prenotazioni WHERE IdPrenotazione = @IdPrenotazione";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdPrenotazione", IdPrenotazione);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                conn.Close();
            }
        }

        /*
            controllo che verifica che il tipo servizio abbia un valore valido, cioè "Colazione a Letto", "Minibar", "Internet", "Letto Aggiuntivo" o "Culla"
         */

        public ActionResult CheckTipoServizio(string tipo)
        {
            if (
                tipo == "Colazione a Letto"
                || tipo == "Minibar"
                || tipo == "Internet"
                || tipo == "Letto Aggiuntivo"
                || tipo == "Culla"
            )
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        /*
            controllo che verifica che l'IdCliente abbia un valore valido, cioè già esistente
         */

        public ActionResult CheckIdCliente(int IdCliente)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Clienti WHERE IdCliente = @IdCliente";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                conn.Close();
            }
        }

        /*
            controllo che verifica che l'IdCamera abbia un valore valido, cioè già esistente
         */

        public ActionResult CheckIdCamera(int IdCamera)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Camere WHERE IdCamera = @IdCamera";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCamera", IdCamera);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                conn.Close();
            }
        }

        /*
            controllo che verifica che il Codice Fiscale abbia un valore valido, cioè non ancora inserito
         */

        public ActionResult CheckCF(string CF)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Clienti WHERE CF = @CF";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CF", CF);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                conn.Close();
            }
        }

        /*
            controllo che verifica che il tipo servizio abbia un valore valido, cioè "Mezza Pensione", "Pensione Completa", "Pernottamento con prima colazione"
         */

        public ActionResult CheckTipoPrenotazione(string tipo)
        {
            if (
                tipo == "Mezza Pensione"
                || tipo == "Pensione Completa"
                || tipo == "Pernottamento con prima colazione"
            )
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        /*
            controllo che verifica che il Numero della Prenotazione abbia un valore valido, cioè già esistente
         */

        public ActionResult CheckNumeroPrenotazione(int Numero_Prenotazione)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "SELECT * FROM Prenotazioni WHERE Numero_Prenotazione = @Numero_Prenotazione";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Numero_Prenotazione", Numero_Prenotazione);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
