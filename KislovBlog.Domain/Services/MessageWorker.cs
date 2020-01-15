using System;
using System.Linq;
using System.Threading.Tasks;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Services
{
    class MessageWorker : IMessageWorker
    {
        private readonly ICensureChecker _censureChecker;

        public MessageWorker(ICensureChecker censureChecker)
        {
            _censureChecker = censureChecker;
        }

        public Task<MessageDataDtoRs> AnalysMessage(MessageDataDto message)
        {
            if (!_censureChecker.CheckMessage(message.Message.Split(' ')))
            {
                return Task.FromResult(new MessageDataDtoRs{CurrectMessage = message.Message});
            }

            var words = message.Message.Split(' ');
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
