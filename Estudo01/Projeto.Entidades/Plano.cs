using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Plano
    {
        public int IdPlano { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        //Relacionamento entre as entidades Cliente e Plano 1 para n 
        public List<Cliente> Cliente { get; set; }

        public Plano()
        {

        }
    }
}
