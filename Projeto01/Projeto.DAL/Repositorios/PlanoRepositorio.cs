using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto01.Entidades;
using System.Data.SqlClient;

namespace Projeto.DAL.Repositorios
{
    public class PlanoRepositorio : Conexao
    {
        public void Inserir(Plano p)
        {
            AbrirConexao();

            string query = "insert into Plano values(Nome, Descricao) values (@Nome, @Descricao)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome",p.Nome);
            cmd.Parameters.AddWithValue("@Descricao", p.Descricao);
            cmd.ExecuteNonQuery();

            FecharConexao();
        }

        public void Alterar(Plano p)
        {
            AbrirConexao();

            string query = "update Plano set Nome = @Nome, Descicao = @Descricao where IdPlano = @IdPano";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdPlano", p.IdPlano);
            cmd.Parameters.AddWithValue("@Nome",p.Nome);
            cmd.Parameters.AddWithValue("@Descricao", p.Descricao);
            cmd.ExecuteNonQuery();

            FecharConexao();
        }

        public void Deletar(int id)
        {
            AbrirConexao();

            string query = "delete from Plano where IdPlano = @IdPlano";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdPlano", id);
            cmd.ExecuteNonQuery();
        }

        public List<Plano> Buscar()
        {
            AbrirConexao();

            string query = "select * from Plano";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Plano> lista = new List<Plano>();
            while (dr.Read())
            {
                var plano = new Plano();

                plano.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                plano.Nome = Convert.ToString(dr["Nome"]);
                plano.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(plano);

            }

            FecharConexao();

            return lista;
        }

        public Plano BuscarPorId(int id)
        {
            AbrirConexao();

            string query = "select * from Plano where IdPlano = @IdPlano";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdPlano", id);
            dr = cmd.ExecuteReader();

            Plano p = null;

            if (dr.Read())
            {
                p = new Plano();

                p.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                p.Nome = Convert.ToString(dr["Nome"]);
                p.Descricao = Convert.ToString(dr["Descricao"]);
            }

            FecharConexao();

            return p;
        }
    }
}
