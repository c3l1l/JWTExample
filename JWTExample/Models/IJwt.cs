namespace JWTExample.Models
{
    public interface IJwt
    {
        string Authenticate(string username, string password);
    }
}
