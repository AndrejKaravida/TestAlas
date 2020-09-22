using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Xml;
using TestApi.Core.IRepository;
using TestApi.Core.Models;
using TestApi.Dtos;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorController : ControllerBase
    {

        private readonly ITranslationRepository _translationRepository;
        public TranslatorController(ITranslationRepository translationRepository)
        {
            _translationRepository = translationRepository;
        }

    
        [HttpPost]
        public async Task<IActionResult> GetTranslation([FromBody] SearchRequest searchRequest)
        {
            var translation_fro_db = _translationRepository.GetTranslation(searchRequest.TextRequest);
            
            if(translation_fro_db != null)
            {
                Translation translationFromDatabase = new Translation()
                {
                    EnglishText = translation_fro_db.EnglishText
                };

                return Ok(translationFromDatabase);
            }

       
            var client = new RestClient("https://simple-elegant-translation-service.p.rapidapi.com/translate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-rapidapi-host", "simple-elegant-translation-service.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "5807bfc0f7mshdb2779da1949d0cp12623fjsnf96ac77d14d4");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");

            request.AddParameter("application/json", "{ \"text\":" + "\"" + searchRequest.TextRequest + "\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var english_text = response.Content.ToString();

            english_text = english_text.Remove(0, 85).ToString();

            do
            {
                english_text = english_text.Remove(0, 1);
            }
            while (english_text[0] != '3');

            english_text = english_text.Remove(0, 20).ToString();
            english_text = english_text.Remove(english_text.Length - 4, 4).ToString();

            var source_language = response.Content.ToString();

            source_language = source_language.Remove(0, 35).ToString();

            do
            {
                source_language = source_language.Remove(source_language.Length -1, 1);
            }
            while (source_language[source_language.Length - 1] != '2');

            source_language = source_language.Remove(source_language.Length - 5, 5);

            var destination_language = response.Content.ToString();

            destination_language = destination_language.Remove(0, 75).ToString();

            do
            {
                destination_language = destination_language.Remove(destination_language.Length - 1, 1);
            }
            while (destination_language[destination_language.Length - 1] != '3');

            destination_language = destination_language.Remove(destination_language.Length - 4, 4);

            TranslationResult tr = new TranslationResult()
            {
                SerbianText = searchRequest.TextRequest,
                EnglishText = english_text,
                From = source_language,
                To = destination_language,
                Time = DateTime.Now
            };

            _translationRepository.Add(tr);

            await _translationRepository.SaveAsync();

            Translation translationToReturn = new Translation()
            {
                EnglishText = tr.EnglishText
            };

            SaveToXml();

            return Ok(translationToReturn);
        }


        private void SaveToXml()
        {
            string filename = "D:\\Testxml.xml";

            XmlTextWriter xmlWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);

            xmlWriter.Formatting = System.Xml.Formatting.Indented;

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("Translations");

            var records = _translationRepository.GetAllTranslation();

            foreach(var record in records)
            {
                xmlWriter.WriteStartElement("Translation");
                xmlWriter.WriteElementString("Id", record.Id.ToString());
                xmlWriter.WriteElementString("Timestamp", record.Time.ToString());
                xmlWriter.WriteElementString("From", record.From);
                xmlWriter.WriteElementString("To", record.To);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
}
