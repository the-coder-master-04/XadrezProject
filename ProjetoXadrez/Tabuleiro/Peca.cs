using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;


namespace ProjetoXadrez.Tabuleiro
{
    internal class Peca
    {
        public Posicao Posicao{ get; set; }
        public Cor Cor { get; set; }
        public int QteDMovimentos { get; protected set; }
        public tabuleiro Tab { get; protected set; }

        public Peca(Posicao posicao, tabuleiro tab, Cor cor)
        {
            Posicao = posicao;
            Tab = tab;
            Cor = cor;
            QteDMovimentos = 0;
        }

    }
}
