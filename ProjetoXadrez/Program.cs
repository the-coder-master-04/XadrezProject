using ProjetoXadrez;
using tabuleiro;
using Xadrez;

try
{
    PartidadeXadrez partida = new PartidadeXadrez();
    while (!partida.Terminada)
    {
        try
        {
            
            Tela.ImprimirPartida(partida);

            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDeOrigem(origem);

            bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPosssiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);


            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDeDestino(origem, destino);

            partida.realizaJogada(origem, destino);
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
    Console.Clear();
    Tela.ImprimirPartida(partida);

}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}
