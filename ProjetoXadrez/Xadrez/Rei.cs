using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;


namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(tabuleiro tab, Cor Cor): base(tab, Cor)
        {

        }
        public override string ToString()
        {
            return "R"; 
        }

    }
}
