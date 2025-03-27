


namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao{ get; set; }
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

        public abstract bool[,] movimentosPosssiveis();
    }
}
