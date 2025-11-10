namespace ContactAPI.Model.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public DateTime? CreatedAt { get; set; } 

        public string? Email { get; set; }

        public string? Phone { get; set; }

        //public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
