using System;
using Criando_um_APP_simples_de_cadastro_de_séries_em_.NET.Classes;

class Program 
{
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper()!= "X")
        {
            switch (opcaoUsuario)
            {
                case "1": ListarSeries(); break;
                case "2": InserirSeries(); break;
                case "3": AtualizarSeries(); break;
                case "4": ExcluirSeries(); break;
                case "5": VisualizarSeries(); break;
                case "C": Console.Clear(); break;
                default: throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
        System.Console.WriteLine("Obrigado por usar nossos serviços");
        Console.ReadLine();
    }

    private static void ExcluirSeries()
    {
        System.Console.WriteLine("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceSerie);
    }

    private static void VisualizarSeries()
    {
        System.Console.WriteLine("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(indiceSerie);
        System.Console.WriteLine(serie);
    }

    private static void AtualizarSeries()
    {
        System.Console.WriteLine("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach (var atualiza in Enum.GetValues(typeof(Genero)))
        {
            System.Console.WriteLine("{0} - {1}", atualiza, Enum.GetName(typeof(Genero), atualiza));
        }
        System.Console.WriteLine("Digite o gênero entre as opções: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o título da série: ");
        string entradaTitulo = Console.ReadLine();

        System.Console.WriteLine("Digite o Ano de Início da série: ");
        int entradaAnoInicio = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAnoInicio, descricao: entradaDescricao);

        repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void ListarSeries()
    {
        System.Console.WriteLine("Listar Séries");
        
        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            System.Console.WriteLine("Nenhuma séria cadastrada.");
            return;
        }

        foreach (var serie in lista)
        {
            var excluido = serie.retornaExcluido();
            System.Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));   
        }
    }
    
    private static void InserirSeries()
    {
        System.Console.WriteLine("Inserir nova série");

        foreach (int item in Enum.GetValues(typeof(Genero)))
        {
            System.Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));
        }
        System.Console.WriteLine("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o título da Série: ");
        string entradaTitulo = Console.ReadLine();

        System.Console.WriteLine("Digite o Ano da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite a Descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

        repositorio.Insere(novaSerie);
    }


    private static string ObterOpcaoUsuario()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Everton ao seu dispor!!!");
        System.Console.WriteLine("Informe a opção desejada");

        System.Console.WriteLine("1 - Listar séries");
        System.Console.WriteLine("2 - Inserir nova série");
        System.Console.WriteLine("3 - Atualizar série");
        System.Console.WriteLine("4 - Excluir série");
        System.Console.WriteLine("5 - Visualizar série");
        System.Console.WriteLine("C - Limpar Tela");
        System.Console.WriteLine("X - Sair");
        System.Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        System.Console.WriteLine();
        return opcaoUsuario;
    }
}