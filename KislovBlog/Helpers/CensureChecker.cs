using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace KislovBlog.Helpers
{
    public class CensureChecker
    {
        private readonly IWebHostEnvironment _environment;

        public CensureChecker(IWebHostEnvironment environment)
        {
            _environment = environment;
            BadWords = File.ReadAllLines(Path.Combine(environment.WebRootPath,"/BadWords.txt"))?.ToList() ?? new List<string>();
        }
        public List<string> BadWords { get; set; }  
        public bool CheckWord(string word) => BadWords.Any(x => x == word.ToLower());
    }
}
