namespace WebDay2.Models {
    public record class Student {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
