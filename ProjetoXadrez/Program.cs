using ProjetoXadrez;
using Tabuleiro;
using Xadrez;

try
{
    tabuleiro tab = new tabuleiro(8, 8);

    tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(0,0));
    tab.ColocarPeca(new Rei(tab, Cor.Branco), new Posicao(2,2));
    tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(1,7));

    Tela.ImprimirTabuleiro(tab);
}
catch (IOException e)
{
    Console.WriteLine(e.Message);
}
