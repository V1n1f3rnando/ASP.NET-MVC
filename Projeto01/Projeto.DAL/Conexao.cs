using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Projeto.DAL
{
    public class Conexao
    {
        protected SqlConnection con; // Conexão com o banco
        protected SqlCommand cmd; // executa comandos SQL
        protected SqlDataReader dr; // ler consultas
        protected SqlTransaction tr;// transações (commit, rollback)

        //método para abrir conexão com o banco
        protected void AbrirConexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString);
            con.Open();
        }

        protected void FecharConexao()
        {
            con.Close();
        }
    }
}
