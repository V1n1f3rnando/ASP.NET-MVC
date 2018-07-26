using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto01.Entidades; //Importando
using System.Data.SqlClient; //Importando

namespace Projeto.DAL.Repositorios
{
    public class PlanoRepositorio : Conexao
    {
        public void Inserir(Plano p)
        {
            //Abrindo conexão com o banco
            AbrirConexao();

            //Comando SQL para inserir dados
            string query = "insert into Plano (Nome, Descricao) values(@Nome, @Descricao)";

            //Executando query
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome",p.Nome);
            cmd.Parameters.AddWithValue("@Descricao", p.Descricao);
            cmd.ExecuteNonQuery();

            //fechando conexão
            FecharConexao();
        }

        public void Alterar(Plano p)
        {
            
            AbrirConexao();

            string query = "update Plano set Nome = @Nome, Descricao = @Descricao where IdPlano = @IdPlano";

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
            //Abrindo conexão
            AbrirConexao();

            //Comando SQL
            string query = "select * from Plano";

            //Solicitando resposta 
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            //Listando planos
            List<Plano> lista = new List<Plano>();
            while (dr.Read())
            {
                var plano = new Plano();

                plano.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                plano.Nome = Convert.ToString(dr["Nome"]);
                plano.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(plano);

            }

            //Fechando conexão 
            FecharConexao();

            //Retornando o resultado
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
