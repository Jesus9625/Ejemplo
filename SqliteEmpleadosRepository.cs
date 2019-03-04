
using Dapper;
using Ejemplo.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejemplo{

    public class SqliteEmpleadosRepository{
        private string constrc;

        public SqliteEmpleadosRepository(string v)
        {
            this.constrc = v;
        }

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

        internal EmpleadoModel LeerPorId(int id)
        {
            var sql = "SELECT Id, Nombre, Centro, Zona FROM Empleados WHERE Id = @Id";

            using(var conn = new SqliteConnection(constrc)){

                var empleado = conn.QueryFirstOrDefault<EmpleadoModel>(sql, new {Id = id});
                return empleado;
            }
        }

        internal List<EmpleadoModel> LeerTodos()
        {
            var sql = "SELECT Id, Nombre, Centro, Zona FROM Empleados;";

            using(var conn = new SqliteConnection(constrc)){

                var empleados = conn.Query<EmpleadoModel>(sql).ToList();
                return empleados;
            }
        }

        internal void Crear(EmpleadoModel model)
        {
            string sql = "INSERT INTO Empleados (Id, Nombre, Centro, Zona) VALUES (@Id, @Nombre, @Centro, @Zona)";
            using(var conn = new SqliteConnection(constrc)){

                conn.Execute(sql, model);
            }
        }

        internal void Actualizar(EmpleadoModel model)
        {
            string sql = "UPDATE Empleados SET Id = @Id,  Nombre = @Nombre, Centro = @Centro, Zona WHERE Id = @Id;";
            using(var conn = new SqliteConnection(constrc)){

                conn.Execute(sql, model);
            }
        }

        internal void Borrar(int id)
        {
            string sql = "DELETE FROM Empleados WHERE Id = @Id";
            using(var conn = new SqliteConnection(constrc)){

                conn.Execute(sql, new {Id = id});
            }
        }
    }





}