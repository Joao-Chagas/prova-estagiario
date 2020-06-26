using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEstagio2
{
    class Bubble
    {
        public Bubble(List<ClassePair> Coluna)
        {

            for(int i = 0; i < Coluna.Count; i++)
            {                          
                for(int j = 0; j < Coluna.Count; j++)
                {
                    if (Coluna[i].Segundo > Coluna[j].Segundo)
                    {
                        
                        var aux = Coluna[i].Segundo;
                        Coluna[i].Segundo = Coluna[j].Segundo;
                        Coluna[j].Segundo = aux;

                        var aux2 = Coluna[i].Primeiro;
                        Coluna[i].Primeiro = Coluna[j].Primeiro;
                        Coluna[j].Primeiro = aux2;
                    }
                }
            }
        }
        
    }
}
