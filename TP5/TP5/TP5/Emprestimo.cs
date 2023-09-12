using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5
{
    public class Emprestimo
    {
        public DateTime dtEmprestimo { get; set; }
        public DateTime dtDevolucao { get; set; }

        public Emprestimo(DateTime _dtEmprestimo)
        {
            dtEmprestimo = _dtEmprestimo;
        }

        public Emprestimo(DateTime _dtEmprestimo, DateTime _dtDevolucao)
        {
            dtEmprestimo = _dtEmprestimo;
            dtDevolucao = _dtDevolucao;
        }
    }
}
