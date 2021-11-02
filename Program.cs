using System;

namespace _NET
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUser = ObterOpcaoUser();

        while (opcaoUser.ToUpper() != "X"){

            switch (opcaoUser)
            {
                case "1":
                ListarSeries();
                break;
                case "2":
                InserirSerie();
                break;
                case "3":
                AtualizarSerie();
                break;
                case "4":
                ExcluirSerie();
                break;
                case "5":
                VisualizarSerie();
                break;
                case "C":
                Console.Clear();
                break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoUser = ObterOpcaoUser();
        }

        Console.WriteLine("Obrigado por utilizar nossos Servicos.");
        Console.ReadLine();

        }

        private static void ExcluirSerie()
         {
             Console.Write("Digite o Id da Serie: ");
             int indiceSerie = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite: 1 - Confimar e 2- Cancelar");
             int comfirmacaoUser = int.Parse(Console.ReadLine());
            
            switch(comfirmacaoUser) 
            {
                case 1 :
                Console.WriteLine("Confirmado a Operação de Exclusão");
                repositorio.Exclui(indiceSerie);
                break;
                case 2:
                Console.WriteLine("Cancelado a Operação de Exclusão");
                break;
            }
            
         }
         private static void VisualizarSerie()
         {
             Console.Write("Digite o Id da Serie: ");
             int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
            
         }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.List();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie Encontrada");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));

            }
        }

        private static void AtualizarSerie()
         {
             Console.Write("Digite o Id da Serie: ");
             int indiceSerie = int.Parse(Console.ReadLine());
         
            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero entres as Opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());
             Console.WriteLine("Digite o Descrição da Serie: ");
            string entradaDesc = Console.ReadLine();
           
           Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDesc); 

            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }

        private static void InserirSerie()
        {
            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero entres as Opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());
             Console.WriteLine("Digite o Descrição da Serie: ");
            string entradaDesc = Console.ReadLine();
           
           Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDesc); 

            repositorio.Insere(novaSerie);
        }


        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Series ao seu Dispor !!!!");
            Console.WriteLine("Informe a Opção Desejada: ");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Nova Serie");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Séries");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("x- Sair");
            Console.WriteLine();

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUser;
        }
    }
}
