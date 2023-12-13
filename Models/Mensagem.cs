using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAjudaCerta.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public Pessoa Destinatario { get; set; }
        public int DestinatarioId { get; set; }
        public Pessoa Remetente { get; set; }
        public int RemetenteId { get; set; }
    }
}