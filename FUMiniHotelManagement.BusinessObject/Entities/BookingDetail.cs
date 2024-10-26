using System;
using System.Collections.Generic;

namespace FUMiniHotelManagement.BusinessObject.Entities
{
    public partial class BookingDetail
    {
        public Guid BookingReservationId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? ActualPrice { get; set; }

        public virtual BookingReservation BookingReservation { get; set; } = null!;
        public virtual RoomInformation Room { get; set; } = null!;
    }
}
