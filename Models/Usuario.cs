using Microsoft.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;
namespace GrupoPresentacionWeb.Models;
public class Usuario
{
       [JsonProperty]
    public string UserName { get; set; }
    [JsonProperty]
    public string Contraseña { get; set; }
    [JsonProperty]
    public string Nombre { get; set; }
    [JsonProperty]
    public string Foto { get; set; }
    [JsonProperty]
    public string Apellido { get; set; }
    [JsonProperty]
    public DateTime UltimoLogin { get; set; }
    [JsonProperty]
    public int Id { get; set; }

 

      public Usuario() { }

}