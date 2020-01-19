using System;
using System.Linq;
using System.Threading.Tasks;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Services
{
    public class MessageWorker : IMessageWorker
    {
        private readonly ICensureChecker _censureChecker;

        public MessageWorker(ICensureChecker censureChecker)
        {
            _censureChecker = censureChecker;
        }

        public Task<MessageDataDtoRs> AnalysMessage(string message)
        {
            if (!_censureChecker.CheckMessage(message.Split(' ')))
            {
                return Task.FromResult(new MessageDataDtoRs{CurrectMessage = message});
            }

            var words = message.Split(' ');
            for (var index = 0; index < words.Length; index++)
            {
                var word = words[index];
                if (_censureChecker.CheckWord(word))
                {
                    words[index] = _censureChecker.CensureWord(word);
                }
            }

            var result = string.Join(" ", words);
            return Task.FromResult(new MessageDataDtoRs { CurrectMessage = result });
        }
    }
}
