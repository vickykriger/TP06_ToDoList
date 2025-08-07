using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Dapper;
public class Tarea
{
    [JsonProperty]
    public int id;
    [JsonProperty]
    public string titulo;
    [JsonProperty]
    public string descripcion;
    [JsonProperty]
    public DateTime fecha;
    [JsonProperty]
    public bool finalizada;
    [JsonProperty]
    public int idUsuario;
    public Tarea(string titulo, string descripcion, DateTime fecha, bool finalizada, int idUsuario)
    {
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.fecha = fecha;
        this.finalizada = finalizada;
        this.idUsuario = idUsuario;
    }
    public Tarea()
    {
        
    }
}