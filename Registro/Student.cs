using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro
{

    public class Student
    {
        public int Matricola { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        [JsonProperty("data_nascita")]
        public DateTime DataNascita { get; set; }

        [JsonProperty("luogo_nascita")]
        public string LuogoNascita { get; set; }

        public string Classe { get; set; }

        public Dictionary<string, List<int>> Voti { get; set; }
    }

}