using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesafioEstagio
{
    class Mapa
    {
        
        public String ColunaTitulo { get; set; } //Pega o titulo de cada coluna do arquivo
        public String Coluna1 { get; set; } //Pega a primeira coluna do arquivo
        public int Coluna2 { get; set; } //Pega a segunda coluna do arquivo
    }
    class Program
    {

        static void Main(string[] args)
        {
            var systemPath = System.Environment.
                             GetFolderPath(Environment.
                                           SpecialFolder.
                                           DesktopDirectory); //Caminho para criar a copia no desktop

            var complete = Path.Combine(systemPath, "mapa_copia.csv");
            String path = @"H:\Faculdade\Linguagens\C#\Nova pasta\DesafioEstagio\DesafioEstagio\Arquivos\";
            StreamReader sr = new StreamReader(path + "mapa.csv");
            String conteudo = sr.ReadToEnd();
            String[] lines = conteudo.Split("\n");
            var populacao = new List<Mapa>();



            for (int i = 0; i < lines.Length; i++)
            {
                String[] aux = lines[i].Split("; ");
                if (i >= 1 && i<lines.Length-1)
                {

                populacao.Add(new Mapa{
                    Coluna1 = aux[0],
                    Coluna2 = Convert.ToInt32(aux[1])*2


                });
               }
                else if(i==0)
                {

                    populacao.Add(new Mapa
                    {
                        Coluna1 = aux[0],
                        ColunaTitulo = aux[1]
                    });
                }
            }

            
        if (!File.Exists(path + "testemapa.csv"))
        {
            for(int i = 0; i < lines.Length-1; i++)
            {
                using(StreamWriter sw = File.AppendText(path + "testemapa.csv"))
                {

                    if (i == 0)
                    {
                        sw.WriteLine($"{populacao[i].Coluna1}; {populacao[i].ColunaTitulo}");
                    }
                    else
                    {

                        sw.WriteLine($"{populacao[i].Coluna1}; {populacao[i].Coluna2}");

                    }
                }
            }
            
          }



        }
    }
}
