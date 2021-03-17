
using System;

namespace Projeto
{
    public class Prog
    {
        static void Main(string[] args)
        {
            
            Console.Write("Insira as coordenadas: ");
            var x = Console.ReadLine();

            Evaluate coordenada = new Evaluate(x);

            Console.WriteLine(Evaluate.PosicaoCartesiana(x));


        }
    }
}
