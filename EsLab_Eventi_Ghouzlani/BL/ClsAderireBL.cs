using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    internal static class ClsAderireBL
    {
        private const string SELECT_BASE =
            @"SELECT IDaderire, iscritto, autorizzato, pagato, partecipato,
                     attivitaID, classeID, studenteID
              FROM aderire";

        private static ClsAderire CreaAderireDaRiga(DataRow r)
        {
            ClsAderire a = new ClsAderire();
            a.IDaderire = Convert.ToInt32(r["IDaderire"]);
            a.Iscritto = r["iscritto"] == DBNull.Value ? false : Convert.ToBoolean(r["iscritto"]);
            a.Autorizzato = r["autorizzato"] == DBNull.Value ? false : Convert.ToBoolean(r["autorizzato"]);
            a.Pagato = r["pagato"] == DBNull.Value ? false : Convert.ToBoolean(r["pagato"]);
            a.Partecipato = r["partecipato"] == DBNull.Value ? false : Convert.ToBoolean(r["partecipato"]);
            a.AttivitaID = r["attivitaID"] == DBNull.Value ? 0 : Convert.ToInt32(r["attivitaID"]);
            a.ClasseID = r["classeID"] == DBNull.Value ? "" : r["classeID"].ToString();
            a.StudenteID = r["studenteID"] == DBNull.Value ? 0 : Convert.ToInt32(r["studenteID"]);
            return a;
        }

        #region CREATE
        internal static long Create(ref MySqlConnection conn, ClsAderire aderire, out string errore)
        {
            long id = 0;
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string sql = @"INSERT INTO aderire
                                    (iscritto, autorizzato, pagato, partecipato, attivitaID, classeID, studenteID)
                               VALUES
                                    (@iscritto, @autorizzato, @pagato, @partecipato, @attivitaID, @classeID, @studenteID)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@iscritto", aderire.Iscritto);
                cmd.Parameters.AddWithValue("@autorizzato", aderire.Autorizzato);
                cmd.Parameters.AddWithValue("@pagato", aderire.Pagato);
                cmd.Parameters.AddWithValue("@partecipato", aderire.Partecipato);
                cmd.Parameters.AddWithValue("@attivitaID", aderire.AttivitaID);
                cmd.Parameters.AddWithValue("@classeID", (object)aderire.ClasseID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@studenteID", aderire.StudenteID > 0 ? (object)aderire.StudenteID : DBNull.Value);
                cmd.ExecuteNonQuery();
                id = cmd.LastInsertedId;

                conn.Close();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                errore = "Adesione già presente per questa attività/classe/studente.";
                id = 0;
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
        internal static List<ClsAderire> GetAll(ref MySqlConnection conn, out string errore)
        {
            List<ClsAderire> adesioni = new List<ClsAderire>();
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    adesioni.Add(CreaAderireDaRiga(dt.Rows[i]));

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return adesioni;
        }

        internal static ClsAderire GetByID(ref MySqlConnection conn, int id, out string errore)
        {
            ClsAderire aderire = null;
            errore = string.Empty;

            if (id <= 0)
                errore = "ID non valido";
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE IDaderire=@id LIMIT 1", conn);
                    da.SelectCommand.Parameters.AddWithValue("@id", id);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        aderire = CreaAderireDaRiga(dt.Rows[0]);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
            return aderire;
        }

        internal static List<ClsAderire> GetByAttivitaID(ref MySqlConnection conn, int attivitaID, out string errore)
        {
            List<ClsAderire> adesioni = new List<ClsAderire>();
            errore = string.Empty;

            if (attivitaID <= 0)
                errore = "AttivitaID non valido";
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE attivitaID=@attivitaID", conn);
                    da.SelectCommand.Parameters.AddWithValue("@attivitaID", attivitaID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                        adesioni.Add(CreaAderireDaRiga(dt.Rows[i]));

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
            
            return adesioni;
        }

        internal static List<ClsAderire> GetByStudenteID(ref MySqlConnection conn, int studenteID, out string errore)
        {
            List<ClsAderire> adesioni = new List<ClsAderire>();
            errore = string.Empty;

            if (studenteID <= 0)
                errore = "StudenteID non valido";
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE studenteID=@studenteID", conn);
                    da.SelectCommand.Parameters.AddWithValue("@studenteID", studenteID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                        adesioni.Add(CreaAderireDaRiga(dt.Rows[i]));

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
            return adesioni;
        }

        internal static List<ClsAderire> GetByClasseID(ref MySqlConnection conn, string classeID, out string errore)
        {
            List<ClsAderire> adesioni = new List<ClsAderire>();
            errore = string.Empty;

            if (string.IsNullOrEmpty(classeID))
                errore = "ClasseID non valido";
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE classeID=@classeID", conn);
                    da.SelectCommand.Parameters.AddWithValue("@classeID", classeID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                        adesioni.Add(CreaAderireDaRiga(dt.Rows[i]));

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }

            }
            return adesioni;
        }

        internal static ClsAderire GetByAttivitaIDeStudenteID(ref MySqlConnection conn, int attivitaID, int studenteID, out string errore)
        {
            ClsAderire aderire = null;
            errore = string.Empty;

            if (attivitaID <= 0 || studenteID <= 0)
                errore = "Parametri non validi"; 
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(
                        SELECT_BASE + " WHERE attivitaID=@attivitaID AND studenteID=@studenteID LIMIT 1", conn);
                    da.SelectCommand.Parameters.AddWithValue("@attivitaID", attivitaID);
                    da.SelectCommand.Parameters.AddWithValue("@studenteID", studenteID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        aderire = CreaAderireDaRiga(dt.Rows[0]);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }

            return aderire;
        }
        #endregion

        #region UPDATE
        internal static int Update(ref MySqlConnection conn, int id, ClsAderire aderire, out string errore)
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

                    string sql = @"UPDATE aderire SET
                                    iscritto=@iscritto,
                                    autorizzato=@autorizzato,
                                    pagato=@pagato,
                                    partecipato=@partecipato,
                                    attivitaID=@attivitaID,
                                    classeID=@classeID,
                                    studenteID=@studenteID
                                WHERE IDaderire=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@iscritto", aderire.Iscritto);
                    cmd.Parameters.AddWithValue("@autorizzato", aderire.Autorizzato);
                    cmd.Parameters.AddWithValue("@pagato", aderire.Pagato);
                    cmd.Parameters.AddWithValue("@partecipato", aderire.Partecipato);
                    cmd.Parameters.AddWithValue("@attivitaID", aderire.AttivitaID);
                    cmd.Parameters.AddWithValue("@classeID", (object)aderire.ClasseID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@studenteID", aderire.StudenteID > 0 ? (object)aderire.StudenteID : DBNull.Value);
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

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM aderire WHERE IDaderire=@id", conn);
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

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM aderire", conn);
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

        internal static int CountByAttivitaID(ref MySqlConnection conn, int attivitaID, out string errore)
        {
            int count = 0;
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM aderire WHERE attivitaID=@attivitaID", conn);
                cmd.Parameters.AddWithValue("@attivitaID", attivitaID);
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