using Microsoft.EntityFrameworkCore;

namespace BulbEd.Entities;

public class Connection
{
    public Connection()
    {
    }
    
    public Connection(string ConnectionId, string username)
    {
        ConnectionId = ConnectionId;
        Username = username;
    }
    
    public string ConnectionId { get; set; }
    
    public string Username { get; set; }
}