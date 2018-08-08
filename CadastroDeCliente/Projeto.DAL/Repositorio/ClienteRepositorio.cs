using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entidades.Tipos;
using Projeto.Entidades;
using System.Data.SqlClient;

namespace Projeto.DAL.Repositorio
{
    public class ClienteRepositorio : Conexao
    {
        public void Inserir(Cliente c)
        {
            AbrirConexao();

            string query = "Insert into Cliente (Nome, Email, Sexo, EstadoCivil)" +
                " values (@Nome, @Email, @Sexo, @EstadoCivil)";

            cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("Nome", c.Nome);
            cmd.Parameters.AddWithValue("Email", c.Email);
            cmd.Parameters.AddWithValue("Sexo", c.Sexo.ToString());
            cmd.Parameters.AddWithValue("EstadoCivil", c.EstadoCivil.ToString());
            cmd.ExecuteNonQuery();

            FecharConexao();
        }

        //Método para verificar se um email já existe na base de dados
        public bool VerificaEmail(string email)
        {
            AbrirConexao();

            string query = "select count(Email) from Cliente where Email = @Email";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("Email", email);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            FecharConexao();

            return count > 0;
        }

        public List<Cliente> Buscar()
        {
            AbrirConexao();

            string query = "select * from Cliente ";

            cmd = new SqlCommand(query,con);
            dr = cmd.ExecuteReader();

            List<Cliente> lista = new List<Cliente>();

            while (dr.Read())
            {
                var c = new Cliente();

                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), Convert.ToString(dr["EstadoCivil"]));
                c.Sexo = (Sexo)Enum.Parse(typeof(Sexo), Convert.ToString(dr["Sexo"]));

                lista.Add(c);
            }

            FecharConexao();

            return lista;
        }
    }
}
