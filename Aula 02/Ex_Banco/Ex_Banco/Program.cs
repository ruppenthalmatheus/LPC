using System;

namespace Ex_Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Teste Cliente

            Cliente cl01 = new Cliente(100, "Ana da Silva", 1234);
            Cliente cl02 = new Cliente(200, "Matheus Ruppenthal", 1412);

            Console.WriteLine(cl01.codigo + ": " + cl01.nome);
            Console.WriteLine(cl02.codigo + ": " + cl02.nome);

            #endregion

            stop();

            #region Teste Cartão de Crédito

            CartaoCredito c1 = new CartaoCredito(123455677, DateTime.Today.AddYears(4), cl01);
            CartaoCredito c2 = new CartaoCredito(434343434, DateTime.Today.AddYears(4), cl02);

            Console.WriteLine(c1.numero + " -- Validade: " + c1.dataValidadeFormat + " Nome Cliente: " + c1.cliente.nome);
            Console.WriteLine(c2.numero + " -- Validade: " + c2.dataValidadeFormat + " Nome Cliente: " + c1.cliente.nome);

            #endregion

            stop();

            #region Teste Agências

            Agencia a1 = new Agencia("0795");
            Agencia a2 = new Agencia("0778");

            Console.WriteLine("Agencia 01: " + a1.numero);
            Console.WriteLine("Agencia 02: " + a2.numero);

            stop();

            #endregion
        }

        static void stop()
        {
            Console.ReadLine();
        }

    }
}
