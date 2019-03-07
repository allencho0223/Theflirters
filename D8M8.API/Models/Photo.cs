using System;

namespace D8M8.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        /*
            By adding these 2 lines below, we can completely remove user's details.
            Without the 2 lines, the database will still keep photos of the user as references
         */
        public User User { get; set; }
        public int UserId { get; set; }
    }
}