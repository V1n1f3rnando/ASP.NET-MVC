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
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;

        //Método para abrir conexão com o banco 
        protected void AbrirConexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString);
            con.Open();
        }

        //Método para fechar conexão com o banco
        protected void FecharConexao()
        {
            con.Close();
        }
    }
}
