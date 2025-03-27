using Xadrez;


namespace tabuleiro
{
     class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro (int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[Linhas, Colunas];
        }
        public Peca peca(int linhas, int colunas)
        {
            return pecas[linhas, colunas];
        }
        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            {
                if (ExistePeca(pos)) { throw new TabuleiroException("Já tem peça ai"); }

                pecas[pos.Linha, pos.Coluna] = p;
                p.posicao = pos;

            }    
        }
        public bool posicaoValida(Posicao pos)
        {
            if (pos.Linha< 0 || pos.Linha >=Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            } 
            return true;
        }
        public void ValidarPosicao(Posicao pos)
        {
           
                if (!posicaoValida(pos))
                {
                    throw new TabuleiroException("Posição inválida");
                }
            
            
        }
        public Peca RetirarPeca(Posicao pos)
        {
            if (peca(pos) == null) { return null; }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }
    }
}
