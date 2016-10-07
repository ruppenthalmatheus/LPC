using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Banco
{
    class CartaoCredito
    {
        #region Atributos

        public int numero { get; set; }
        public DateTime dataValidade { get; set; }
        public Cliente cliente { get; set; }

        public string dataValidadeFormat
        {
            get { return dataValidade.ToShortDateString(); }
        }

        #endregion

        #region Construtores

        public CartaoCredito(int pNumero, DateTime pDataValidade, Cliente pCliente)
        {
            numero = pNumero;
            dataValidade = pDataValidade;
            cliente = pCliente;
        }

        #endregion


    }
}
