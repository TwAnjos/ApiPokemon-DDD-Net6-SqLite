using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class Notifies
    {
        public Notifies()
        {
            ListNotifies = new List<Notifies>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string MensagemPropriedade { get; set; }

        [NotMapped]
        public List<Notifies> ListNotifies { get; set; }

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                ListNotifies.Add(new Notifies
                {
                    MensagemPropriedade = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidarPropriedadeiNT(int valor, string nomePropriedade)
        {
            if (valor <= 0 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                ListNotifies.Add(new Notifies
                {
                    MensagemPropriedade = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
    }
}