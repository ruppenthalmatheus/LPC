using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula02_introducao
{
    public class Veiculo
    {

        #region Atributos

        public int id { get; private set; }
        public string modelo { get; private set; }
        public DateTime dataRevisao { get; set; }

        #endregion

        #region Construtores

        public Veiculo(int pId, string pModelo)
        {
            id = pId;
            modelo = pModelo;
        }

        public Veiculo()
        {

        }
        #endregion

        #region Metodos

        public void ligar()
        {

        }

        public void parar()
        {

        }

        #endregion


    }
}
