using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListmaster.Models
{
    public static class BD
    {
        public static string _connectionString = @"Server=localhost;
        DataBase=Presentación;Integrated Security=True;TrustServerCertificate=True;";


    public static Usuario Login(string UserName, string contraseña)
    {
        Usuario u = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE UserName = @pUserName AND Contraseña = @pContraseña";
            u = connection.QueryFirstOrDefault<Usuario>(query, new { pUserName = UserName, pContraseña = contraseña });
        }
        if(u != null){  return u;}
        else{return u = null;}     
    }


public static int EliminarTarea(int Idtarea){
string query = "DELETE FROM Tarea WHERE Idt= IDtarea";
int tareasAfectados = 0;
using (SqlConnection connection = new SqlConnection(_connectionString))
{
tareasAfectados = connection.Execute(query, new { Idtarea });
}

return tareasAfectados;
}


    public static void AgregarTarea(Tarea t)
    {
       string query = "INSERT INTO Tarea (Id, Titulo, Descripción, Fecha, Finalizada, IdUsuario)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
           connection.Execute(query, new{pIdt = t.Id, pTitulo = t.Titulo,pDescripción = t.Descripción,pFecha = t.Fecha, pFinalizada = t.Finalizada,pIdUsuario = t.IdUsuario});
        }
  
    }
    
    public static int ModificarTarea(Tarea t) {
    string query = @"
        UPDATE Tarea
        SET Titulo = @Titulo,
            Descripción = @Descripción,
            Fecha = @Fecha,
            Finalizada = @Finalizada
        WHERE Id = @Id";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        int registrosAfectados = connection.Execute(query, new {
            Id = t.Id,
            Titulo = t.Titulo,
            Descripción = t.Descripción,
            Fecha = t.Fecha,
            Finalizada = t.Finalizada
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

public static List<Tarea> VerTareas(int IdUsuario){
 List<Tarea> Tareas = new List<Tarea>();
using (SqlConnection connection = new SqlConnection(_connectionString))
{
string query = "SELECT * FROM Tarea WHERE IdUsuario = @pIdUsuario";
Tareas= connection.Query<Tarea>(query).ToList();

}

return  Tareas;

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


public static int RegistrarUsuario(string nombre, string apellido, string email, string contrasena, string userName)
{
    string query = @"
        INSERT INTO Usuario (Nombre, Apellido, Email, [Contraseña], UserName, FechaUltimoLogin) 
        VALUES (@Nombre, @Apellido, @Email, @Contrasena, @UserName, NULL);
        SELECT CAST(SCOPE_IDENTITY() as int);";

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        int nuevoId = connection.QuerySingle<int>(query, new 
        { 
            Nombre = nombre, 
            Apellido = apellido, 
            Email = email, 
            Contrasena = contrasena,
            UserName = userName 
        });

        return nuevoId;
    }
}

     public static int FinalizarTarea(int idTarea, bool finalizada)
        {
            string query = @"UPDATE Tarea SET Finalizada = @Finalizada WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                int registrosAfectados = connection.Execute(query, new
                {
                    Finalizada = finalizada,
                    Id = idTarea   
                });

                return registrosAfectados;
            }
        }


}
}