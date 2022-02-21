
namespace vacationFriends.Interfaces
{
    public interface IVacation
    {
        public int Id { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public string Destination { get; set; }
        public string TimeFrame { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }

    }
}