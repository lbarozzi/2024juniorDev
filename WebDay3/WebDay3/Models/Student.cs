namespace WebDay3.Models {
    public record class Student {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public override string ToString() { return $"{FirstName} {LastName}"; }
    }
}
