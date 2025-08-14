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
        if (validar== null)
        {
            string query = "INSERT INTO Usuarios (nombre, apellido, foto, username, ultimoLogin, password) VALUES (@pnombre, @papellido, @pfoto, @pusername, @pultimoLogin, @ppassword)";
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                if (user.ultimoLogin < new DateTime(1753, 1, 1))
                    user.ultimoLogin = DateTime.Now;
                connection.Execute(query, new {pnombre = user.nombre, papellido = user.apellido, pfoto = user.foto, pusername = user.username, pultimoLogin = user.ultimoLogin, ppassword = user.password});
            }
            registrado = true;
        }
        return registrado;
    }
    public static Usuario login(string username, string password)
    {
        Usuario logeado = new Usuario();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE username = @pUsername AND password = @pPassword";
            logeado = connection.QueryFirstOrDefault<Usuario>(query, new { pUsername = username, pPassword = password});
        }
        return logeado;
    }
    public static void actualizarLogin(int idUsuario)
    {
        string query = "UPDATE Usuarios SET ultimoLogin = @pLogin WHERE id = @pId";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pLogin = DateTime.Now, pId = idUsuario});
        }
    }
    public static List<Tarea> devolverTareas(int idUsuario)
    {
        List<Tarea> tareas = new List<Tarea>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE idUsuario = @pUsuario";
            tareas = connection.Query<Tarea>(query, new {pUsuario = idUsuario}).ToList();
        }
        return tareas;
    }
    public static Tarea devolverTarea(int idTarea)
{
    Tarea tarea = new Tarea();
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Tareas WHERE id = @pIdTarea";
        tarea = connection.QueryFirstOrDefault<Tarea>(query, new {pIdTarea = idTarea});
    }
    return tarea;
}
   public static void modificarTarea(int id, string tituloNuevo, string descripcionNueva, DateTime fechaNueva, bool finalizadaNueva, int idUserNuevo)
    {
        string query = "UPDATE Tareas SET titulo = @pTitulo, descripcion = @pDescripcion, fecha = @pFecha, finalizada = @pFinalizada, idUsuario = @pIdUsuario WHERE id = @pId";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { pTitulo = tituloNuevo, pDescripcion = descripcionNueva, pFecha = fechaNueva, pFinalizada = finalizadaNueva, pIdUsuario = idUserNuevo, pId = id });
        }
    }
    public static void eliminarTarea(int idTarea)
{
    string query = "DELETE FROM Tareas WHERE id = @pIdTarea";
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new {pIdTarea = idTarea});
    }
}
    public static void crearTarea(Tarea tarea)
    {
        string query = "INSERT INTO Tareas (titulo, descripcion, fecha, finalizada, idUsuario) VALUES (@pTitulo, @pDescripcion, @pFecha, @pFinalizada, @pIdUsuario)";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pTitulo = tarea.titulo, pDescripcion = tarea.descripcion, pFecha = tarea.fecha, pFinalizada = tarea.finalizada, pIdUsuario = tarea.idUsuario});
        }
    }
    public static void finalizarTarea(int idTarea)
    {
        string query = "UPDATE Tareas SET finalizada = 1 WHERE id = @pId";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pId = idTarea});
        }
    }
}