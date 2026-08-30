using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    internal static class ClsAttivitaBL
    {
        private const string SELECT_BASE =
            @"SELECT ID, titolo, testo, ordine, dalle, alle, eventoID
              FROM attivita";
        

        private static ClsAttivita CreaAttivitaDaRiga(DataRow r)
        {
            ClsAttivita a = new ClsAttivita();
            a.ID1 = Convert.ToInt32(r["ID"]);
            a.Titolo = r["titolo"] == DBNull.Value ? "" : r["titolo"].ToString();
            a.Testo = r["testo"] == DBNull.Value ? "" : r["testo"].ToString();
            a.Ordine = r["ordine"] == DBNull.Value ? 0 : Convert.ToInt32(r["ordine"]);
            a.Dalle = r["dalle"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)r["dalle"];
            a.Alle = r["alle"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)r["alle"];
            a.EventoID = r["eventoID"] == DBNull.Value ? 0 : Convert.ToInt32(r["eventoID"]);
            return a;
        }

        #region CREATE
        internal static long Create(ref MySqlConnection conn, ClsAttivita attivita, out string errore)
        {
            long id = 0;
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string sql = @"INSERT INTO attivita (titolo, testo, ordine, dalle, alle, eventoID)
                               VALUES (@titolo, @testo, @ordine, @dalle, @alle, @eventoID)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@titolo", attivita.Titolo ?? "");
                cmd.Parameters.AddWithValue("@testo", attivita.Testo ?? "");
                cmd.Parameters.AddWithValue("@ordine", attivita.Ordine);
                cmd.Parameters.AddWithValue("@dalle", attivita.Dalle);
                cmd.Parameters.AddWithValue("@alle", attivita.Alle);
                cmd.Parameters.AddWithValue("@eventoID", attivita.EventoID);
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
        internal static List<ClsAttivita> GetAll(ref MySqlConnection conn, out string errore)
        {
            List<ClsAttivita> attivita = new List<ClsAttivita>();
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " ORDER BY eventoID, ordine", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    attivita.Add(CreaAttivitaDaRiga(dt.Rows[i]));

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return attivita;
        }

        internal static ClsAttivita GetByID(ref MySqlConnection conn, int id, out string errore)
        {
            ClsAttivita attivita = null;
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
                        attivita = CreaAttivitaDaRiga(dt.Rows[0]);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }

            }
            return attivita;
        }

        internal static List<ClsAttivita> GetByEventoID(ref MySqlConnection conn, int eventoID, out string errore)
        {
            List<ClsAttivita> attivita = new List<ClsAttivita>();
            errore = string.Empty;

            if (eventoID <= 0)
                errore = "EventoID non valido";
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE eventoID=@eventoID ORDER BY ordine", conn);
                    da.SelectCommand.Parameters.AddWithValue("@eventoID", eventoID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                        attivita.Add(CreaAttivitaDaRiga(dt.Rows[i]));

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
            return attivita;
        }
        #endregion

        #region UPDATE
        internal static int Update(ref MySqlConnection conn, int id, ClsAttivita attivita, out string errore)
        {
            int esito = 0;
            errore = string.Empty;

            if (id <= 0) { errore = "ID non valido"; return esito; }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string sql = @"UPDATE attivita SET
                                    titolo=@titolo,
                                    testo=@testo,
                                    ordine=@ordine,
                                    dalle=@dalle,
                                    alle=@alle,
                                    eventoID=@eventoID
                                WHERE ID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@titolo", attivita.Titolo ?? "");
                cmd.Parameters.AddWithValue("@testo", attivita.Testo ?? "");
                cmd.Parameters.AddWithValue("@ordine", attivita.Ordine);
                cmd.Parameters.AddWithValue("@dalle", attivita.Dalle);
                cmd.Parameters.AddWithValue("@alle", attivita.Alle);
                cmd.Parameters.AddWithValue("@eventoID", attivita.EventoID);
                esito = cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
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

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM attivita WHERE ID=@id", conn);
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

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM attivita", conn);
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

        internal static int CountByEventoID(ref MySqlConnection conn, int eventoID, out string errore)
        {
            int count = 0;
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM attivita WHERE eventoID=@eventoID", conn);
                cmd.Parameters.AddWithValue("@eventoID", eventoID);
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
    }
}