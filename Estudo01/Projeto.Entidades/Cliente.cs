using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        //Relacionamento entre as entidades Cliente e Plano 1 para n 
        public Plano Plano { get; set; }

        public Cliente()
        {

        }
    }
}
