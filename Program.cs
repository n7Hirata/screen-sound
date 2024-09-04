//List<string> listaBandas = new List<string> { "Beatles", "U2"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int>());
bandasRegistradas.Add("Beatles", new List<int> { 8, 9, 7, 10});

void ExibirLogo()
{
    //Mensagem boas vindas
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
}

void ExibirTitulo(string titulo)
{
    int quantidadeLetras = titulo.Length;
    string asteriscos = string.Empty.PadRight(quantidadeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void ExibirOpcoesMenu()
{
    ExibirLogo();
    Console.WriteLine("Menu:");
    Console.WriteLine("   1 - Registrar uma banda");
    Console.WriteLine("   2 - Exibir todas as bandas");
    Console.WriteLine("   3 - Avaliar uma banda");
    Console.WriteLine("   4 - Exibir média de avaliações");
    Console.WriteLine("   0 - Para Sair");

    Console.Write("Selecione uma opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaInt = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaInt)
    {
        case 1: RegistrarBanda();
            break;
        case 2: ExibirBandas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: MediaAvaliacaoBanda();
            break;
        case 0: Console.WriteLine("Encerrando Screen Sound...");
            break;
        default: Console.WriteLine("Opção Invalida");
            break;
    }
}

void RegistrarBanda ()
{
    Console.Clear();
    ExibirLogo ();
    ExibirTitulo("Registro de banda");
    Console.Write("Disite o nome da banda: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesMenu();
}

void ExibirBandas()
{
    Console.Clear();
    ExibirLogo();
    ExibirTitulo("Bandas Registradas");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($" - {banda}");
    }
    Console.WriteLine("\nPressione uma tecla para voltar ao Menu Inicial...");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}

void AvaliarBanda()
{
    //  Informar banda que deseja avaliar
    //  Verificar se a banda existe no dicionario >> atribuir nota
    //  Se não, volta ao menu principal

    Console.Clear();
    ExibirLogo();
    ExibirTitulo("Avaliar Banda");
    Console.Write("Informe o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine();
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        VerificaNotaBanda(nomeBanda);
    }
    else
    {
        Console.Clear();
        ExibirLogo();
        Console.WriteLine($"A banda {nomeBanda} não foi encontrada.");
        Console.WriteLine("Pressione uma tecla para retornar ao menu...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
}

void VerificaNotaBanda(string nomeBanda)
{
    Console.WriteLine($"\nQual a nota para a banda {nomeBanda}: ");
    int nota = int.Parse(Console.ReadLine()!);
    if (nota >= 0 && nota <= 10)
    {
        bandasRegistradas[nomeBanda].Add(nota);
        Console.WriteLine("\nNota registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesMenu();
    }
    else
    {
        Console.WriteLine("\nA nota deve ser de 0 á 10");
        Console.ReadKey();
        Console.Clear();
        ExibirLogo();
        VerificaNotaBanda(nomeBanda);
    }
}

void MediaAvaliacaoBanda()
{
    Console.Clear();
    ExibirLogo();
    ExibirTitulo("Média de avaliações");
    Console.Write("\nInforme o nome da banda para ver suas estatísticas: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        List<int> notasBandas = bandasRegistradas[nomeBanda];
        Console.WriteLine($"\nMédia de avaliações: {notasBandas.Average()}");
        Console.WriteLine("\nPressione uma tecla para retornar ao menu inicial...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    } else
    {
        Console.WriteLine("\nA banda não foi encontrada!");
        Console.WriteLine("\nPressione uma tecla para retornar ao menu inicial...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
    
}

ExibirOpcoesMenu(); 