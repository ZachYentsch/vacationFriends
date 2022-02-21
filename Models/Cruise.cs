using System;
using vacationFriends.Interfaces;

namespace vacationFriends.Models
{
    public class Cruise : IVacation
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Destination { get; set; }
        public string TimeFrame { get; set; }
        public int Stops { get; set; }
        public string StopName { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }

    }
}