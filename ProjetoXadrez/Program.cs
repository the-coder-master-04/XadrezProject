using ProjetoXadrez;
using tabuleiro;
using Xadrez;

try
{
   

    PartidadeXadrez partida = new PartidadeXadrez();
    while (!partida.Terminada)
    {
        Tela.ImprimirTabuleiro(partida.tab);
        Console.WriteLine();
        Console.Write("Origem: ");
        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

        
        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPosssiveis();
        Console.Clear();

        Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);
        Console.Write("Destino: ");
        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

        partida.ExecutaMovimento(origem, destino);
    }
}

catch (IOException e)
{
    Console.WriteLine(e.Message);
}
