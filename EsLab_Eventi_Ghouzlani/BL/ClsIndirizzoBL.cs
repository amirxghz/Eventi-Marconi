using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    internal static class ClsIndirizzoBL
    {
        private const string SELECT_BASE =
            @"SELECT ID, nome
              FROM indirizzi";

        private static ClsIndirizzo CreaIndirizzoDaRiga(DataRow r)
        {
            ClsIndirizzo i = new ClsIndirizzo();
            i.ID = Convert.ToInt32(r["ID"]);
            i.Nome = r["nome"] == DBNull.Value ? "" : r["nome"].ToString();
            return i;
        }

        #region CREATE
        internal static long Create(ref MySqlConnection conn, ClsIndirizzo indirizzo, out string errore)
        {
            long id = 0;
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string sql = "INSERT INTO indirizzi (nome) VALUES (@nome)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", indirizzo.Nome ?? "");
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
        internal static List<ClsIndirizzo> GetAll(ref MySqlConnection conn, out string errore)
        {
            List<ClsIndirizzo> indirizzi = new List<ClsIndirizzo>();
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " ORDER BY nome", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    indirizzi.Add(CreaIndirizzoDaRiga(dt.Rows[i]));

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return indirizzi;
        }

        internal static ClsIndirizzo GetByID(ref MySqlConnection conn, int id, out string errore)
        {
            ClsIndirizzo indirizzo = null;
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
                        indirizzo = CreaIndirizzoDaRiga(dt.Rows[0]);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
            return indirizzo;
        }

        internal static List<ClsIndirizzo> GetByNome(ref MySqlConnection conn, string nome, out string errore)
        {
            List<ClsIndirizzo> indirizzi = new List<ClsIndirizzo>();
            errore = string.Empty;

            if (string.IsNullOrEmpty(nome))
                errore = "Nome non valido"; 
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE nome LIKE @nome ORDER BY nome", conn);
                    da.SelectCommand.Parameters.AddWithValue("@nome", "%" + nome + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                        indirizzi.Add(CreaIndirizzoDaRiga(dt.Rows[i]));

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
            
            return indirizzi;
        }
        #endregion

        #region UPDATE
        internal static int Update(ref MySqlConnection conn, int id, ClsIndirizzo indirizzo, out string errore)
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

                    string sql = "UPDATE indirizzi SET nome=@nome WHERE ID=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nome", indirizzo.Nome ?? "");
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

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM indirizzi WHERE ID=@id", conn);
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

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM indirizzi", conn);
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