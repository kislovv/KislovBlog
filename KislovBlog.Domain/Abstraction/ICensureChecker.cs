using System.Collections.Generic;

namespace KislovBlog.Domain.Abstraction
{
    public interface ICensureChecker
    {
        bool CheckWord(string word);
        bool CheckMessage(IEnumerable<string> words);
        string CensureWord(string word);
    }
}
