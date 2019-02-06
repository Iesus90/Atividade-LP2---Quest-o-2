using System;


namespace Atividade1
{
    class Aplicacao
    {
        public const decimal Juros = 0.5M;
        static void Main(string[] args)
        {
            int s = 0;
            int idContaCorrente = 1;
            int idContaPoupanca = 1;

            using (var dbcontext = new StoreContext())
            {
                
                dbcontext.Set<Agencia>().RemoveRange(dbcontext.Agencias);
                dbcontext.Set<Banco>().RemoveRange(dbcontext.Bancos);
                dbcontext.Set<Cliente>().RemoveRange(dbcontext.Clientes);
                dbcontext.Set<ContaCorrente>().RemoveRange(dbcontext.ContasCorrentes);
                dbcontext.Set<ContaPoupanca>().RemoveRange(dbcontext.ContasPoupanca);
                dbcontext.Set<Solicitacao>().RemoveRange(dbcontext.Solicitacoes);
                dbcontext.SaveChanges();

                Banco b = new Banco();
                dbcontext.Bancos.Add(b);
                dbcontext.SaveChanges();

                

                while (true)
                {
                    b.listaIdAgencias();
                    Menu();
                    int op = int.Parse(Console.ReadLine());

                    if (op == 1)
                    {
                        Agencia a = new Agencia();
                        a.IdAgencia = s;
                        b.AdicionarAgencia(a);
                        s++;

                        dbcontext.Agencias.Add(a);
                        dbcontext.SaveChanges();

                    }
                    else if (op == 2)
                    {
                        Cliente c = new Cliente();
                        Console.WriteLine("Digite o nome do cliente: ");
                        string nomeCliente = Console.ReadLine();
                        c.Nome = nomeCliente;
                        dbcontext.Clientes.Add(c);
                        dbcontext.SaveChanges();

                        Console.WriteLine("Que tipo de conta deseja criar:\n");
                        Console.WriteLine("1 - Corrente / 2 - Poupança: ");
                        int tipo_conta = int.Parse(Console.ReadLine());
                        if (tipo_conta == 1)
                        {
                            ContaCorrente cc = new ContaCorrente(c.Nome);
                            Console.WriteLine("Digite o Id da agência: ");
                            int numAgencia = int.Parse(Console.ReadLine());

                            Agencia agencia = b.buscaAgencia(numAgencia);
                            if (agencia != null)
                            {
                                cc.Id = idContaCorrente;
                                agencia.AdicionarContaCorrente(cc);
                                idContaCorrente++;
                                dbcontext.ContasCorrentes.Add(cc);
                                dbcontext.SaveChanges();
                            }
                            else
                            {
                                Console.WriteLine("Por favor tente novamente!");
                            }

                        }
                        else if (tipo_conta == 2)
                        {
                            ContaPoupanca cp = new ContaPoupanca(Juros, DateTime.Now, c.Nome);
                            Console.WriteLine("Digite o Id da agência: ");
                            int numAgencia = int.Parse(Console.ReadLine());

                            Agencia agencia = b.buscaAgencia(numAgencia);
                            if (agencia != null)
                            {
                                cp.Id = idContaPoupanca;
                                agencia.AdicionarContaPoupanca(cp);
                                idContaPoupanca++;
                                dbcontext.ContasPoupanca.Add(cp);
                                dbcontext.SaveChanges();
                            }
                            else
                            {
                                Console.WriteLine("Por favor tente novamente!");
                            }

                        }
                    }
                    else if (op == 3)
                    {
                        Solicitacao solicitacao = new Solicitacao();
                        solicitacao.realizarSolicitacao(b);
                        dbcontext.Solicitacoes.Add(solicitacao);
                        dbcontext.SaveChanges();

                    }
                    else if (op == 4) b.listaIdAgencias();
                    else if (op == 5) Console.Clear();
                    else if (op == 0) return;
                    else Console.WriteLine("OPÇÃO INVÁLIDA");
                }
            }
        }
        public static void Menu()
            {
                Console.WriteLine("Banco Caixa");
                Console.WriteLine("1 - Cadastrar Agência ");
                Console.WriteLine("2 - Criar Conta ");
                Console.WriteLine("3 - Abrir uma Sessão");
                Console.WriteLine("4 - Listar agências");
                Console.WriteLine("5 - Limpar tela");
                Console.WriteLine("0 - Sair");
            }


        
    }
}