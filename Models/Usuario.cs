using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAjudaCerta.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte []? Senha_Hash { get; set; }
        public byte []? Senha_Salt { get; set; }
        public DateTime UltimoAcesso { get; set; }
        [NotMapped]
        public int? NumeroTentativas { get; set; }
        [NotMapped]
        public Boolean? bloqueado { get; set; }
        [NotMapped]
        public string Senha { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public byte[]? Foto { get; set; }
        public List<Pessoa> Pessoas { get; set; }

    }
}