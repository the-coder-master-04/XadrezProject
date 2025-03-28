


namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor Cor { get; set; }
        public int qteDMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {

            this.tab = tab;
            Cor = cor;
            qteDMovimentos = 0;
        }
        public void IncrementarMovimentos()
        {
            qteDMovimentos++;
        }
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = movimentosPosssiveis();
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        public abstract bool[,] movimentosPosssiveis();
    
    public bool PodeMoverPara(Posicao pos)
        {
            return movimentosPosssiveis()[pos.Linha, pos.Coluna];
        }
    }
}
