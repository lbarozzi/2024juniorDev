
namespace Logistica.Interfaces
{
    public abstract class Veicolo
    {
        protected Veicolo(string tipologia , string marca, string modello, int annoProduzione, int numeroPersone, float maxVolume)
        {
            Tipologia = tipologia;
            Marca = marca;
            Modello = modello;
            AnnoProduzione = annoProduzione;
            NumeroPersone = numeroPersone;
            MaxVolume = maxVolume;
        }

        public string Tipologia { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public int AnnoProduzione { get; set; }
        public int NumeroPersone { get; set; }
        public float MaxVolume { get; set; }

        private float volume;
        private int persone;

        public void Carica(float q)
        {
            if (volume + q <= MaxVolume) volume += q;
        }

        public void Scarica(float q)
        {
            if (volume - q >= 0) volume -= q;
        }

        public float GetVolumeDisponibile()
        {
            return MaxVolume - volume;
        }

        public void Board(int q)
        {
            if(persone + q < NumeroPersone) persone += q;
        }
        
        public void Unboard(int q)
        {
            if (persone - q >= 0) persone -= q;
        }


        public int GetPersoneDisponibili()
        {
            return NumeroPersone - persone;
        }


        public override bool Equals(object? obj)
        {
            return obj is Veicolo veicolo &&
                   Tipologia == veicolo.Tipologia &&
                   Marca == veicolo.Marca &&
                   Modello == veicolo.Modello &&
                   AnnoProduzione == veicolo.AnnoProduzione &&
                   NumeroPersone == veicolo.NumeroPersone &&
                   MaxVolume == veicolo.MaxVolume;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Tipologia, Marca, Modello, AnnoProduzione, NumeroPersone, MaxVolume);
        }

        public override string ToString()
        {
            return $"Tipologia: {Tipologia}, Marca: {Marca}, Modello: {Modello}, Anno di Produzione: {AnnoProduzione}, Numero Persone: {NumeroPersone}, Max Volume: {MaxVolume}";
        }

    }
}
