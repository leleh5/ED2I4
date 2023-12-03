using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Final.Models;

namespace TP_Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var locacaoController = new LocacaoController();

            var seletor = new Seletor(locacaoController);

            int opcao = -1;
            while (opcao != 0)
            {
                opcao = seletor.EscolherOpcao();
            }

        }
    }
}