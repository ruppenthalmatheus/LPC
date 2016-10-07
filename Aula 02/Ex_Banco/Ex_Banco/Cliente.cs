using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Banco
{
    class Cliente : Pessoa
    {
        #region Atributos

        public int token { get; set; }

        #endregion

        #region Construtores

        public Cliente(int pCodigo, string pNome, int pToken)
            :base(pCodigo, pNome)
        {
            token = pToken;
        }

        #endregion

        #region Métodos

        public override void save()
        {
            base.save();
        }

        #endregion
    }
}
