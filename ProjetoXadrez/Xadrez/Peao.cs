using System;
using tabuleiro;


namespace Xadrez
{
    class Peao : Peca
    {

        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.Cor != Cor;
        }
        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.Cor != Cor;
        }
        private bool Livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }


        

        public override string ToString()
        {
            return "P";
        }

       

        public override bool[,] movimentosPosssiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branco)
            {
                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
                if (tab.posicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha - 2, posicao.Coluna);
                Posicao p2 = new Posicao(posicao.Linha - 1, posicao.Coluna);
                if (tab.posicaoValida(p2) && Livre(p2) && tab.posicaoValida(pos) && Livre(pos) && qteDMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #jogadaespecial en passant
                if (posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    if (tab.posicaoValida(esquerda) && ExisteInimigo(esquerda))
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    if (tab.posicaoValida(direita) && ExisteInimigo(direita))
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
                if (tab.posicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha + 2, posicao.Coluna);
                Posicao p2 = new Posicao(posicao.Linha + 1, posicao.Coluna);
                if (tab.posicaoValida(p2) && Livre(p2) && tab.posicaoValida(pos) && Livre(pos) && qteDMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }


            }


            return mat;
        }
    }
}