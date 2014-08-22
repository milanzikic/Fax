using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace HealthOnline.BusinessLogic
{
    /// <summary>
    /// Summary description for dbWorker
    /// </summary>
    public class dbWorker
    {
        public dbWorker()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string Login(string username, string password)
        {

            // Create an ODBC SQL command that will be executed below. Any SQL 
            // command that is valid with PostgreSQL is valid here (I think, 
            // but am not 100 percent sure. Every SQL command I've tried works).
            string query = "SELECT * FROM KorisnickiNalog as k Where k.Username = @Username AND k.Password = @Pass";
            OdbcCommand pgSqlCommand = new OdbcCommand();
            pgSqlCommand.CommandText = query;
            pgSqlCommand.Parameters.Add("@Username", OdbcType.VarChar);
            pgSqlCommand.Parameters.Add("@Pass", OdbcType.VarChar);
            DataSet result = GetData(pgSqlCommand);
            return result.DataSetName;
        }

        protected static DataSet GetData(OdbcCommand pgsqlCommand)
        {
            // Create the ODBC connection using the unique name you specified when 
            // creating your DSN. If desired you may input less information at the
            // DSN entry stage and put more in the "DSN=" line below.
            //OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL");
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["medicoConnection"].ToString();
            DataSet result = new DataSet();
            // "DSN=MyDSN;UID=Admin;PWD=Test" (UID = User name, PWD = password.)


            // Open the ODBC connection to the PostgreSQL database and display
            // the connection state (status).
            try
            {
                connection.Open();
                System.Console.WriteLine("State: " + connection.State.ToString());

                pgsqlCommand.Connection = connection;


                // Execute the SQL command and return a reader for navigating the results.
                OdbcDataReader reader = pgsqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                OdbcDataAdapter pgSqlAdapter = new OdbcDataAdapter(pgsqlCommand);
                pgSqlAdapter.Fill(result, "DataSet");
                pgsqlCommand.ExecuteNonQuery();

                // This loop will output the entire contents of the results, iterating
                // through each row and through each field of the row.
                //while (reader.Read() == true)
                //{
                //    Console.WriteLine("New Row:");
                //    for (int i = 0; i < reader.FieldCount; i++)
                //    {
                //        Console.WriteLine(reader.GetString(i));
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw new ApplicationException("pgsql Error: " + pgsqlCommand.CommandText + "<br />" + "Error message: " + ex.Message, ex);
            }
            finally
            {
                // Close the reader and connection (commands are not closed).
                //reader.Close();
                connection.Close();
            }
            return result;
        }
    }
}