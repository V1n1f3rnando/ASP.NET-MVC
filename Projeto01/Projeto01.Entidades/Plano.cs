using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Entidades
{
    public class Plano
    {
        public int IdPlano { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //associação (TER-Muitos)
        public List<Cliente> Cliente { get; set; }

        //construtor
        public Plano()
        {

        }

        //sobrecarga do construtor 
        public Plano(int idPlano, string nome, string descricao)
        {
            IdPlano = idPlano;
            Nome = nome;
            Descricao = descricao;
        }

        //sobrescrevendo o método ToString da classe object
        public override string ToString()
        {
            return string.Format("Id:{0}, Plano:{1}, Descição:{2}", IdPlano, Nome, Descricao);
        }
    }
}
