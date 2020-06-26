using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEstagio3
{
    class CEPs
    {
        //Complemento;Bairro;Localidade;UF;Unidade;IBGE;GIA
        public String Titulo { get; set; }
        public String CEP { get; set; }
        public String Logradouro { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Localidade { get; set; }
        public String UF { get; set; }
        public String Unidade { get; set; }
        public int IBGE { get; set; }
        public int? GIA { get; set; }

        public CEPs() { }

        public override string ToString()
        {
            return $"{CEP};{Logradouro};{Complemento};{Bairro};{Localidade};{UF};{Unidade};{IBGE};{GIA}";
        }

    }
}
