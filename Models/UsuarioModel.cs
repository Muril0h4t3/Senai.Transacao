using System;
namespace Senai.Financas.web.Mvc.Models
{
    public class UsuarioModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}