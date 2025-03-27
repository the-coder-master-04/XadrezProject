using tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor Cor) : base(tab, Cor)
        {

        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] movimentosPosssiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Pra cima
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            while (tab.posicaoValida(pos) && PodeMover(pos)) 
            {
                mat[posicao.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).Cor != Cor) 
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }
            // Pra baixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[posicao.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            // Pra esuqerdalulanojo
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[posicao.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }
            // Pra DireitoVaiBolsonaroVai17
            pos.DefinirValores(posicao.Linha , posicao.Coluna + 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[posicao.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }





            return mat;

        }
        public override string ToString()
        {
            return "T";
        }
    }
}