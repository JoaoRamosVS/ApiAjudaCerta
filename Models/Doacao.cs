using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAjudaCerta.Models.Enuns;

namespace ApiAjudaCerta.Models
{
    public class Doacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public StatusDoacaoEnum StatusDoacao { get; set; }
        public TipoDoacaoEnum TipoDoacao { get; set; }
        public StatusDoacaoEnum IdDoacaoOrigem { get; set; }
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public Agenda Agenda { get; set; }
        public int AgendaId { get; set; }
        public double Dinheiro { get; set; }
        public List<ItemDoacaoDoado> ItemDoacaoDoados { get; set; }
    }
}