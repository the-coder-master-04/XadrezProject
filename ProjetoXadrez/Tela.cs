using System;
using tabuleiro;
using Xadrez;
using System.Collections.Generic;

namespace ProjetoXadrez
{
    class Tela
    {
        public static void ImprimirPartida(PartidadeXadrez partida)
        {
            Console.Clear();
            ImprimirTabuleiro(partida.tab);

            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno {partida.turno}");
            Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");
        }

        public static void ImprimirPecasCapturadas(PartidadeXadrez partidade)
        {
            Console.Write("Peças capturadas: ");
            Console.WriteLine();

            Console.Write("Brancas: ");
            ImprimirConjunto(partidade.PecasCapturadas(Cor.Branco));
            
            Console.WriteLine();
            Console.Write("Pretas: ");
            ImprimirConjunto(partidade.PecasCapturadas(Cor.Preto));
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca p in conjunto)
            {
                Console.Write($" {p} ");
            }
            Console.Write("]");
        }


        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
           
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    
                    ImprimirPeca(tab.peca(i, j));
                    
                }
                Console.WriteLine();

            }
            Console.WriteLine("  a b c d e f g h");
           
        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;


            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Colunas; j++)
                {   if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else { Console.BackgroundColor = fundoOriginal;}
                    ImprimirPeca(tab.peca(i,j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();

            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void ImprimirPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branco)
                {
                    Console.Write(peca + " ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca + " ");
                    Console.ForegroundColor = aux;
                }
                
            }
            
        }
    }
}
