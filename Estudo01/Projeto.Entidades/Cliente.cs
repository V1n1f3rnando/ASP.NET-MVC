using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entidades.Tipos;

namespace Projeto.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Sexo Sexo { get; set; }
        //Relacionamento entre as entidades Cliente e Plano 1 para n 
        public Plano Plano { get; set; }

        public Cliente()
        {

        }

        // Sobrecarregando o construtor 
        public Cliente(int idCliente, string nome, string email, DateTime dataCadastro, EstadoCivil estadoCivil, Sexo sexo)
        {
            IdCliente = idCliente;
            Nome = nome;
            Email = email;
            DataCadastro = dataCadastro;
            EstadoCivil = estadoCivil;
            Sexo = sexo;
        }

        //Sobrescrevendo o método ToString. 
        public override string ToString()
        {
            return $"ID:{IdCliente}, Nome:{Nome}, Email:{Email}, DataCadastro:{DataCadastro}" +
                $"Sexo:{Sexo}, Estado Civil:{EstadoCivil}";
        }
    }
}
