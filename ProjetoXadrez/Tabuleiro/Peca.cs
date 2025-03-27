using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;


namespace Tabuleiro
{
    internal class Peca
    {
        public Posicao Posicao{ get; set; }
        public Cor Cor { get; set; }
        public int QteDMovimentos { get; protected set; }
        public tabuleiro Tab { get; protected set; }

        public Peca(tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Tab = tab;
            Cor = cor;
            QteDMovimentos = 0;
        }
        public void IncrementarMovimentos()
        {
            QteDMovimentos++;
        }

    }
}
