using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using ProyectoPAWRep.classes;
namespace ProyectoPAWRep.classes
{
    public class DatabaseManager
    {
        private SqlConnection sqlConnection;
        private string table;

        public string Table { get => table; set => table = value; }
        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public DatabaseManager(string connectionString, string table)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
            this.table = table;
        }
        public bool RemoveDatabaseRecord(string[,] conditions, string[] logic_conditionals)
        {
            string formatted_conditions;
            formatted_conditions = FormatConditiontoSelect(conditions, logic_conditionals);

            string strSQL = "DELETE FROM " + table + formatted_conditions;

            var cmd = new SqlCommand(strSQL, SqlConnection);

            try
            {
                SqlConnection.Open();
                cmd.ExecuteNonQuery();
                SqlConnection.Close();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }
        public DataSet ReadDatabaseRecord(string[] values, string[,] conditions, string[] logic_conditionals, string orderby = null, string direction = null)
        {
            string formatted_values;
            string formatted_conditions;
            string formatted_order = " ORDER BY ";

            // Darle formato a los valores a traer de la base de datos
            formatted_values = FormatValuestoSelect(values);

            // Darle formato a las condiciones a traer de la base de datos
            if(conditions != null)
            {
                formatted_conditions = FormatConditiontoSelect(conditions, logic_conditionals);
            }
            else
            {
                formatted_conditions = "";
            }


            // Darle formato al orden en el que se traera la informacion
            if (!String.IsNullOrEmpty(orderby))
            {
                formatted_order += orderby + " " + direction;
            }
            else
            {
                formatted_order = "";
            }

            string strSQL = "SELECT " + formatted_values + " FROM " + table + formatted_conditions + formatted_order;

            var cmd = new SqlCommand(strSQL, sqlConnection);

            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            sqlConnection.Open();
            da.Fill(ds, "tb_Usuarios");
            sqlConnection.Close();

            return ds;
        }
        public bool UpdateDatabaseRecord(string[,] values_to_update, string[,] conditions, string[] logic_conditionals)
        {
            string formatted_values;
            string formatted_conditions;

            if (conditions != null)
            {
                formatted_conditions = FormatConditiontoSelect(conditions, logic_conditionals);
            }
            else
            {
                formatted_conditions = "";
            }
            formatted_values = FormatValuesToUpdate(values_to_update);


            string strSQL = "UPDATE " + table + formatted_values + formatted_conditions;

            var cmd = new SqlCommand(strSQL, SqlConnection);

            try
            {
                SqlConnection.Open();
                cmd.ExecuteNonQuery();
                SqlConnection.Close();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }

        public int CountFetchedData(string[] values, string[,] conditions, string[] logic_conditionals, string orderby = null, string direction = null)
        {
            DataSet data = ReadDatabaseRecord(values, conditions, logic_conditionals, orderby, direction);

            return data.Tables[0].Rows.Count;

        }

        public bool CheckIfExists(string[] values, string[,] conditions, string[] logic_conditionals, string orderby = null, string direction = null)
        {
            DataSet data = ReadDatabaseRecord(values, conditions, logic_conditionals, orderby, direction);

            if (data.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        string FormatValuestoSelect(string[] values)
        {
            string formatted_values = "";

            if (values.Length > 1)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (i < values.Length - 1)
                    {
                        formatted_values += "[" + values[i] + "],";
                    }
                    else
                    {
                        formatted_values += "[" + values[i] + "]";
                    }
                }
            }
            else if (values.Length == 1)
            {
                formatted_values += values[0] == "*" ? "*" : "[" + values[0] + "]";
            }
            else
            {
                formatted_values += "*";
            }
            return formatted_values;
        }
        string FormatConditiontoSelect(string[,] conditions, string[] logic_conditionals)
        {
            string formatted_conditions = " WHERE ";

            if (conditions.GetLength(0) > 1)
            {
                for (int i = 0; i < conditions.GetLength(0); i++)
                {
                    if (i < conditions.GetLength(0) - 1)
                    {
                        formatted_conditions += conditions[i, 0] + conditions[i, 1] + conditions[i, 2] + " " + logic_conditionals[i] + " ";
                    }
                    else
                    {
                        formatted_conditions += conditions[i, 0] + conditions[i, 1] + conditions[i, 2];
                    }
                }
            }
            else if (conditions.GetLength(0) == 1)
            {
                formatted_conditions += conditions[0, 0] + conditions[0, 1] + conditions[0, 2];
            }
            else
            {
                formatted_conditions = "";
            }
            return formatted_conditions;
        }
        string FormatValuesToUpdate(string[,] values_to_update)
        {
            string formatted_values = " SET ";

            if (values_to_update.GetLength(0)>1)
            {
                for (int i = 0; i < values_to_update.GetLength(0); i++)
                {
                    if (i < values_to_update.GetLength(0) - 1)
                    {
                        formatted_values += "[" + values_to_update[i,0] + "]=" + values_to_update[i, 1] + ", ";
                    }
                    else
                    {
                        formatted_values += "[" + values_to_update[i, 0] + "]=" + values_to_update[i, 1];
                    }
                }
            }else if(values_to_update.GetLength(0) == 1)
            {
                formatted_values += "[" + values_to_update[0, 0] + "]=" + values_to_update[0, 1];
            }
            else
            {
                formatted_values = "";
            }
            return formatted_values;
        }
    }
}