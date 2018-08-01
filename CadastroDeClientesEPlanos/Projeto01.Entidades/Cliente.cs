using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto01.Entidades.Tipos; // importando 

namespace Projeto01.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public DateTime DataCadastro { get; set; }

        // relacionamento de associação (Ter-1)
        public Plano Plano { get; set; }

        //Construtor
        public Cliente()
        {

        }

        //Sobrecarregando o construtor 
        public Cliente(int idCliente, string nome, string email, Sexo sexo, EstadoCivil estadoCivil, DateTime dataCadastro)
        {
            IdCliente = idCliente;
            Nome = nome;
            Email = email;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            DataCadastro = dataCadastro;
        }

        //Sobrecarga do método ToString da classe object
        public override string ToString()
        {
            return $"Id:{IdCliente}\n Nome:{Nome}\n Email:{Email}\n" +
                $" Sexo:{Sexo}\n EstadoCivil:{EstadoCivil}\n Data de cadastro:{DataCadastro}";
        }
    }
}
