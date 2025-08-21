using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListmaster.Models
{
    public static class BD
    {
        public static string _connectionString = @"Server=localhost;
        DataBase=BD;Integrated Security=True;TrustServerCertificate=True;";

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

    public static int Login(string UserName, string Contraseña)
    {
        int id = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Id FROM Usuario WHERE UserName = @pUserName AND Contraseña = @pcontraseña";
            id = connection.QueryFirstOrDefault<int>(query, new { pUserName = UserName, pcontraseña = Contraseña });
        }
if(id != 0){  return id;}
 else{return id = -1;}     
    }



public static int EliminarTarea(int Idtarea){
string query = "DELETE FROM Tarea WHERE Id= Idtarea";
int tareasAfectados = 0;
using (SqlConnection connection = new SqlConnection(_connectionString))
{
tareasAfectados = connection.Execute(query, new { Idtarea });
}

return tareasAfectados;
}


    public static void AgregarTarea(Tarea t)
    {
       string query = "INSERT INTO Tarea (Id, Titulo, Descripción, Fecha, Finalización, IdUsuario)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
           connection.Execute(query, new{pIdt = t.Id, pTitulo = t.Titulo,pDescripción = t.Descripción,pFecha = t.Fecha, pFinalizada = t.Finalización,pIdUsuario = t.IdUsuario});
        }
  
    }
    
    public static int ModificarTarea(Tarea t) {
    string query = @"
        UPDATE Tarea
        SET Titulo = @Titulo,
            Descripción = @Descripción,
            Fecha = @Fecha,
            Finalización = @Finalización
        WHERE Id = @Id";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        int registrosAfectados = connection.Execute(query, new {
            Id = t.Id,
            Titulo = t.Titulo,
            Descripción = t.Descripción,
            Fecha = t.Fecha,
            Finalización = t.Finalización
        });
        return registrosAfectados;
    }
}


public static  Tarea VerTarea(int Id){
Tarea t = null;
using (SqlConnection connection = new SqlConnection(_connectionString))
{
string query = "SELECT * FROM TAREA WHERE ID = @pId";
t = connection.QueryFirstOrDefault<Tarea>(query, new { pId
=
Id});

}
return t;
}

public static  Usuario VerUsuario(int Id){
    Usuario u = null;
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM USUARIO WHERE ID = @pId";
        u = connection.QueryFirstOrDefault<Usuario>(query, new { pId = Id});

    }
    return u;
}
public static List<Tarea> VerTareas(int IdUsuario)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Tarea WHERE IdUsuario = @IdUsuario";

        // Pasamos el parámetro correctamente
        var Tareas = connection.Query<Tarea>(query, new { IdUsuario }).ToList();

        return Tareas;
    }
}


public static int ActualizarFecha(int Id)
{
    string query = "UPDATE Usuario SET UltimoLogIng = GETDATE() WHERE Id = @id";
    int registrosAfectados = 0;

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        registrosAfectados = connection.Execute(query, new { Id });
    }

    return registrosAfectados;
}


public static int RegistrarUsuario(string nombre, string apellido,  string contrasena, string userName)
{
    
    string query = @"
        INSERT INTO Usuario (Nombre, Apellido, [Contraseña], UserName, UltimoLogIn) 
        VALUES (@Nombre, @Apellido, @Contrasena, @UserName, @UltimoLogIn);
        SELECT CAST(SCOPE_IDENTITY() as int);";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        int nuevoId = connection.QuerySingle<int>(query, new 
        { 
            Nombre = nombre,
            Apellido = apellido,
         
            UserName = userName,
            UltimoLogIn = DateTime.Now,
            
            Contrasena = contrasena
        });

        return nuevoId;
    }
}

     public static int FinalizarTarea(int idTarea, bool Finalización)
        {
            string query = @"UPDATE Tarea SET Finalización = @Finalización WHERE Id = @Id";
   int registrosAfectados = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                 registrosAfectados = connection.Execute(query, new
                {
                    Finalización = Finalización,
                    Id = idTarea   
                });

                return registrosAfectados;
            }
        }


}
}