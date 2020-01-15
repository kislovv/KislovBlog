using System.Collections.Generic;
using System.IO;
using System.Linq;
using KislovBlog.Domain.Abstraction;
using Microsoft.AspNetCore.Hosting;

namespace KislovBlog.Utilities.Helpers
{
    public class CensureChecker : ICensureChecker
    {
        private readonly IWebHostEnvironment _environment;
        private readonly List<string> _badWords;

        public CensureChecker(IWebHostEnvironment environment)
        {
            _environment = environment;
            _badWords = File.ReadAllLines(Path.Combine(environment.WebRootPath,"/BadWords.txt"))?.ToList() ?? new List<string>();
        }

        ///<summary>
        ///Слова на наличие мата
        /// </summary>       
        public bool CheckWord(string word) => _badWords.Any(x => x == word.ToLower());

        /// <summary>
        /// проверка наличия мата в предложении
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public bool CheckMessage(IEnumerable<string> words)
        {
            var result = words.ToList().Intersect(_badWords);
            return !result.Any();
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
