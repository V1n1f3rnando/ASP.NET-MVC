using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto01.Entidades;
using System.Data.SqlClient;

namespace Projeto.DAL.Repositorios
{
    public class ClienteRepositorio : Conexao
    {
        public void Inserir(Cliente c)
        {
            AbrirConexao();

            string query = "insert into Cliente (Nome, Email, Sexo, EstadoCivil, DataCadastro, IdPlano) values(@Nome, @Email, @Sexo, @EstadoCivil, @DataCadastro, @IdPlano)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Sexo", c.Sexo.ToString().Trim()); // removendo espaço 
            cmd.Parameters.AddWithValue("@EstadoCivil", c.EstadoCivil.ToString().Trim()); //removendo espaço
            cmd.Parameters.AddWithValue("@DataCadastro", c.DataCadastro);
            cmd.Parameters.AddWithValue("@IdPlano", c.Plano.IdPlano);
            cmd.ExecuteNonQuery();

            FecharConexao();
        }
    }
}
