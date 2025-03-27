using ProjetoXadrez;
using Tabuleiro;
using Xadrez;

try
{
    PartidadeXadrez partida = new PartidadeXadrez();
    Tela.ImprimirTabuleiro(partida.tab);

    
        

        Console.WriteLine();
        Console.Write("Origem: ");
        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
        Console.Write("Destino: ");
        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

        partida.ExecutaMovimento(origem, destino);
    
}

catch (IOException e)
{
    Console.WriteLine(e.Message);
}
