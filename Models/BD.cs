using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Dapper;
public static class BD
{
    private static string _connectionString = @"Server=localhost;
    DataBase=BD;Integrated Security =True;TrustServerCertificate=True;";
    public static bool registrarse(Usuario user)
    {
        Usuario validar = new Usuario();
        bool registrado = false;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT username FROM Usuarios WHERE username = @pUusername";
            validar = connection.QueryFirstOrDefault<Usuario>(query, new { pUusername = user.username});
        }
        if (validar!= null)
        {
            string query = "INSERT INTO Usuarios (nombre, apellido, foto, username, ultimoLogin, password) VALUES (@pnombre, @papellido, @pfoto, @pusername, @pultimoLogin, @ppassword)";
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new {pnombre = user.nombre, papellido = user.apellido, pfoto = user.foto, pusername = user.username, pultimoLogin = user.ultimoLogin, ppassword = user.password});
            }
        }
        return registrado;
    }
    public static Usuario login(string username, string password)
    {

    }
    public static void actualizarLogin(int idUsuario)
    {

    }
    public static List<Tarea> devolverTareas(int idUsuario)
    {

    }
    public static Tarea devolverTarea(int idTarea)
    {

    }
    public static void editarTarea(Tarea tarea)
    {

    }
    public static void eliminarTarea(int idTarea)
    {

    }
    public static void crearTarea(Tarea tarea)
    {

    }
    public static void finalizarTarea(int idTarea)
    {

    }
}