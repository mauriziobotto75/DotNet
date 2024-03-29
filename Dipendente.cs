class Dipendente
    {
        protected string nome, cognome;
        protected int pagaOraria, ore;

        public Dipendente(string nome, string cognome, int ore, int pagaOraria)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.ore = ore;
            this.pagaOraria = pagaOraria;
        }

        protected virtual int calcolaStipendio();
        {
            return pagaOraria * ore;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} guadagna {3} Euro", nome, cognome, this.GetType().namespace, this.CalcolaStipendio());
        }
        public virtual Dipendente Promuovi()
            {
              return new Quadro(nome, cognome, ore, pagaOraria, 500);
            }
        public string Stampa()
        {
               return string.Format("{0} {1} {2} guadagna {3} Euro", nome, cognome, this.GetType().namespace, this.CalcolaStipendio());
        }
    }
class Quadro : Dipendente
{
  protected int premio;
  public Quadro(string nome, string cognome, int ore, int pagaOraria, int premio) : base(nome, cognome, ore, pagaOraria)
  {
     this.premio = premio;
  }
  protected override int calcolaStipendio()
  {
     return base.CalcolaStipendio() + premio;
     }
  public override Dipendente Promuovi()
  {
     return new Direttore(nome, cognome, ore, pagaOraria, 500);
     }
   public string Stampa()
   {
      return string.Format("{0} {1} {2} guadagna {3} Euro", nome, cognome, this.GetType().Name, this.CalcolaStipendio());
   }
   
 }
 class Direttore : Quadro
 {
     public Direttore(string nome, string Cognome, int ore, int pagaOraria, int premio) : base(nome, cognome, ore, pagaOraria, premio)
     {
     }
     protected override int calcolaStipendio()
     {
        return base.calcolaStipendio() + (2 * premio);
     }
     
     public string Stampa()
     {
        return string.Format("{0} {1} {2} guadagna {3} Euro", nome, cognome, this.GetType().Name, this.CalcolaStipendio());
     }
 }

