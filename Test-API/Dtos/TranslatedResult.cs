using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Dtos
{
    public class TranslatedResult
    {
        public string SourceLanguage { get; set; }
        public string DestinationLanguage { get; set; }
        public string TranslatedText { get; set; }
    }
}
