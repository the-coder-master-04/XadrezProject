using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoXadrez.Tabuleiro;
using Tabuleiro;

namespace Tabuleiro
{
    internal class tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public tabuleiro (int linhas, int colunas)
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
                try
                {
                    if (ExistePeca(pos)) { throw new TabuleiroException("Já tem peça ai"); }

                    pecas[pos.Linha, pos.Coluna] = p;
                    p.Posicao = pos;
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Environment.Exit(1);
                }
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
            try
            {
                if (!posicaoValida(pos))
                {
                    throw new TabuleiroException("Posição inválida");
                }
            }
            catch (IOException e) { Console.WriteLine($"{e.Message}");
                Environment.Exit(1);
            }
        }
    }
}
