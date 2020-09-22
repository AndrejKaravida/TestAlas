using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Dtos
{
 
    public class Rootobject
    {
        public Translated translated { get; set; }
    }

    public class Translated
    {
        public string _1sourcelanguage { get; set; }
        public string _2destinationlanguage { get; set; }
        public string _3translatedtext { get; set; }
    }

}
