using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    internal static class ClsUtenteBL
    {
        private const string SELECT_BASE =
            @"SELECT ID, nome, cognome, username, password, matricola,
                     rappresentanteClasse, rappresentanteIstituto, ruolo, classeID
              FROM utenti";

        private static ClsUtente CreaUtenteDaRiga(DataRow r)
        {
            ClsUtente u = new ClsUtente();
            u.ID = Convert.ToInt32(r["ID"]);
            u.Nome = r["nome"] == DBNull.Value ? "" : r["nome"].ToString();
            u.Cognome = r["cognome"] == DBNull.Value ? "" : r["cognome"].ToString();
            u.Username = r["username"] == DBNull.Value ? "" : r["username"].ToString();
            u.Password = r["password"] == DBNull.Value ? "" : r["password"].ToString();
            u.Matricola = r["matricola"] == DBNull.Value ? "" : r["matricola"].ToString();
            u.RappresentanteClasse = r["rappresentanteClasse"] == DBNull.Value ? false : Convert.ToBoolean(r["rappresentanteClasse"]);
            u.RappresentanteIstituto = r["rappresentanteIstituto"] == DBNull.Value ? false : Convert.ToBoolean(r["rappresentanteIstituto"]);
            u.Ruolo = r["ruolo"] == DBNull.Value ? ' ' : Convert.ToChar(r["ruolo"]);
            u.ClasseID = r["classeID"] == DBNull.Value ? "" : r["classeID"].ToString();
            return u;
        }

        internal static void AssicuraAdminDefault(ref MySqlConnection conn, string username, string password, out string errore)
        {
            errore = string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errore = "Credenziali admin di default non valide";
                return;
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string queryUtente = "SELECT ID FROM utenti WHERE username=@username";
                MySqlCommand cmdSel = new MySqlCommand(queryUtente, conn);
                cmdSel.Parameters.AddWithValue("@username", username.Trim());
                object res = cmdSel.ExecuteScalar();

                if (res == null || res == DBNull.Value)
                {
                    string sql = @"INSERT INTO utenti
                                (nome, cognome, username, password, matricola,
                                 rappresentanteClasse, rappresentanteIstituto, ruolo, classeID)
                           VALUES
                                ('Admin', '', @username, @password, NULL,
                                 0, 0, 'A', NULL)";
                    MySqlCommand cmdIns = new MySqlCommand(sql, conn);
                    cmdIns.Parameters.AddWithValue("@username", username.Trim());
                    cmdIns.Parameters.AddWithValue("@password", password.Trim());
                    cmdIns.ExecuteNonQuery();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }
        }

        #region CREATE
        internal static long Create(ref MySqlConnection conn, ClsUtente utente, out string errore)
        {
            long id = 0;
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string sql = @"INSERT INTO utenti
                                    (nome, cognome, username, password, matricola,
                                     rappresentanteClasse, rappresentanteIstituto, ruolo, classeID)
                               VALUES
                                    (@nome, @cognome, @username, @password, @matricola,
                                     @rappresentanteClasse, @rappresentanteIstituto, @ruolo, @classeID)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", utente.Nome ?? "");
                cmd.Parameters.AddWithValue("@cognome", utente.Cognome ?? "");
                cmd.Parameters.AddWithValue("@username", utente.Username ?? "");
                cmd.Parameters.AddWithValue("@password", utente.Password ?? "");
                cmd.Parameters.AddWithValue("@matricola", utente.Matricola ?? "");
                cmd.Parameters.AddWithValue("@rappresentanteClasse", utente.RappresentanteClasse);
                cmd.Parameters.AddWithValue("@rappresentanteIstituto", utente.RappresentanteIstituto);
                cmd.Parameters.AddWithValue("@ruolo", utente.Ruolo);
                cmd.Parameters.AddWithValue("@classeID", string.IsNullOrEmpty(utente.ClasseID) ? (object)DBNull.Value : utente.ClasseID);
                cmd.ExecuteNonQuery();
                id = cmd.LastInsertedId;

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
                id = 0;
            }

            return id;
        }
        #endregion

        #region READ
        internal static List<ClsUtente> GetAll(ref MySqlConnection conn, out string errore)
        {
            List<ClsUtente> utenti = new List<ClsUtente>();
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " ORDER BY cognome, nome", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    utenti.Add(CreaUtenteDaRiga(dt.Rows[i]));

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return utenti;
        }
        internal static ClsUtente GetByMatricola(ref MySqlConnection conn, string matricola, out string errore)
        {
            ClsUtente utente = null;
            errore = string.Empty;

            if (string.IsNullOrEmpty(matricola))
                return null;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE matricola=@matricola LIMIT 1", conn);
                da.SelectCommand.Parameters.AddWithValue("@matricola", matricola);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                    utente = CreaUtenteDaRiga(dt.Rows[0]);

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return utente;
        }
        internal static ClsUtente GetByID(ref MySqlConnection conn, int id, out string errore)
        {
            ClsUtente utente = null;
            errore = string.Empty;

            if (id <= 0)
                errore = "ID non valido"; 
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE ID=@id LIMIT 1", conn);
                    da.SelectCommand.Parameters.AddWithValue("@id", id);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        utente = CreaUtenteDaRiga(dt.Rows[0]);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }

            }

            return utente;
        }

        internal static ClsUtente GetByUsername(ref MySqlConnection conn, string username, out string errore)
        {
            ClsUtente utente = null;
            errore = string.Empty;

            if (string.IsNullOrEmpty(username))
                errore = "Username non valido";
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE username=@username LIMIT 1", conn);
                    da.SelectCommand.Parameters.AddWithValue("@username", username);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        utente = CreaUtenteDaRiga(dt.Rows[0]);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
          

            return utente;
        }

        internal static List<ClsUtente> GetByClasseID(ref MySqlConnection conn, string classeID, out string errore)
        {
            List<ClsUtente> utenti = new List<ClsUtente>();
            errore = string.Empty;

            if (string.IsNullOrEmpty(classeID)) { errore = "ClasseID non valido"; return utenti; }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE classeID=@classeID ORDER BY cognome, nome", conn);
                da.SelectCommand.Parameters.AddWithValue("@classeID", classeID);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    utenti.Add(CreaUtenteDaRiga(dt.Rows[i]));

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return utenti;
        }

        internal static List<ClsUtente> GetByRuolo(ref MySqlConnection conn, char ruolo, out string errore)
        {
            List<ClsUtente> utenti = new List<ClsUtente>();
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE ruolo=@ruolo ORDER BY cognome, nome", conn);
                da.SelectCommand.Parameters.AddWithValue("@ruolo", ruolo);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    utenti.Add(CreaUtenteDaRiga(dt.Rows[i]));

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return utenti;
        }
        #endregion

        #region UPDATE
        internal static int Update(ref MySqlConnection conn, int id, ClsUtente utente, out string errore)
        {
            int esito = 0;
            errore = string.Empty;

            if (id <= 0)
                errore = "ID non valido";
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string sql = @"UPDATE utenti SET
                                    nome=@nome,
                                    cognome=@cognome,
                                    username=@username,
                                    matricola=@matricola,
                                    rappresentanteClasse=@rappresentanteClasse,
                                    rappresentanteIstituto=@rappresentanteIstituto,
                                    ruolo=@ruolo,
                                    classeID=@classeID
                                WHERE ID=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nome", utente.Nome ?? "");
                    cmd.Parameters.AddWithValue("@cognome", utente.Cognome ?? "");
                    cmd.Parameters.AddWithValue("@username", utente.Username ?? "");
                    cmd.Parameters.AddWithValue("@matricola", utente.Matricola ?? "");
                    cmd.Parameters.AddWithValue("@rappresentanteClasse", utente.RappresentanteClasse);
                    cmd.Parameters.AddWithValue("@rappresentanteIstituto", utente.RappresentanteIstituto);
                    cmd.Parameters.AddWithValue("@ruolo", utente.Ruolo);
                    cmd.Parameters.AddWithValue("@classeID", string.IsNullOrEmpty(utente.ClasseID) ? (object)DBNull.Value : utente.ClasseID);
                    esito = cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }

            }

            return esito;
        }

        internal static int UpdatePassword(ref MySqlConnection conn, int id, string nuovaPassword, out string errore)
        {
            int esito = 0;
            errore = string.Empty;

            if (id <= 0)
                errore = "ID non valido";
            else
            {
                if (string.IsNullOrEmpty(nuovaPassword))
                    errore = "Password non valida";
                else
                {
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        MySqlCommand cmd = new MySqlCommand("UPDATE utenti SET password=@password WHERE ID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@password", nuovaPassword);
                        esito = cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        errore = ex.Message;
                    }
                }
            }
            return esito;
        }
        #endregion

        #region DELETE
        internal static int Delete(ref MySqlConnection conn, int id, out string errore)
        {
            int esito = 0;
            errore = string.Empty;

            if (id <= 0)
                errore = "ID non valido";
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM utenti WHERE ID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    esito = cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }

            }
            return esito;
        }
        #endregion

        #region COUNT
        internal static int Count(ref MySqlConnection conn, out string errore)
        {
            int count = 0;
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM utenti", conn);
                if (cmd.ExecuteScalar() != null)
                    count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return count;
        }
        #endregion

        #region ALTRO
        internal static ClsUtente Login(ref MySqlConnection conn, string username, string password, out string errore)
        {
            ClsUtente utente = null;
            errore = string.Empty;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                errore = "Credenziali non valide";
                return utente;
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(
                    SELECT_BASE + " WHERE username=@username AND password=@password LIMIT 1", conn);
                da.SelectCommand.Parameters.AddWithValue("@username", username);
                da.SelectCommand.Parameters.AddWithValue("@password", password);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                    utente = CreaUtenteDaRiga(dt.Rows[0]);
                else
                    errore = "Username o password errati";

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return utente;
        }
        #endregion
    }
}