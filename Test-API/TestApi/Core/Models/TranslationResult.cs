using System;

namespace TestApi.Core.Models
{
    public class TranslationResult
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Time { get; set; }
        public string SerbianText { get; set; }
        public string EnglishText { get; set; }
    }
}
