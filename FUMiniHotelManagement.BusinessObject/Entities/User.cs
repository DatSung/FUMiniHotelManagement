using System;
using System.Collections.Generic;

namespace FUMiniHotelManagement.BusinessObject.Entities
{
    public partial class User
    {
        public User()
        {
            BookingReservations = new HashSet<BookingReservation>();
        }

        public Guid UserId { get; set; }
        public string? AvatarUrl { get; set; }
        public string? FullName { get; set; }
        public string? Telephone { get; set; }
        public string EmailAddress { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? Status { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<BookingReservation> BookingReservations { get; set; }
    }
}
