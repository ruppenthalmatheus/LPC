using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula02_introducao
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal total = soma(10, 5);
            myWrite("Total da soma: " + total);
        }

        /// <summary>
        /// Matheus
        /// 12/08
        /// Método para somar dois valores.
        /// </summary>
        /// <param name="num1">Passa um número decimal</param>
        /// <param name="num2">Passa um segundo número decimal</param>
        /// <returns></returns>
        private static decimal soma(decimal num1, decimal num2)
        {
            return num1 + num2;
        }

        private static void myWrite(string pMsg)
        {
            Console.WriteLine(pMsg);
            Console.ReadLine();
        }

        private void test()
        {
            Veiculo fusca = new Veiculo(100, "Fusca X");
            fusca.ligar();
            fusca.parar();

            fusca.dataRevisao = DateTime.Today;

            myWrite(fusca.modelo);
        }

    }
}
