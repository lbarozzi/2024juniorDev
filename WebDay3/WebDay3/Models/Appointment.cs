using Microsoft.AspNetCore.Identity;
using System.Data;

namespace WebDay3.Models {
    public class Appointment {
        public int AppointmentID { get; set; }
        public string Title { get; set; }
        public DateTime AppointementDate{ get; set; }
        public IdentityUser AppointmentUser { get; set; }
        public IdentityUser AppointmentGuestUser { get; set; }
    }
}
