using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAjudaCerta.Models
{
    public class ItemDoacaoDoado
    {
        public int DoacaoId { get; set; }
        public Doacao Doacao { get; set; }
        public int ItemDoacaoId { get; set; }
        public ItemDoacao ItemDoacao { get; set; }
    }
}