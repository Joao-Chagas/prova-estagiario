using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Sockets;
using ViaCep;

namespace DesafioEstagio3
{
    class Program
    {
        static void Main(string[] args)
        {
            var systemPath = System.Environment.
                 GetFolderPath(Environment.
                               SpecialFolder.
                               DesktopDirectory);

            var complete = Path.Combine(systemPath, "mapa_copia.csv");

            String path = @"H:\Faculdade\Linguagens\C#\Nova pasta\DesafioEstagio2\DesafioEstagio2\Arquivos\";
            StreamReader sr = new StreamReader(path + "CEPs.csv");//Abre o arquivo
            String conteudoCep = sr.ReadToEnd(); //Lê o arquivo

            string[] linhasCep = conteudoCep.Split("\n");
            CEPs ceps = new CEPs();

            for (int i = 0; i < linhasCep.Length - 1; i++)
            {
                var aux = linhasCep[i].Split(";"); // Recebe as linhas
                
                if (i == 0)
                {
                    var aux2 = linhasCep[i]; //Pega o titulo
                    ceps.Titulo = aux2;

                    using (StreamWriter sw = File.CreateText(complete)) //Cria o arquivo e coloca na pasta
                        sw.WriteLine(ceps.Titulo);
                }
                else if (i == 5)
                {
                    aux[0] = "0" + aux[0];
                }
                else if(aux[0].Contains(" "))
                {
                    aux[0] = aux[0].Replace(" ", "");
                }
                else
                {

                var result = new ViaCepClient().Search(aux[0]);
                ceps.CEP = result.ZipCode;
                ceps.Logradouro = result.Street;
                ceps.Bairro = result.Neighborhood;
                ceps.Complemento = result.Complement;
                ceps.Localidade = result.City;
                ceps.UF = result.StateInitials;
                ceps.Unidade = result.Unit;
                ceps.IBGE = result.IBGECode;
                ceps.GIA = result.GIACode;

                    if (File.Exists(complete))
                    {
                        using (StreamWriter sw = File.AppendText(complete))
                            sw.WriteLine(ceps.ToString());
                    }
                
                }

            }

        }
    }
}
