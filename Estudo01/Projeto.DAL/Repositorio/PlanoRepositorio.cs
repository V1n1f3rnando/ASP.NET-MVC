using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //sqlserver
using Projeto.Entidades; // Classes


namespace Projeto.DAL.Repositorios
{
    public class PlanoRepositorio : Conexao
    {
        //Método para inserir registro
        public void Inserir(Plano p)
        {
            AbrirConexao();

            string query = "insert into Plano(Nome, Descricao) " +
                "values(@Nome, @Descricao)";

            //Executando Query
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.Parameters.AddWithValue("@Descricao", p.Descricao);
            cmd.ExecuteNonQuery();

            FecharConexao();
        }

        //Método para atualizar um plano na tabela
        public void Atualizar(Plano p)
        {
            AbrirConexao();

            string query = "update Plano set Nome = @Nome, Descricao = @Descricao" +
                " where IdPlano = @IdPlano";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdPlano", p.IdPlano);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.Parameters.AddWithValue("@Descricao", p.Descricao);
            cmd.ExecuteNonQuery();

            FecharConexao();

        }

        // Método para excluir um plano
        public void Excluir(int id)
        {
            AbrirConexao();

            string query = "delete from Plano where IdPlano = @IdPlano";

            cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@IdPlano", id);
            cmd.ExecuteNonQuery();

            FecharConexao();
        }

        //Listando todos os registros da tabela
        public List<Plano> Listar()
        {
            AbrirConexao();

            string query = "select * from Plano";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            //Criando lista de planos
            List<Plano> lista = new List<Plano>();

            // Varrendo a consulta
            while (dr.Read())
            {
                Plano p = new Plano(); // instanciando 

                p.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                p.Nome = Convert.ToString(dr["Nome"]);
                p.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(p);
            }

            FecharConexao();

            return lista; // retornando a lista

        }

        //Método para mostrar registro por id
        public Plano Selecionar(int id)
        {
            AbrirConexao();

            string query = "select * from Plano where IdPlano = @IdPlano";

            cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@IdPlano", id);
            dr = cmd.ExecuteReader();

            //Declarando um objeto plano
            Plano p = null; // Sem alocar memória

            if (dr.Read())
            {
                p = new Plano();

                p.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                p.Nome = Convert.ToString(dr["Nome"]);
                p.Descricao = Convert.ToString(dr["Descricao"]);
            }

            FecharConexao();
            return p; // retornando Plano
            
        }


    }
}
