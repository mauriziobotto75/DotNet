using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneComanda.Data
{
    // 1) Lookup / Archives
    public class TipiGestione { public int IdTipoGestione { get; set; } [Required, MaxLength(50)] public string Descrizione { get; set; } = null!; }
    public class CategorieScadenza { public int IdCategoria { get; set; } [Required, MaxLength(100)] public string Descrizione { get; set; } = null!; }
    public class TipiContatore { public int IdTipoContatore { get; set; } [Required, MaxLength(100)] public string Descrizione { get; set; } = null!; [Required, MaxLength(20)] public string UnitaMisura { get; set; } = null!; }
    public class TipiDocumento { public int IdTipoDocumento { get; set; } [Required, MaxLength(50)] public string Descrizione { get; set; } = null!; }
    public class RaggruppamentiMillesimali { public int IdRaggruppamento { get; set; } [Required, MaxLength(100)] public string Nome { get; set; } = null!; public string? Descrizione { get; set; } }
    public class CausaliContabili { public int IdCausale { get; set; } [Required, MaxLength(10)] public string Codice { get; set; } = null!; [Required, MaxLength(200)] public string Descrizione { get; set; } = null!; [Required, MaxLength(5)] public string Segno { get; set; } = null!; }

    // 2) Anagrafiche
    public class Amministratore
    {
        [Key] public int IdAmministratore { get; set; }
        [Required, MaxLength(200)] public string RagioneSociale { get; set; } = null!;
        [MaxLength(200)] public string? Indirizzo { get; set; }
        [MaxLength(100)] public string? Citta { get; set; }
        [MaxLength(10)] public string? CAP { get; set; }
        [MaxLength(30)] public string? Telefono { get; set; }
        [MaxLength(150)] public string? Email { get; set; }
        [MaxLength(20)] public string? PIVA { get; set; }
        [MaxLength(20)] public string? CodiceFiscale { get; set; }
        public DateTime DataCreazione { get; set; } = DateTime.UtcNow;

        public ICollection<Condominio>? Condomini { get; set; }
    }

    public class Persona
    {
        [Key] public int IdPersona { get; set; }
        [Required, MaxLength(100)] public string Nome { get; set; } = null!;
        [Required, MaxLength(100)] public string Cognome { get; set; } = null!;
        [MaxLength(20)] public string? CodiceFiscale { get; set; }
        [MaxLength(30)] public string? Telefono { get; set; }
        [MaxLength(150)] public string? Email { get; set; }
        [MaxLength(20)] public string? TipoPersona { get; set; }
    }

    public class Condominio
    {
        [Key] public int IdCondominio { get; set; }
        public int IdAmministratore { get; set; }
        [Required, MaxLength(200)] public string Nome { get; set; } = null!;
        [MaxLength(200)] public string? Indirizzo { get; set; }
        [MaxLength(100)] public string? Citta { get; set; }
        [MaxLength(10)] public string? CAP { get; set; }
        [MaxLength(50)] public string? CodiceCondominio { get; set; }
        public DateTime? DataAttivazione { get; set; }
        public string? Note { get; set; }
        public DateTime DataCreazione { get; set; } = DateTime.UtcNow;

        public Amministratore? Amministratore { get; set; }
        public ICollection<UnitaImmobiliare>? UnitaImmobiliari { get; set; }
        public ICollection<Gestioni>? Gestioni { get; set; }
    }

    public class UnitaImmobiliare
    {
        [Key] public int IdUnita { get; set; }
        public int IdCondominio { get; set; }
        [MaxLength(20)] public string? Scala { get; set; }
        [MaxLength(20)] public string? Interno { get; set; }
        [MaxLength(20)] public string? Piano { get; set; }
        public decimal? SuperficieMq { get; set; }
        public string? Note { get; set; }

        public Condominio? Condominio { get; set; }
        public ICollection<OccupazioneUnita>? Occupazioni { get; set; }
        public ICollection<RigaTabellaMillesimale>? RigheMillesimali { get; set; }
        public ICollection<Rate>? Rate { get; set; }
        public ICollection<LetturaContatore>? LettureContatori { get; set; }
    }

    // 3) Occupazioni & Subentri
    public class OccupazioneUnita
    {
        [Key] public int IdOccupazione { get; set; }
        public int IdUnita { get; set; }
        public int IdPersona { get; set; }
        [Required, MaxLength(20)] public string TipoOccupazione { get; set; } = null!;
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }

        public UnitaImmobiliare? Unita { get; set; }
        public Persona? Persona { get; set; }
    }

    public class Subentro
    {
        [Key] public int IdSubentro { get; set; }
        public int IdUnita { get; set; }
        public int IdCedente { get; set; }
        public int IdSubentrante { get; set; }
        public DateTime DataSubentro { get; set; }
        public decimal ConsumiDaRipartire { get; set; }
        public decimal ConguaglioProvvisorio { get; set; }
        public decimal ConguaglioDefinitivo { get; set; }

        public UnitaImmobiliare? Unita { get; set; }
        public Persona? Cedente { get; set; }
        public Persona? Subentrante { get; set; }
    }

    // 4) Gestioni
    public class Gestione
    {
        [Key] public int IdGestione { get; set; }
        public int IdCondominio { get; set; }
        public int IdTipoGestione { get; set; }
        [MaxLength(200)] public string? Descrizione { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        [MaxLength(20)] public string? Stato { get; set; }

        public Condominio? Condominio { get; set; }
        public TipiGestione? TipoGestione { get; set; }
        public ICollection<MovimentoContabile>? MovimentiContabili { get; set; }
        public ICollection<Rata>? Rate { get; set; }
    }

    // 5) Millesimi
    public class TabellaMillesimale
    {
        [Key] public int IdTabella { get; set; }
        public int IdCondominio { get; set; }
        public int? IdRaggruppamento { get; set; }
        [Required, MaxLength(200)] public string Nome { get; set; } = null!;
        public string? Descrizione { get; set; }

        public Condominio? Condominio { get; set; }
        public RaggruppamentiMillesimali? Raggruppamento { get; set; }
        public ICollection<RigaTabellaMillesimale>? Righe { get; set; }
    }

    public class RigaTabellaMillesimale
    {
        [Key] public int IdRiga { get; set; }
        public int IdTabella { get; set; }
        public int IdUnita { get; set; }
        public decimal ValoreMillesimale { get; set; }

        public TabellaMillesimale? Tabella { get; set; }
        public UnitaImmobiliare? Unita { get; set; }
    }

    // 6) Contatori e Letture
    public class Contatore
    {
        [Key] public int IdContatore { get; set; }
        public int IdCondominio { get; set; }
        public int IdTipoContatore { get; set; }
        [Required, MaxLength(100)] public string Nome { get; set; } = null!;

        public Condominio? Condominio { get; set; }
        public TipiContatore? TipoContatore { get; set; }
        public ICollection<LetturaContatore>? Letture { get; set; }
    }

    public class LetturaContatore
    {
        [Key] public int IdLettura { get; set; }
        public int IdContatore { get; set; }
        public int IdUnita { get; set; }
        public DateTime DataLettura { get; set; }
        public decimal Valore { get; set; }

        public Contatore? Contatore { get; set; }
        public UnitaImmobiliare? Unita { get; set; }
    }

    // 7) Contabilità
    public class PianoConto
    {
        [Key] public int IdConto { get; set; }
        public int IdCondominio { get; set; }
        [Required, MaxLength(20)] public string Codice { get; set; } = null!;
        [Required, MaxLength(200)] public string Descrizione { get; set; } = null!;
        [Required, MaxLength(20)] public string Tipo { get; set; } = null!;

        public Condominio? Condominio { get; set; }
        public ICollection<MovimentoContabile>? Movimenti { get; set; }
    }

    public class MovimentoContabile
    {
        [Key] public int IdMovimento { get; set; }
        public int IdGestione { get; set; }
        public int IdConto { get; set; }
        public int? IdCausale { get; set; }
        public DateTime DataMovimento { get; set; }
        public decimal Importo { get; set; }
        [Required, MaxLength(10)] public string TipoMovimento { get; set; } = null!; // Dare/Avere
        [MaxLength(300)] public string? Descrizione { get; set; }

        public Gestione? Gestione { get; set; }
        public PianoConto? Conto { get; set; }
        public CausaliContabili? Causale { get; set; }
    }

    // 8) Rate / Bollette / Solleciti
    public class Rata
    {
        [Key] public int IdRata { get; set; }
        public int IdGestione { get; set; }
        public int IdUnita { get; set; }
        public DateTime Scadenza { get; set; }
        public decimal Importo { get; set; }
        public bool Pagata { get; set; }

        public Gestione? Gestione { get; set; }
        public UnitaImmobiliare? Unita { get; set; }
        public ICollection<Bolletta>? Bollette { get; set; }
        public ICollection<Sollecito>? Solleciti { get; set; }
    }

    public class Bolletta
    {
        [Key] public int IdBolletta { get; set; }
        public int IdRata { get; set; }
        public DateTime DataEmissione { get; set; }
        [MaxLength(50)] public string? NumeroDocumento { get; set; }
        public decimal Importo { get; set; }

        public Rata? Rata { get; set; }
    }

    public class Sollecito
    {
        [Key] public int IdSollecito { get; set; }
        public int IdRata { get; set; }
        public DateTime DataSollecito { get; set; }
        public string? Testo { get; set; }
        [MaxLength(20)] public string? Stato { get; set; }

        public Rata? Rata { get; set; }
    }

    // 9) Scadenziario & Agenda
    public class Scadenza
    {
        [Key] public int IdScadenza { get; set; }
        public int IdCondominio { get; set; }
        public int IdCategoria { get; set; }
        [MaxLength(300)] public string? Descrizione { get; set; }
        public DateTime DataScadenza { get; set; }
        [MaxLength(20)] public string? Stato { get; set; }

        public Condominio? Condominio { get; set; }
        public CategorieScadenza? Categoria { get; set; }
    }

    public class AgendaIntervento
    {
        [Key] public int IdIntervento { get; set; }
        public int IdCondominio { get; set; }
        [Required, MaxLength(300)] public string Descrizione { get; set; } = null!;
        public DateTime? DataIntervento { get; set; }
        [MaxLength(20)] public string? Stato { get; set; }

        public Condominio? Condominio { get; set; }
    }

    // 10) Documenti
    public class Documento
    {
        [Key] public int IdDocumento { get; set; }
        public int IdCondominio { get; set; }
        public int IdTipoDocumento { get; set; }
        [Required, MaxLength(200)] public string Nome { get; set; } = null!;
        public DateTime DataCaricamento { get; set; } = DateTime.UtcNow;
        [MaxLength(500)] public string? PercorsoFile { get; set; }

        public Condominio? Condominio { get; set; }
        public TipiDocumento? TipoDocumento { get; set; }
    }
}
