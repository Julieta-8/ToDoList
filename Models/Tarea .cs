using Microsoft.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;
namespace GrupoPresentacionWeb.Models;
public class Tarea
{
       [JsonProperty]
    public string Titulo { get; set; }
    [JsonProperty]
    public string Descripción { get; set; }
    [JsonProperty]
    public DateTime Fecha  { get; set; }
    [JsonProperty]
    public bool Finalizada  { get; set; }
    [JsonProperty]
    public int Id { get; set; }

 

      public Tarea() { }

}