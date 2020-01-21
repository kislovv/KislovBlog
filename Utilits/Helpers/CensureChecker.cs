using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using KislovBlog.Domain.Abstraction;
using Microsoft.AspNetCore.Hosting;

namespace KislovBlog.Utilities.Helpers
{
    public class CensureChecker : ICensureChecker
    {
        private readonly IWebHostEnvironment _environment;

        private List<string> _badWords;
        private List<string> BadWords
        {
            get
            {
                if (_badWords != null)
                {
                    return _badWords;
                }
                var path = $"{_environment.WebRootPath}\\BadWords.txt";
                return _badWords ?? (_badWords = File
                           .ReadAllLines(path)
                           ?.ToList());
            }
        }

        public CensureChecker(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        ///<summary>
        ///Слова на наличие мата
        /// </summary>       
        public bool CheckWord(string word)
        {
            return BadWords.Any(x => x == word.ToLower());
        }

        /// <summary>
        /// проверка наличия мата в предложении
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public List<string> CheckMessage(IEnumerable<string> words)
        {
            words = words.ToList().ConvertAll(x => x.ToLower());
            return  words.Intersect(BadWords).ToList();
        }

        /// <summary>
        /// Цензурирование матерных слов
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string CensureWord(string word)
        {
            return word.Replace(word.Substring(1, word.Length - 2), "*");
        }
    }
}
