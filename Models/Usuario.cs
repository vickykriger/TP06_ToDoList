using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Dapper;
public class Usuario
{
    [JsonProperty]
    public int id;
    [JsonProperty]
    public string nombre;
    [JsonProperty]
    public string apellido;
    [JsonProperty]
    public string foto;
    [JsonProperty]
    public string username;
    [JsonProperty]
    public DateTime ultimoLogin;
    [JsonProperty]
    public string password;
    public Usuario()
    {

    }
    public Usuario(string user, string password, string nombre, string apellido, string foto)
    {
        this.username = user;
        this.password = password;
        this.nombre = nombre;
        this.apellido = apellido;
        this.foto = foto;
    }
}