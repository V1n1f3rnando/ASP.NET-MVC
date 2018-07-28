using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto01.Entidades;
using System.Data.SqlClient;
using Projeto01.Entidades.Tipos;

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

        public List<Cliente> Buscar()
        {
            AbrirConexao();

            string query = "select c.IdCliente, c.Nome, c.Email, c.Sexo, c.EstadoCivil, c.DataCadastro," +
                " c.IdPlano, p.Nome as Plano from Cliente c inner join Plano p on p.IdPlano = c.IdPlano order by c.IdCliente";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Cliente> lista = new List<Cliente>();

            while (dr.Read())
            {
                Cliente c = new Cliente();
                c.Plano = new Plano();

                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.Sexo = (Sexo)Enum.Parse(typeof(Sexo), Convert.ToString(dr["Sexo"]));
                c.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), Convert.ToString(dr["EstadoCivil"]));
                c.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);
                c.Plano.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                c.Plano.Nome = Convert.ToString(dr["Plano"]);

                lista.Add(c);

            }

            FecharConexao();

            return lista;
        }
    }
}
