using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){
                
                switch (opcaoUsuario){
                    case "1":
                    ListarSeries();
                    break;
                    case "2":
                    InserirSeries();
                    break;
                    case "3":
                    AtualizarSeries();
                    break;
                    case "4":
                    ExcluirSeries();
                    break;
                    case "5":
                    VisualizarSeries();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();

        }

    private static void VisualizarSeries(){             //Visualizar os dados da Série
        Console.Write("Digite o ID da Série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
    }
    private static void ExcluirSeries(){
        Console.Write("Digite o ID da Série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Excluir(indiceSerie);
    }
    private static void AtualizarSeries(){          //Metodo para Atualizar as Séries
        Console.Write("Digite o ID da série: ");            //Vai solicita o ID da Série
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero))){
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o genêro entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Titulo da Série: ");
        String entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Inicio da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite o Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie atualizarSeries = new Serie(id: indiceSerie,      //Sobreescreve os dados
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Atualiza(indiceSerie, atualizarSeries);

    }

    private static void ListarSeries(){         //metodo para listar séries
        Console.WriteLine("Listar Séries");

        var lista = repositorio.Lista();

        if(lista.Count == 0){
            Console.WriteLine("Nenhuma série cadastrada.");
            return;
        }

        foreach(var serie in lista){
            var excluido = serie.retornaExcluido();
            Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
        }
    }

    private static void InserirSeries(){            //metodo para Inserir Séries
        foreach(int i in Enum.GetValues(typeof(Genero))){
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o genêro entre as Opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Titulo da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Inicio da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Insere(novaSerie);
    }

    private static string ObterOpcaoUsuario(){
        Console.WriteLine();
        Console.WriteLine("DIO Séries de Anime a seu dispor!!!");
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1- Listar Séries");
        Console.WriteLine("2- Inserir nova Série");
        Console.WriteLine("3- Atualizar Série");
        Console.WriteLine("4- Excluir Série");
        Console.WriteLine("5- Visualizar Série");
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;

    }
    }
}
