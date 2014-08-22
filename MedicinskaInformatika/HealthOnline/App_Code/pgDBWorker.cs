using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for pgDBWorker
/// </summary>
public class pgDBWorker
{
	public pgDBWorker()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet Login(string username, string password)
    {
        // Create an ODBC SQL command that will be executed below. Any SQL 
        // command that is valid with PostgreSQL is valid here (I think, 
        // but am not 100 percent sure. Every SQL command I've tried works).
        string query = "SELECT * FROM public.\"korisnicki_nalog\" as k Where k.\"username\" = ? AND k.\"password\" = ?";
        OdbcCommand pgSqlCommand = new OdbcCommand();
        pgSqlCommand.CommandText = query;
        pgSqlCommand.Parameters.Add("param1", OdbcType.VarChar).Value = username;
        pgSqlCommand.Parameters.Add("param2", OdbcType.VarChar).Value = password;
        DataSet result = GetData(pgSqlCommand);
        return result;
    }

    public DataSet GetAllLogins() {
        string query = "SELECT * FROM public.\"korisnicki_nalog\" ";
        OdbcCommand pgSqlCommand = new OdbcCommand();
        pgSqlCommand.CommandText = query;
        DataSet result = GetData(pgSqlCommand);
        return result;
    }

    public string Register(int pin, string jmbg, string username, string password, string mail, string telefon, string mobilni) {
        string query = "INSERT INTO \"public\".korisnicki_nalog (username, password, pin, jmbg, mail, telefon, mobilni) VALUES (?, ?, ?, ?, ?, ?, ?)";
        OdbcCommand pgsqlCommand = new OdbcCommand();
        pgsqlCommand.CommandText = query;
        //pgsqlCommand.Parameters.Add("@tablename", OdbcType.VarChar).Value = "public.\"korisnicki_nalog\"";
        pgsqlCommand.Parameters.Add("param1", OdbcType.VarChar, 25).Value = username;
        pgsqlCommand.Parameters.Add("param2", OdbcType.VarChar, 25).Value = password;
        pgsqlCommand.Parameters.Add("param3", OdbcType.Int).Value = pin;
        pgsqlCommand.Parameters.Add("param4", OdbcType.VarChar, 13).Value = jmbg;
        pgsqlCommand.Parameters.Add("param5", OdbcType.VarChar, 100).Value = mail;
        pgsqlCommand.Parameters.Add("param6", OdbcType.VarChar, 30).Value = telefon;
        pgsqlCommand.Parameters.Add("param7", OdbcType.VarChar, 30).Value = mobilni;
        return Insert(pgsqlCommand);
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
            //OdbcDataReader reader = pgsqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

            OdbcDataAdapter pgSqlAdapter = new OdbcDataAdapter(pgsqlCommand);
            

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
            
            // Close the reader (commands are not closed).
            //reader.Close();

            pgSqlAdapter.Fill(result, "DataSet");
            pgsqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("pgsql Error: " + pgsqlCommand.CommandText + "<br />" + "Error message: " + ex.Message, ex);
        }
        finally
        {
            // Close connection (commands are not closed).
            connection.Close();
        }
        return result;
    }

    protected static string Insert(OdbcCommand myCommand)
    {
        // Create the ODBC connection using the unique name you specified when 
        // creating your DSN. If desired you may input less information at the
        // DSN entry stage and put more in the "DSN=" line below.
        //OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL");
        OdbcConnection connection = new OdbcConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["medicoConnection"].ToString();
        
        string result;
        try
        {
            connection.Open();
            //execute queries, etc
            myCommand.Connection = connection;
            myCommand.ExecuteNonQuery();
            result="Uspesno ste upisali podatke!";
        }
        catch (Exception ex)
        {
            result="sqlError:" + myCommand.CommandText + " <br />  --> error message: " + ex.Message;
            throw new ApplicationException("pgsql Error:" + myCommand.CommandText + " <br />  --> error message: " + ex.Message, ex);
        }
        finally
        {
            connection.Close();
        }
        return result;
    }
}