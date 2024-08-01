namespace Hotel.Domain
{
    public class Room
    {
        public int RoomID { get; set; }
        public string? RoomNumber { get; set; }
        public int? RoomTypeID { get; set; }
        public int Floor { get; set; }
        public string? Description { get; set; }
        public decimal PricePerNight { get; set; }
        public int StatusID { get; set; }
        public RoomType? RoomType { get; set; }
        public RoomStatuses? RoomStatus { get; set; }
    }
}