using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibLogistica {

    public enum TipoLuogo { Terra, Mare }
    public class Luogo {

        protected float _volumeOccupato;

        public int IdLuogo { get; set; }

        public string NomeLuogo { get; set; }

        public TipoLuogo Tipo { get; set; }

        public float VolumeOccupato {
            get {
                return _volumeOccupato;
            }
            set {
                if (value > MassimoVolume)
                    throw new ArgumentException("Capienza massima superata");
                else if (value < 0) 
                    throw new ArgumentException("Impossibile occupare una capienza negativa");
                _volumeOccupato = value;
            }
        }
        public float MassimoVolume { get; set; }

        public Luogo(int idLuogo, string nomeLuogo, TipoLuogo tipo, float volumeOccupato, float massimoVolume) {
            IdLuogo = idLuogo;
            NomeLuogo = nomeLuogo;
            Tipo = tipo;
            VolumeOccupato = volumeOccupato;
            MassimoVolume = massimoVolume;
        }

        public void CaricaMerce(float volume) {
            VolumeOccupato += volume;
        }

        public void ScaricaMerce(float volume) {
            VolumeOccupato -= volume;
        }

        public override string ToString() => $"Id: {IdLuogo}, Nome: {NomeLuogo}, Tipo: {Tipo}";
    }
}
