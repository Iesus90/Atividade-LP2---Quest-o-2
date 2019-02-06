using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Atividade1
{
    public class Agencia
    {

        private int idAgencia;
        List<ContaCorrente> contas_corrente = new List<ContaCorrente>();
        List<ContaPoupanca> contas_poupanca = new List<ContaPoupanca>();
        List<Solicitacao> solicitacoes = new List<Solicitacao>();

        public void AdicionarContaCorrente(ContaCorrente cc)
        {
            contas_corrente.Add(cc);
            Console.WriteLine("Conta " + cc.Id + " de titular " + cc.Titular + " criada com sucesso!");
        }

        public void AdicionarContaPoupanca(ContaPoupanca cp)
        {
            contas_poupanca.Add(cp);
            Console.WriteLine("Conta " + cp.Id + " de titular " + cp.Titular + " criada com sucesso!");
        }

        public ContaCorrente getCorrente(int num)
        {
            ContaCorrente cc = null;
            foreach (var e in contas_corrente)
            {
                if (e.Id == num)
                {
                    cc = e;
                    return cc;
                }
            }

            Console.WriteLine("O a conta não está cadastrada! Verifique seu número!");
            return null;



        }
        public ContaPoupanca getPoupanca(int num)
        {
            ContaPoupanca cp = null;
            foreach (var e in contas_poupanca)
            {
                if (e.Id == num)
                {
                    cp = e;
                    return cp;
                }
            }
            Console.WriteLine("O a conta não está cadastrada! Verifique seu número!");
            return null;

        }



        [Key]
        public int IdAgencia {
            get { return idAgencia; }
            set { idAgencia = value; }
        }

        public List<ContaCorrente> ContaCorrentes { get; set; }
        public List<ContaPoupanca> ContaPoupancas { get; set; }
        public List<Solicitacao> Solicitacoes { get; set; }





    }
}
