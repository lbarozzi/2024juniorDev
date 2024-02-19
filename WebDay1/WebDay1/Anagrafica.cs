using System.ComponentModel.DataAnnotations;

namespace WebDay1 {
    public class Anagrafica {
        //[Key]
        public int AnagraficaID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DOB { get; set; }
        public override string ToString() { return $"{FirstName} {LastName} @ {DOB}"; }
    }

    public class Rubrica {
        public List<Anagrafica> Elenco { get; set; }
        public Rubrica() { 
            Elenco= new List<Anagrafica>();
        }
    }

}
