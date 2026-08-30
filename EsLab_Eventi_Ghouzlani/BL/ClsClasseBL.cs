using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    internal static class ClsClasseBL
    {
        private const string SELECT_BASE =
            @"SELECT sigla, aula, anno, sezione, indirizzoID
              FROM classi";

        private static ClsClasse CreaClasseDaRiga(DataRow r)
        {
            ClsClasse c = new ClsClasse();
            c.Sigla = r["sigla"] == DBNull.Value ? "" : r["sigla"].ToString();
            c.Aula = r["aula"] == DBNull.Value ? "" : r["aula"].ToString();
            c.Anno = r["anno"] == DBNull.Value ? (byte)0 : Convert.ToByte(r["anno"]);
            c.Sezione = r["sezione"] == DBNull.Value ? "" : r["sezione"].ToString();
            c.IndirizzoID = r["indirizzoID"] == DBNull.Value ? 0 : Convert.ToInt32(r["indirizzoID"]);
            return c;
        }

        #region CREATE
        internal static int Create(ref MySqlConnection conn, ClsClasse classe, out string errore)
        {
            int esito = 0;
            errore = string.Empty;

            if (string.IsNullOrEmpty(classe.Sigla))
                errore = "Sigla non valida"; 
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string sql = @"INSERT INTO classi (sigla, aula, anno, sezione, indirizzoID)
                               VALUES (@sigla, @aula, @anno, @sezione, @indirizzoID)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sigla", classe.Sigla ?? "");
                    cmd.Parameters.AddWithValue("@aula", classe.Aula ?? "");
                    cmd.Parameters.AddWithValue("@anno", classe.Anno);
                    cmd.Parameters.AddWithValue("@sezione", classe.Sezione ?? "");
                    cmd.Parameters.AddWithValue("@indirizzoID", classe.IndirizzoID);
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

        #region READ
        internal static List<ClsClasse> GetAll(ref MySqlConnection conn, out string errore)
        {
            List<ClsClasse> classi = new List<ClsClasse>();
            errore = string.Empty;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " ORDER BY anno, sezione", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    classi.Add(CreaClasseDaRiga(dt.Rows[i]));

                conn.Close();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }

            return classi;
        }

        internal static ClsClasse GetBySigla(ref MySqlConnection conn, string sigla, out string errore)
        {
            ClsClasse classe = null;
            errore = string.Empty;

            if (string.IsNullOrEmpty(sigla))
                errore = "Sigla non valida"; 
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE sigla=@sigla LIMIT 1", conn);
                    da.SelectCommand.Parameters.AddWithValue("@sigla", sigla);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        classe = CreaClasseDaRiga(dt.Rows[0]);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
            return classe;
        }

        internal static List<ClsClasse> GetByIndirizzoID(ref MySqlConnection conn, int indirizzoID, out string errore)
        {
            List<ClsClasse> classi = new List<ClsClasse>();
            errore = string.Empty;

            if (indirizzoID <= 0)
                errore = "IndirizzoID non valido"; 
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(SELECT_BASE + " WHERE indirizzoID=@indirizzoID ORDER BY anno, sezione", conn);
                    da.SelectCommand.Parameters.AddWithValue("@indirizzoID", indirizzoID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                        classi.Add(CreaClasseDaRiga(dt.Rows[i]));

                    conn.Close();
                }
                catch (Exception ex)
                {
                    errore = ex.Message;
                }
            }
            return classi;
        }
        #endregion

        #region UPDATE
        internal static int Update(ref MySqlConnection conn, string sigla, ClsClasse classe, out string errore)
        {
            int esito = 0;
            errore = string.Empty;

            if (string.IsNullOrEmpty(sigla))
                errore = "Sigla non valida"; 
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string sql = @"UPDATE classi SET
                                    aula=@aula,
                                    anno=@anno,
                                    sezione=@sezione,
                                    indirizzoID=@indirizzoID
                                WHERE sigla=@sigla";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sigla", sigla);
                    cmd.Parameters.AddWithValue("@aula", classe.Aula ?? "");
                    cmd.Parameters.AddWithValue("@anno", classe.Anno);
                    cmd.Parameters.AddWithValue("@sezione", classe.Sezione ?? "");
                    cmd.Parameters.AddWithValue("@indirizzoID", classe.IndirizzoID);
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
        internal static int Delete(ref MySqlConnection conn, string sigla, out string errore)
        {
            int esito = 0;
            errore = string.Empty;

            if (string.IsNullOrEmpty(sigla))
                errore = "Sigla non valida";
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM classi WHERE sigla=@sigla", conn);
                    cmd.Parameters.AddWithValue("@sigla", sigla);
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

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM classi", conn);
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