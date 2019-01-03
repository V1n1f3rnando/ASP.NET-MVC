using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace AutenticaUsuario.WEB.Util
{
    public class Criptografia
    {
       public static string EncriptarSenha(string senha)
        {
            //Convertendo a senha para bytes
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);

            //encriptando a senha
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(senhaBytes);

            string conteudo = string.Empty;

            foreach ( byte b in hash)
            {
                conteudo += b.ToString("X");//hexadecimal
            }

            return conteudo;
        }
     
    }
}