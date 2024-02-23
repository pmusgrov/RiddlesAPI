namespace RiddlesAPI.Models
{
    public class RiddlesDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string RiddlesCollectionName { get; set; } = null!;
    }
}
