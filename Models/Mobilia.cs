using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAjudaCerta.Models.Enuns;

namespace ApiAjudaCerta.Models
{
    public class Mobilia
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Medida { get; set; }
        public string Condicao { get; set; }
        public StatusItemEnum StatusItem { get; set; }
        public ItemDoacao ItemDoacao { get; set; }
        public int ItemDoacaoId { get; set; }
    }
}