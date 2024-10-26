using System;
using System.Collections.Generic;

namespace FUMiniHotelManagement.BusinessObject.Entities
{
    public partial class BookingReservation
    {
        public BookingReservation()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public Guid BookingReservationId { get; set; }
        public DateTime? BookingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public Guid CustomerId { get; set; }
        public string? BookingStatus { get; set; }

        public virtual User Customer { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
