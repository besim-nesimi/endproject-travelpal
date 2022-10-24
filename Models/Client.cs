namespace slutproj_TravelPal.Models
{
    public class Client : User
    {
        public Client(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}