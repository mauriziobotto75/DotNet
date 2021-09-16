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
