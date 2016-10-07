using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Banco
{
    class Conta
    {
        #region Atributos

        public string numero { get; set; }
        public decimal saldo { get; set; }
        public decimal limite { get; set; }

        #endregion

        #region Construtores

        public Conta(string pNumero, decimal pSaldo, decimal pLimite)
        {
            numero = pNumero;
            saldo = pSaldo;
            if (pLimite == 0)
                limite = 100;
            else
                limite = pLimite;
        }

        #endregion

        #region Métodos

        public void deposito(decimal pValor)
        {
            saldo += pValor;
        }

        public void saque(decimal pValor)
        {
            saldo -= pValor;
        }

        #endregion
    }
}
