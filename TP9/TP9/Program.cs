using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP9.Models;
using TP9;

namespace TP9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jornada = new Jornada();

            var seletor = new Seletor(jornada);

            int opcao = -1;
            while (opcao != 0)
            {
                opcao = seletor.EscolherOpcao();
            }

        }
    }
}
