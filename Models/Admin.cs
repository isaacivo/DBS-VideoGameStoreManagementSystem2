namespace VideoGameRentalManagementSystem.Models
{
    public class Admin
    {
        public int Id { get; set; }              // PRIMARY KEY
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // plain text for demo only
    }
}
