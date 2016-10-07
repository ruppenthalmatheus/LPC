using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Banco
{
    class Agencia
    {
        #region Atributos

        public string numero { get; set; }

        #endregion

        #region Construtores
        
        public Agencia(string pNumero)
        {
            numero = pNumero;
        }

        #endregion
    }
}
