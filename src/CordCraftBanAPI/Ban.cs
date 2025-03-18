namespace CordCraftBanAPI
{
    public class Ban
    {
        public int Id { get; set; }
        public string UUID { get; set; }
        public string PlayerName { get; set; }
        public string BannedBy { get; set; }
        public string Reason { get; set; }
        public DateTime BannedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
