using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5
{
    public class Exemplar
    {
        public int tombo { get; set; }
        public List<Emprestimo> emprestimos { get; }

        public Exemplar(int _tombo)
        {
            tombo = _tombo;
            emprestimos = new List<Emprestimo>();
        }

        public bool disponivel()
        {
            if (emprestimos.Count == 0 || emprestimos[emprestimos.Count - 1].dtDevolucao == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool emprestar()
        {
            if (disponivel())
            {
                Emprestimo data_atual = new Emprestimo(DateTime.Now);
                emprestimos.Add(data_atual);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool devolver()
        {
            if (disponivel())
            {
                return false;
            }
            else
            {
                emprestimos[emprestimos.Count - 1].dtDevolucao = DateTime.Now;
                return true;
            }
        }

        public int qtdeEmprestimos()
        {
            return emprestimos.Count;
        }
    }
}
