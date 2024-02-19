namespace WebDay2.Models {
    public record class ClassRoom {
        public int ClassRoomID { get; set; }
        public string Description { get; set; }
        public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>();

        public bool IsActive { get; set; }
    }
}
