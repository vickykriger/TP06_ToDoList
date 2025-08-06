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
}