using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace GrupoPresentacionWeb.Models
{
    public static class BD
    {
        public static string _connectionString = @"Server=localhost;
        DataBase=Presentación;Integrated Security=True;TrustServerCertificate=True;";
   public static Usuario LevantarUsuario(string Contraseña, string UserName)
{
Usuario u = null;
using (SqlConnection connection = new SqlConnection(_connectionString))
{
string query = "SELECT * FROM Usuario WHERE UserName = @EmaUserName AND Contraseña = @Contraseña";
u = connection.QueryFirstOrDefault<Usuario>(query, new { Email = Email, Contraseña = Contraseña });
}
return u;
}






    public static Usuario GetUsuario(int idUsuario)
    {
        Usuario miusuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE Id = @pIdUsuario";
             miusuario = connection.QueryFirstOrDefault<Usuario>(query, new { pIdUsuario = idUsuario });
            return miusuario;
        }
    }






    public static List<DatoFamiliar> GetDatoFamiliar(int idUsuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM DatoFamiliar WHERE IdUsuario = @pIdUsuario";
            List<DatoFamiliar> familiares = connection.Query<DatoFamiliar>(query, new { pIdUsuario = idUsuario }).AsList();
            return familiares;
        }
    }
public static DatosInteres GetDatoInteres(int idUsuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM DatoInteres WHERE IdUsuario = @pIdUsuario";
            DatosInteres intereses = connection.QueryFirstOrDefault<DatosInteres>(query, new { pIdUsuario = idUsuario });
            return intereses;
        }
    }
    public static int Login(string email, string contraseña)
    {
        int id = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Id FROM Usuario WHERE Email = @pEmail AND Contraseña = @pContraseña";
            id = connection.QueryFirstOrDefault<int>(query, new { pEmail = email, pContraseña = contraseña });
        }
if(id != 0){  return id;}
 else{return id = -1;}     
    }
}
}