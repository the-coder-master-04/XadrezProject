using ProjetoXadrez;
using Tabuleiro;
using Xadrez;


tabuleiro tab = new tabuleiro(8, 8);

tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(0, 0));
tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(1, 3));
tab.ColocarPeca(new Rei(tab, Cor.Preto), new Posicao(2, 4));

Tela.ImprimirTabuleiro(tab);