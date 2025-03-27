using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez
{
    class PartidadeXadrez
    {
        public tabuleiro tab { get; private set; }
        private int turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }

        public PartidadeXadrez()
        {
            tab = new tabuleiro(8, 8);
            turno = 1;
            JogadorAtual = Cor.Branco;
            ColocarPecas();
            Terminada = false;
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }
        private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('a', 1).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('b', 1).toPosicao()); 
            tab.ColocarPeca(new Rei  (tab, Cor.Preto), new PosicaoXadrez('d', 2).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('e', 2).toPosicao());
    

            tab.ColocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('a', 8).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('b', 8).toPosicao());
            tab.ColocarPeca(new Rei  (tab, Cor.Branco), new PosicaoXadrez('d', 7).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('e', 7).toPosicao());
        }
    }
}
