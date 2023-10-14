using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP7
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();

            int opcao = 1;
            while (opcao != 0)
            {
                
                Console.WriteLine("0\tFinalizar\r\n1\tCadastrar Medicamento\r\n2\tConsultar Medicamento (sintético)¹\r\n3\tConsultar Medicamento (analítico)²\r\n4\tComprar medicamento\r\n5\tVender medicamento\r\n6\tListar medicamentos\n");
                Console.Write("\nDigite a opção: ");
                opcao = int.Parse(Console.ReadLine());

                separador();

                switch (opcao)
                {
                    case 0:
                        finalizar();
                        break;
                    case 1:
                        cadastrarMedicamentos(medicamentos);
                        break;
                    case 2:
                        consultarMedicamentoSintetico(medicamentos);
                        break;
                    case 3:
                        consultarMedicamentoAnalitico(medicamentos);
                        break;
                    case 4:
                        comprarMedicamento(medicamentos);
                        break;
                    case 5:
                        venderMedicamento(medicamentos);
                        break;
                    case 6:
                        listarMedicamentos(medicamentos);
                        break;
                    default:
                        Console.WriteLine("\n\nopção invalida, por favor selecione um valor entre 0 e 6\n\n");
                        break;
                }

                separador();
            }
        }

        private static void listarMedicamentos(Medicamentos medicamentos)
        {
            if (medicamentos.listaMedicamentos.Count() <= 0)
            {
                Console.WriteLine("\nNão há medicamentos a serem listados!");
            }
            else
            {
                Console.WriteLine("ID - NOME - LABORATORIO - QTDE DISPONÍVEL");
                foreach (var medicamento in medicamentos.listaMedicamentos)
                {
                    Console.WriteLine("\n" + medicamento.ToString());
                }
            }
        }

        private static void venderMedicamento(Medicamentos medicamentos)
        {
            Medicamento medicamento = consultarMedicamentoPeloId(medicamentos);
            int qtdeVenda = 0;

            if (medicamento == null)
            {
                Console.WriteLine("\nMedicamento não encontrado!");
            }

            Console.Write("Digite a qtde da venda: ");
            qtdeVenda = int.Parse(Console.ReadLine());

            bool vendaSucesso = medicamento.vender(qtdeVenda);

            if (vendaSucesso)
            {
                Console.WriteLine("\nVenda realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nQtde da venda maior que a quantidade disponivel!");
            }
        }

        private static void comprarMedicamento(Medicamentos medicamentos)
        {
            Medicamento medicamento = consultarMedicamentoPeloId(medicamentos);
            Lote lote = new Lote();

            if (medicamento == null)
            {
                Console.WriteLine("\nMedicamento não encontrado!");
            }

            Console.Write("Digite id do lote: ");
            lote.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade do lote: ");
            lote.Qtde = int.Parse(Console.ReadLine());

            Console.Write("Digite o dia do vencimento do lote: ");
            int dia = int.Parse(Console.ReadLine());

            Console.Write("Digite o mes do vencimento do lote: ");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano do vencimento do lote: ");
            int ano = int.Parse(Console.ReadLine());

            lote.Vencimento = new DateTime(ano, mes, dia);

            medicamento.comprar(lote);

            Console.WriteLine("\nLote adicionada com sucesso!");
        }

        private static void consultarMedicamentoAnalitico(Medicamentos medicamentos)
        {
            Medicamento medicamento = consultarMedicamentoPeloId(medicamentos);

            if (medicamento == null)
            {
                Console.WriteLine("\nMedicamento não encontrado!");
            }
            else
            {
                Console.WriteLine("\n" + medicamento.ToString());
                Console.WriteLine("Lotes:");

                if (medicamento.Lotes.Count() <= 0)
                {
                    Console.WriteLine("\tMedicamento não possui lotes!");
                }
                else
                {
                    foreach (var lote in medicamento.Lotes)
                    {
                        Console.WriteLine("\t" + lote.ToString());
                    }
                }
            }
        }

        private static void consultarMedicamentoSintetico(Medicamentos medicamentos)
        {
            Medicamento medicamento = consultarMedicamentoPeloId(medicamentos);

            if (medicamento == null)
            {
                Console.WriteLine("\nMedicamento não encontrado!");
            }
            else
            {
                Console.WriteLine("\n" + medicamento.ToString());
            }
        }

        private static Medicamento consultarMedicamentoPeloId(Medicamentos medicamentos)
        {
            Medicamento medicamento = new Medicamento();

            Console.Write("Digite id do medicamento: ");
            medicamento.Id = int.Parse(Console.ReadLine());

            return medicamentos.pesquisar(medicamento);
        }

        private static void cadastrarMedicamentos(Medicamentos medicamentos)
        {
            Medicamento medicamento = new Medicamento();

            Console.Write("Digite id do medicamento: ");
            medicamento.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do medicamento: ");
            medicamento.Nome = Console.ReadLine();

            Console.Write("Digite o nome do laboratorio: ");
            medicamento.Laboratorio = Console.ReadLine();

            medicamentos.adicionar(medicamento);

            Console.WriteLine("\nMedicamento adicionada com sucesso!");
        }

        private static void finalizar()
        {
            Console.WriteLine("Obrigado por usar o programa...");
            Console.WriteLine("Até a proxima :)");
            Console.ReadKey();
        }


        private static void separador()
        {
            Console.WriteLine();
            for (int i = 0; i < 35; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("\n");
        }
        
    }
}
