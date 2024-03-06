using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data
{
    public enum ClientType { Node, Regular, Premium }
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
