using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAjudaCerta.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public byte[]? Foto { get; set; }
        public DateTime DataPostagem { get; set; }
        public int Likes { get; set; }
    }
}