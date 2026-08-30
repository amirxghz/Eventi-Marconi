using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    internal static class ClsEventoBL
    {
        private const string SELECT_BASE =
            @"SELECT ID, nome, descrizione, dal, al, adminID
              FROM eventi";

        private static ClsEvento CreaEventoDaRiga(DataRow r)
        {
            ClsEvento e = new ClsEvento();
            e.ID1 = Convert.ToInt32(r["ID"]);
            e.Nome = r["nome"] == DBNull.Value ? "" : r["nome"].ToString();
            e.Descrizione = r["descrizione"] == DBNull.Value ? "" : r["descrizione"].ToString();
            if (r["dal"] != DBNull.Value)
                e.Dal = Convert.ToDateTime(r["dal"]);
            if (r["al"] != DBNull.Value)
                e.Al = Convert.ToDateTime(r["al"]);
            e.AdminID = r["adminID"] == DBNull.Value ? 0 : Convert.ToInt32(r["adminID"]);
            return e;
        }

        #region CREATE
        internal static long Create(ref MySqlConnection conn, ClsEvento evento, out string errore)
        {
            long id = 0;
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string sql = @"INSERT INTO eventi (nome, descrizione, dal, al, adminID)
                               VALUES (@nome, @descrizione, @dal, @al, @adminID)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", evento.Nome ?? "");
                cmd.Parameters.AddWithValue("@descrizione", evento.Descrizione ?? "");
                cmd.Parameters.AddWithValue("@dal", evento.Dal);
                cmd.Parameters.AddWithValue("@al", evento.Al);
                cmd.Parameters.AddWithValue("@adminID", evento.AdminID);
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
        internal static List<ClsEvento> GetAll(ref MySqlConnection conn, out string errore)
        {
            List<ClsEvento> eventi = new List<ClsEvento>();
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " ORDER BY dal DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    eventi.Add(CreaEventoDaRiga(dt.Rows[i]));

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return eventi;
        }

        internal static ClsEvento GetByID(ref MySqlConnection conn, int id, out string errore)
        {
            ClsEvento evento = null;
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
                        evento = CreaEventoDaRiga(dt.Rows[0]);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
            return evento;
        }

        internal static List<ClsEvento> GetByAdminID(ref MySqlConnection conn, int adminID, out string errore)
        {
            List<ClsEvento> eventi = new List<ClsEvento>();
            errore = string.Empty;

            if (adminID <= 0)
                errore = "AdminID non valido"; 
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE adminID=@adminID ORDER BY dal DESC", conn);
                    da.SelectCommand.Parameters.AddWithValue("@adminID", adminID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                        eventi.Add(CreaEventoDaRiga(dt.Rows[i]));

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }

            }

            return eventi;
        }

        internal static List<ClsEvento> GetInCorso(ref MySqlConnection conn, out string errore)
        {
            List<ClsEvento> eventi = new List<ClsEvento>();
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(
                    SELECT_BASE + " WHERE NOW() BETWEEN dal AND al ORDER BY dal", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    eventi.Add(CreaEventoDaRiga(dt.Rows[i]));

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return eventi;
        }
        #endregion

        #region UPDATE
        internal static int Update(ref MySqlConnection conn, int id, ClsEvento evento, out string errore)
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

                    string sql = @"UPDATE eventi SET
                                    nome=@nome,
                                    descrizione=@descrizione,
                                    dal=@dal,
                                    al=@al,
                                    adminID=@adminID
                                WHERE ID=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nome", evento.Nome ?? "");
                    cmd.Parameters.AddWithValue("@descrizione", evento.Descrizione ?? "");
                    cmd.Parameters.AddWithValue("@dal", evento.Dal);
                    cmd.Parameters.AddWithValue("@al", evento.Al);
                    cmd.Parameters.AddWithValue("@adminID", evento.AdminID);
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

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM eventi WHERE ID=@id", conn);
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

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM eventi", conn);
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