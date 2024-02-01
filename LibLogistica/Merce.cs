using System.Text;

namespace logistica;

public class Merce
{

    //Barcode or qrcode
    public string Id { get; set; }
    public string Code { get; set; }

    public DateTime DataScadenza { get; set; }
    public string DescCategoria { get; set; }

    public string Label { get; set; }
    public float Volume { get; set; } //IN LITRI
    public float Peso { get; set; } //IN KG
    public EnumLivelloPericolo LivelloPericolo { get; set; }
    public TipoConservazione Conservazione { get; set; }
    public EnumTipoImballo TipoImballo { get; set; }

    public void GeneraId()
    {
        this.Id = Guid.NewGuid().ToString();
    }

    public bool CheckVolume(int volumerif)
    {
        return volumerif <= this.Volume;
    }

    public bool CheckPeso(int pesorif)
    {
        return pesorif <= this.Peso;
    }

    public bool IsPericoloAlto()
    {
        return this.LivelloPericolo == EnumLivelloPericolo.ALTO;
    }

    public bool IsPericoloMedioAlto()
    {
        return this.LivelloPericolo == EnumLivelloPericolo.ALTO || this.LivelloPericolo == EnumLivelloPericolo.MEDIO;
    }

    public bool IsFresco()
    {
        return this.Conservazione == TipoConservazione.FRESCO;
    }

    public bool IsDeperibile()
    {
        return this.Conservazione == TipoConservazione.FRESCO || this.Conservazione == TipoConservazione.CONGELATO;
    }

    public bool IsImballoPlastica()
    {
        return this.TipoImballo == EnumTipoImballo.BUSTA || this.TipoImballo == EnumTipoImballo.BUSTA_IMBOTTITA;
    }

    public bool IsRiciclabile()
    {
        return this.TipoImballo == EnumTipoImballo.BUSTA || this.TipoImballo == EnumTipoImballo.BUSTA_IMBOTTITA || this.TipoImballo == EnumTipoImballo.SCATOLA;
    }

    public string GeneraEtichetta()
    {
        StringBuilder s = new StringBuilder();
        s.Append("Codice: " + this.Code + "\n");
        s.Append("Label: " + this.Label + "\n");
        s.Append("Volume: " + this.Volume + "\n");
        s.Append("Descrizione: " + this.DescCategoria + " Kg\n");
        s.Append("Peso: " + this.Peso + "\n");
        s.Append("Livello pericolo: " + this.LivelloPericolo + "\n");
        s.Append("Livello conservazione: " + this.Conservazione + "\n");
        s.Append("Tipo imballo: " + this.TipoImballo + "\n");
        s.Append("Data scadenza: " + this.DataScadenza + "\n");
        return s.ToString();
    }




    public enum EnumLivelloPericolo
    {
        BASSO,
        MEDIO,
        ALTO
    }

    public enum TipoConservazione
    {
        FRESCO,
        CONGELATO,
        AMBIENTE,
        AMBIENTE_CONTROLLATO,
    }

    public enum EnumTipoImballo
    {
        SCATOLA,
        BUSTA,
        BUSTA_IMBOTTITA,
    }

}

