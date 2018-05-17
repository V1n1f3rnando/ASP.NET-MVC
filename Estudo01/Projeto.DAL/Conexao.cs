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

        //Método para abrir a conexão com o banco.
        protected void AbrirConexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["banco"]
                .ConnectionString);
            con.Open(); //conectado
        }

        protected void FecharConexao()
        {
            con.Close(); //desconectado
        }
    }
}
