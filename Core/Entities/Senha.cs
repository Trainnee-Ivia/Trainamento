using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Senha
    {
        private String m_senha, m_senhacrypto;
        private System.Byte[] tmpsource;
        private System.Byte[] tmphash;

        public String senhacrypto
        {
            get { return m_senhacrypto; }
        }

        public Senha(String senha)
        {
            m_senha = senha;
            criptografar();
        }

        private void criptografar()
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            tmpsource = System.Text.ASCIIEncoding.ASCII.GetBytes(m_senha);
            tmphash = md5.ComputeHash(tmpsource);

            System.Text.StringBuilder sb = new System.Text.StringBuilder(tmphash.Length);

            for (int i = 0; i <= tmphash.Length - 1; i++)
            {
                sb.Append(tmphash[i].ToString("X2"));
            }
            m_senhacrypto = sb.ToString();
        }
    }
}
