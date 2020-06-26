using System;
using System.Collections.Generic;
using System.IO;

namespace DesafioEstagio2
{ 

    public class ClassePair
    {
            public String Primeiro { get; set; } //Pega o primeiro elemento da linha do arquivo
            public int Segundo { get; set; } // Pega o segundo elemento da linha do arquivo
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
            String path = @"H:\Faculdade\Linguagens\C#\Nova pasta\DesafioEstagio2\DesafioEstagio2\Arquivos\";

            StreamReader sr = new StreamReader(path + "mapa.csv");//Abre o arquivo
            String conteudo = sr.ReadToEnd(); //Lê o arquivo

            String[] lines = conteudo.Split("\n"); // Pega o conteudo de cada linha e armazena
                                                   // sendo um elemento do array

            ValueTuple<string, string> Titulo; // Metodo de captura de titulo
            Titulo.Item1 = ""; //Salva o primeiro titulo
            Titulo.Item2 = ""; // Salva o segundo titulo
            
            var coluna = new List<ClassePair>(); // Cria uma lista para salvar a linha de cada coluna

            for (int i = 0; i < lines.Length-1; i++) // Pega os elementos do arquivo
            {
                String[] aux = lines[i].Split("; ");
                if (i == 0)
                {
                    Titulo.Item1 = aux[0];
                    Titulo.Item2 = aux[1];
                }
                else if (i >= 1 && i < lines.Length - 1)
                {

                    coluna.Add(new ClassePair
                    {

                        Primeiro = aux[0],
                        Segundo = Convert.ToInt32(aux[1])

                    });

                }
            }

            Bubble bubble = new Bubble(coluna); //Ordena a lista(Cria o BubbleSort)

            using(StreamWriter sw = File.CreateText(complete))// Imprime o conteúdo para o arquivo 
            {

            sw.WriteLine($"{Titulo.Item1}; {Titulo.Item2}"); 
            for (int i = 0; i < coluna.Count; i++)
            {
                 sw.WriteLine($"{coluna[i].Primeiro}; {coluna[i].Segundo}");
            }
            
            }
        }
    }
}
