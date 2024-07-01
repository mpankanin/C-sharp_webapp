using Microsoft.Data.SqlClient;

namespace WebApp_example;

public class Repository
{
    
    private readonly Configuration _configuration;
    
    public Repository(Configuration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<IEnumerable<Student>> GetAsync()
    {
        await using var connection = new SqlConnection(_configuration.ConnectionString);
        await connection.OpenAsync();
        
        await using var command = connection.CreateCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Student";
        
        var dr = await command.ExecuteReaderAsync();
        var students = new List<Student>();
        while (await dr.ReadAsync())
        {
            var Student = new Student
            {
                Id = dr.GetInt32(0),
                Name = dr.GetString(1),
            };
            students.Add(Student);
        }

        return students;
    }
    
}