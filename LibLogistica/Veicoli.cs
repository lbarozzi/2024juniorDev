using Logistica.Interfaces;

namespace Logistica.Classes
{
    public class Terra : Veicolo
    {
        public Terra(string tipologia, string marca, string modello, int annoProduzione, int numPersone, int maxVolume,  int numeroRuote, string tipoTrasmissione) 
            : base(tipologia, marca, modello, annoProduzione, numPersone, maxVolume) { 
            NumeroRuote = numeroRuote;
            TipoTrasmissione = tipoTrasmissione;
        }

        public int NumeroRuote { get; set; }
        public string TipoTrasmissione { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, Numero Ruote: {NumeroRuote}, Tipo Trasmissione: {TipoTrasmissione}";
        }

    }


    public class Mare : Veicolo
    {
        public Mare(string tipologia, string marca, string modello, int annoProduzione, int numPersone, int maxVolume, string tipoPropulsione, double lunghezza)
        : base(tipologia, marca, modello, annoProduzione, numPersone, maxVolume)
        {
            TipoPropulsione = tipoPropulsione;
            Lunghezza = lunghezza;
        }

        public string TipoPropulsione { get; set; }
        public double Lunghezza { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} , Tipo Propulsione: {TipoPropulsione}, Lunghezza: {Lunghezza} metri";
        }
    }

    public class Aria : Veicolo
    {
        public Aria(string tipologia, string marca, string modello, int annoProduzione, int numPersone, int maxVolume, int numeroMotori, double aperturaAlare) 
            : base(tipologia, marca, modello, annoProduzione, numPersone, maxVolume)
        {
            NumeroMotori = numeroMotori;
            AperturaAlare = aperturaAlare;
        }

        public int NumeroMotori { get; set; }
        public double AperturaAlare { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} , Numero Motori: {NumeroMotori}, Apertura Alare: {AperturaAlare} metri";
        }
    }
}
