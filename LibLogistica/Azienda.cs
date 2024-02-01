namespace LibLogistica {

    public class Azienda {

        public Luogo Sede { get; set; }

        public int Id { get; set; }

        public String PIva { get; set; }

        public String Nome { get; set; }

        public Azienda(Luogo sede, int id, string pIva, string nome) {
            Sede = sede;
            Id = id;
            PIva = pIva;
            Nome = nome;
        }

        public override string ToString() => $"Id: {Id}, Nome: {Nome}, P.Iva: {PIva}, Sede: {Sede} ";
    }
}
