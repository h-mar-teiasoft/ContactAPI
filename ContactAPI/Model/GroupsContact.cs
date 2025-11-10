namespace ContactAPI.Model
{
    public class GroupsContact
    {
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;

        public int ContactId { get; set; }
        public Contact Contact { get; set; } = null!;
    }
}
