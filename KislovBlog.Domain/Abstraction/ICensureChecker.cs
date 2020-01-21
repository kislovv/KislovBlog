using System.Collections.Generic;

namespace KislovBlog.Domain.Abstraction
{
    public interface ICensureChecker
    {
        bool CheckWord(string word);
        List<string> CheckMessage(IEnumerable<string> words);
        string CensureWord(string word);
    }
}
