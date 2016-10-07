using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Banco
{
    abstract class Pessoa
    {

        #region Atributos

        public int codigo { get; set; }
        public string nome { get; set; }

        #endregion

        #region Construtores

        public Pessoa()
        { }

        public Pessoa(int pCodigo, string pNome)
        {
            codigo = pCodigo;
            nome = pNome;
        }

        #endregion

        #region Métodos

        public virtual void save()
        {

        }

        #endregion

    }
}
