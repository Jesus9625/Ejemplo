
using Microsoft.Data.Sqlite;
using System;

namespace Ejempl{

    public class SqliteEmpleadosRepository{

        public static void InitDatabase(){

            string stringConsulta = "CREATE TABLE IF NOT EXISTS EMPLEADOS" +
                " ( Id INTEGER KEY AUTOINCREMENT, " +
                "Nombre TEXT NOT NULL, " +
                "Centro INTEGER NOT NULL, " +
                "Zona INTEGER NOT NULL);";
            var con = new SqliteConnection("Data Source=app.db");
            var cmd = new SqliteCommand(stringConsulta);
                cmd.Connection = con;
                
                try{
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
                catch(Exception ex){
                    Console.WriteLine(ex.Message);


                }

        }
    }





}