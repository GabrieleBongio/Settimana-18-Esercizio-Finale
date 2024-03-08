using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Settimana_18_Esercizio_Finale.Models;

namespace Settimana_18_Esercizio_Finale.Controllers
{
    public class InternalController : Controller
    {
        /*
            ActionResult che permette di creare un nuovo cliente, per accedere si deve essere loggati
         */
        public ActionResult NuovoCliente()
        {
            if (Session["Account"] == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult NuovoCliente(Cliente c)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Clienti (CF, Cognome, Nome, Città, Provincia, Email, Telefono, Cellulare) VALUES (@CF, @Cognome, @Nome, @Città, @Provincia, @Email, @Telefono, @Cellulare)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CF", c.CF);
                cmd.Parameters.AddWithValue("@Cognome", c.Cognome);
                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@Città", c.Città);
                cmd.Parameters.AddWithValue("@Provincia", c.Provincia);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@Cellulare", c.Cellulare);
                cmd.ExecuteNonQuery();

                TempData["Info"] = "Cliente inserito con successo";
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.Errore = "Errore nell'inserimento del cliente, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        public ActionResult NuovaCamera()
        {
            if (Session["Account"] == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        /*
            ActionResult che permette di creare una nuova camera, per accedere si deve essere loggati
         */

        [HttpPost]
        public ActionResult NuovaCamera(Camera c)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Camere (Numero, Descrizione, Tipologia) VALUES (@Numero, @Descrizione, @Tipologia)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Numero", c.Numero);
                cmd.Parameters.AddWithValue("@Descrizione", c.Descrizione);
                cmd.Parameters.AddWithValue("@Tipologia", c.Tipologia);
                cmd.ExecuteNonQuery();

                TempData["Info"] = "Camera inserita con successo";
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.Errore = "Errore nell'inserimento della camera, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        /*
            ActionResult che permette di creare un nuovo dipendente, per accedere si deve essere loggati
         */

        public ActionResult NuovoDipendente()
        {
            if (Session["Account"] == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult NuovoDipendente(Dipendente d)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Dipendenti (Username, Password) VALUES (@Username, @Password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", d.Username);
                cmd.Parameters.AddWithValue("@Password", d.Password);
                cmd.ExecuteNonQuery();

                TempData["Info"] = "Dipendente inserito con successo";
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.Errore = "Errore nell'inserimento del dipendente, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        /*
            ActionResult che permette di creare una nuova prenotazione, per accedere si deve essere loggati
         */

        public ActionResult NuovaPrenotazione()
        {
            if (Session["Account"] == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult NuovaPrenotazione(Prenotazione p)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Prenotazioni (IdCliente, IdCamera, Data_Prenotazione, Numero_Prenotazione, Anno, Inizio_Soggiorno, Fine_Soggiorno, Caparra, Tariffa, Tipo) VALUES (@IdCliente, @IdCamera, @Data_Prenotazione, @Numero_Prenotazione, @Anno, @Inizio_Soggiorno, @Fine_Soggiorno, @Caparra, @Tariffa, @Tipo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCamera", p.IdCamera);
                cmd.Parameters.AddWithValue("@IdCliente", p.IdCliente);
                cmd.Parameters.AddWithValue("@Data_Prenotazione", DateTime.Now);
                cmd.Parameters.AddWithValue(
                    "@Numero_Prenotazione",
                    ProssimoNumeroPrenotazione(DateTime.Now.Year.ToString())
                );
                cmd.Parameters.AddWithValue("@Anno", DateTime.Now.Year.ToString());
                cmd.Parameters.AddWithValue("@Inizio_Soggiorno", p.Inizio_Soggiorno);
                cmd.Parameters.AddWithValue("@Fine_Soggiorno", p.Fine_Soggiorno);
                cmd.Parameters.AddWithValue(
                    "@Caparra",
                    Caparra(p.Tipo, p.Inizio_Soggiorno, p.Fine_Soggiorno)
                );
                cmd.Parameters.AddWithValue(
                    "@Tariffa",
                    Tariffa(p.Tipo, p.Inizio_Soggiorno, p.Fine_Soggiorno)
                );
                cmd.Parameters.AddWithValue("@Tipo", p.Tipo);
                cmd.ExecuteNonQuery();

                TempData["Info"] = "Prenotaizone inserita con successo";
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.Errore = "Errore nell'inserimento della prenotazione, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        /*
          funzione che permette di calcolare la caparra di una prenotazione prima di caricarla nel database
         */

        public double Caparra(string Tipo, DateTime Inizio_Soggiorno, DateTime Fine_Soggiorno)
        {
            int prezzoBase = 0;

            switch (Tipo)
            {
                case "Mezza Pensione":
                    prezzoBase = 10;
                    break;
                case "Pensione Completa":
                    prezzoBase = 14;
                    break;
                case "Pernottamento con prima colazione":
                    prezzoBase = 7;
                    break;
            }

            TimeSpan differenza = Fine_Soggiorno.Subtract(Inizio_Soggiorno);

            int NumeroNotti = differenza.Days;

            return (prezzoBase * NumeroNotti) + 5;
        }

        /*
          funzione che permette di calcolare la tariffa di una prenotazione prima di caricarla nel database
         */

        public double Tariffa(string Tipo, DateTime Inizio_Soggiorno, DateTime Fine_Soggiorno)
        {
            int prezzoBase = 0;

            switch (Tipo)
            {
                case "Mezza Pensione":
                    prezzoBase = 60;
                    break;
                case "Pensione Completa":
                    prezzoBase = 90;
                    break;
                case "Pernottamento con prima colazione":
                    prezzoBase = 45;
                    break;
            }

            TimeSpan differenza = Fine_Soggiorno.Subtract(Inizio_Soggiorno);

            int NumeroNotti = differenza.Days;

            return (prezzoBase * NumeroNotti) - 1;
        }

        /*
          funzione che permette di calcolare il prossimo numero libero per una prenotazione prima di caricarla nel database
         */

        public int ProssimoNumeroPrenotazione(string Anno)
        {
            int result = 1;

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Prenotazioni WHERE Anno = @Anno";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Anno", Anno);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    if (r.GetInt32(4) > result)
                    {
                        result = r.GetInt32(4);
                    }
                }

                return result + 1;
            }
            catch
            {
                ViewBag.Errore = "Errore nell'inserimento della prenotazione, riprova";
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        /*
            ActionResult che permette di creare un nuovo servizio, per accedere si deve essere loggati
         */

        public ActionResult NuovoServizio()
        {
            if (Session["Account"] == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult NuovoServizio(Servizio s)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Servizi (IdPrenotazione, Tipo, Data, Quantità, Prezzo) VALUES (@IdPrenotazione, @Tipo, @Data, @Quantità, @Prezzo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdPrenotazione", s.IdPrenotazione);
                cmd.Parameters.AddWithValue("@Tipo", s.Tipo);
                cmd.Parameters.AddWithValue("@Data", s.Data);
                cmd.Parameters.AddWithValue("@Quantità", s.Quantità);
                cmd.Parameters.AddWithValue("@Prezzo", Prezzo(s.Tipo, s.Quantità));
                cmd.ExecuteNonQuery();

                TempData["Info"] = "Servizio inserito con successo";
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.Errore = "Errore nell'inserimento del servizio, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        /*
          funzione che permette di calcolare il prezzo di un servizio prima di caricarlo nel database
         */

        public double Prezzo(string Tipo, int Quantità)
        {
            double prezzoBase = 0;

            switch (Tipo)
            {
                case "Colazione in Camera":
                    prezzoBase = 9.5;
                    break;
                case "Minibar":
                    prezzoBase = 3;
                    break;
                case "Internet":
                    prezzoBase = 6.5;
                    break;
                case "Letto Aggiuntivo":
                    prezzoBase = 8.5;
                    break;
                case "Culla":
                    prezzoBase = 7;
                    break;
            }

            return prezzoBase * Quantità;
        }

        /*
            ActionResult che permette di ricercare una prenotazione tramite Codice Fiscale e Numero di Prenotazione, solo se entrambi sono collegati si apre la pagina effettivamente
         */

        public ActionResult Checkout()
        {
            if (Session["Account"] == "true")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult Checkout(RicercaPrenotazione r)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "SELECT * FROM Prenotazioni INNER JOIN Clienti ON Clienti.IdCliente = Prenotazioni.IdCliente WHERE CF = @CF AND Numero_Prenotazione = @Numero_Prenotazione";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CF", r.CF);
                cmd.Parameters.AddWithValue("@Numero_Prenotazione", r.Numero_Prenotazione);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TempData["IdPrenotazione"] = reader.GetInt32(1);
                    return RedirectToAction("DettagliPrenotazione");
                }
                else
                {
                    ViewBag.Errore = "Nessuna prenotazione con questi dati";
                    return View();
                }
            }
            catch
            {
                ViewBag.Errore = "Errore nella ricerca della prenotazione, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        /*
            ActionResult che mostra i dettagli della prenotazione, vi si accede dalla pagina precedente se la prenotazione è stata trovata
         */

        public ActionResult DettagliPrenotazione()
        {
            if (Session["Account"] == "true")
            {
                if (TempData.ContainsKey("IdPrenotazione"))
                {
                    double prezzoTotale = 0;

                    int IdPrenotazione = Convert.ToInt32(TempData["IdPrenotazione"]);

                    string connString = ConfigurationManager
                        .ConnectionStrings["myConnection"]
                        .ConnectionString.ToString();
                    SqlConnection conn = new SqlConnection(connString);

                    try
                    {
                        conn.Open();
                        string query =
                            "SELECT Numero, Inizio_Soggiorno, Fine_Soggiorno, Caparra, Tariffa FROM Prenotazioni INNER JOIN Camere ON Prenotazioni.IdCamera = Camere.IdCamera WHERE IdPrenotazione = @IdPrenotazione";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@IdPrenotazione", IdPrenotazione);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            TempData["NumeroStanza"] = reader.GetInt32(0);
                            TempData["Inizio_Soggiorno"] = reader.GetDateTime(1);
                            TempData["Fine_Soggiorno"] = reader.GetDateTime(2);
                            TempData["Tariffa"] = reader.GetSqlMoney(4).ToDouble();
                            TempData["Caparra"] = reader.GetSqlMoney(3).ToDouble();

                            prezzoTotale =
                                reader.GetSqlMoney(4).ToDouble() - reader.GetSqlMoney(3).ToDouble();
                        }
                    }
                    catch
                    {
                        ViewBag.Errore = "Errore nella ricerca della prenotazione, riprova";
                        return View();
                    }
                    finally
                    {
                        conn.Close();
                    }

                    List<Servizio> listaServizi = new List<Servizio>();

                    try
                    {
                        conn.Open();
                        string query =
                            "SELECT * FROM Servizi WHERE IdPrenotazione = @IdPrenotazione";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@IdPrenotazione", IdPrenotazione);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            listaServizi.Add(
                                new Servizio(
                                    reader.GetInt32(0),
                                    reader.GetInt32(1),
                                    reader.GetString(2),
                                    reader.GetDateTime(3),
                                    reader.GetInt32(4),
                                    reader.GetSqlMoney(5).ToDouble()
                                )
                            );

                            prezzoTotale += reader.GetSqlMoney(5).ToDouble();
                        }
                    }
                    catch
                    {
                        ViewBag.Errore = "Errore nella ricerca dei servizi, riprova";
                        return View();
                    }
                    finally
                    {
                        conn.Close();
                    }

                    TempData["importo"] = prezzoTotale;

                    return View(listaServizi);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}
