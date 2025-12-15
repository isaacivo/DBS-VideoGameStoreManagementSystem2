namespace VideoGameRentalManagementSystem.Models
{
    // Demonstrates Encapsulation via properties and data validation
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty; 
        public int ReleaseYear { get; set; }
        public int CopiesTotal { get; set; }       
        public int CopiesAvailable { get; set; }   
        public int TimesCheckedOut { get; set; }   // for analytics

        public override string ToString()
        {
            return $"{Title} ({Platform}) by {Developer} ({ReleaseYear}) - " +
                   $"Available: {CopiesAvailable}/{CopiesTotal} - Checked out: {TimesCheckedOut}";
        }
    }
}
