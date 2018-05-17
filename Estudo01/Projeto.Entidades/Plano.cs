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
        //Relacionamento de associação entre as entidades Cliente e Plano. 
        public List<Cliente> Cliente { get; set; }

        public Plano()
        {

        }

        public Plano(int idPlano, string nome, string descricao)
        {
            IdPlano = idPlano;
            Nome = nome;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"ID:{IdPlano}, Nome:{Nome}, Descrição:{Descricao}";
        }
    }
}
