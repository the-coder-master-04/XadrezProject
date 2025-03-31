using tabuleiro;
using System.Collections.Generic;

namespace Xadrez
{
    class PartidadeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        public PartidadeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            JogadorAtual = Cor.Branco;
            Terminada = false;
            Xeque = false;
            pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);
            p.DecrementarMovimentos();
            if (pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p, origem);
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce nao pode se colocar em xeque");
            }
            else if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (testeXequemate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                turno++;
                MudaJogador();
            }
        }
        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != tab.peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça disponivel!");
            }
        }
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino invalida!");
            }
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branco)
            {
                JogadorAtual = Cor.Preto;
            }
            else
            {
                JogadorAtual = Cor.Branco;
            }
        }
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            
            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if(cor == Cor.Branco)
            {
                return Cor.Preto;
            }
            else
            {
                return Cor.Branco;
            }
        }
        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
                
            }
            return null;
        }
        

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.movimentosPosssiveis();
                if (mat[R.posicao.Linha, R.posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        

       
        public bool testeXequemate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPosssiveis();
                for(int i = 0; i < tab.Linhas; i++)
                {
                    for (int j = 0; j < tab.Colunas; j++)
                    {
                        if(mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecacapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            desfazMovimento(origem, destino, pecacapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                            
                            
                        }
                    }
                }
            }
            return true;
        }



        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }





        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 8, new Torre(tab, Cor.Preto));
            ColocarNovaPeca('d', 8, new Rei(tab, Cor.Preto));
            ColocarNovaPeca('e', 8, new Rainha(tab, Cor.Preto));
            ColocarNovaPeca('h', 8, new Torre(tab, Cor.Preto));
            ColocarNovaPeca('c', 8, new Bispo(tab, Cor.Preto));
            ColocarNovaPeca('f', 8, new Bispo(tab, Cor.Preto));
            ColocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preto));
            ColocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preto));
            ColocarNovaPeca('a', 7, new Peao(tab, Cor.Preto));
            ColocarNovaPeca('b', 7, new Peao(tab, Cor.Preto));
            ColocarNovaPeca('c', 7, new Peao(tab, Cor.Preto));
            ColocarNovaPeca('d', 7, new Peao(tab, Cor.Preto));
            ColocarNovaPeca('e', 7, new Peao(tab, Cor.Preto));
            ColocarNovaPeca('f', 7, new Peao(tab, Cor.Preto));
            ColocarNovaPeca('g', 7, new Peao(tab, Cor.Preto));
            ColocarNovaPeca('h', 7, new Peao(tab, Cor.Preto));
            




            ColocarNovaPeca('a', 1, new Torre(tab, Cor.Branco));
            ColocarNovaPeca('d', 1, new Rei(tab, Cor.Branco));
            ColocarNovaPeca('e', 1, new Rainha(tab, Cor.Branco));
            ColocarNovaPeca('h', 1, new Torre(tab, Cor.Branco));
            ColocarNovaPeca('c', 1, new Bispo(tab, Cor.Branco));
            ColocarNovaPeca('f', 1, new Bispo(tab, Cor.Branco));
            ColocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branco));
            ColocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branco));
            ColocarNovaPeca('a', 2, new Peao(tab, Cor.Branco));
            ColocarNovaPeca('b', 2, new Peao(tab, Cor.Branco));
            ColocarNovaPeca('c', 2, new Peao(tab, Cor.Branco));
            ColocarNovaPeca('d', 2, new Peao(tab, Cor.Branco));
            ColocarNovaPeca('e', 2, new Peao(tab, Cor.Branco));
            ColocarNovaPeca('f', 2, new Peao(tab, Cor.Branco));
            ColocarNovaPeca('g', 2, new Peao(tab, Cor.Branco));
            ColocarNovaPeca('h', 2, new Peao(tab, Cor.Branco));


        }
        
    }
}
