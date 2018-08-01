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
        //Encapsulamento inplícito 
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

        //Construtor default
        public Cliente()
        {

        }

        //SObrecarga de contrutor 
        public Cliente(int idCliente, string nome, string email, Sexo sexo, EstadoCivil estadoCivil)
        {
            IdCliente = idCliente;
            Nome = nome;
            Email = email;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
        }

        //Sobrescrita do método ToString da classe object
        public override string ToString()
        {
            return $"ID:{IdCliente}, Nome:{Nome}, Email:{Email}, Sexo:{Sexo}, EstadoCivil:{EstadoCivil}";
        }
    }
}
