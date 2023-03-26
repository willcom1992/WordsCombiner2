using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordsCombiner.Server.Data;
using WordsCombiner.Shared;
using WordsCombiner.Shared.Model;
using Xunit;

namespace WordsCombiner.ServerTest
{
    [TestClass]
    public class UnitTest1 : IAsyncLifetime
    {
        private DbContextOptions<AppDbContext> _inMemoryContextOptions;

        public Task InitializeAsync()
        {
            _inMemoryContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString(), opt => opt.EnableNullChecks(false))
                .ConfigureWarnings(opt => { opt.Ignore(InMemoryEventId.TransactionIgnoredWarning); })
                .Options;

            return Task.CompletedTask;
        }

        
        public static IEnumerable<object[]> SearchWordsAsyncTestData
        {
            get
            {
                var entity = new Word[]
                {
                    new Word(){Id = 1, Value ="飛行機", PartOfSpeech = 0},
                    new Word(){Id = 2, Value ="風船", PartOfSpeech = 0},
                    new Word(){Id = 3, Value ="走る", PartOfSpeech = 1},
                    new Word(){Id = 4, Value ="飛ぶ", PartOfSpeech = 1},
                };

                yield return MakeSearchWordsAsyncTestData(
                    entity,
                    Language.Japanese,
                    1,
                    PartOfSpeech.Noun,
                    new Word[] 
                    {
                        new Word(){Id = 1, Value ="飛行機", PartOfSpeech = 0},
                    });
            }
        }

        private static object[] MakeSearchWordsAsyncTestData(
            IEnumerable<Word> entity,
            Language language,
            int numberOfWords,
            PartOfSpeech partOfSpeech,
            IEnumerable<Word> expected)
        {
            var expected = 

            return new object[] { };
        }

        [Theory]
        [MemberData(nameof(MakeSearchWordsAsyncTestData))]
        public void SearchWordsAsync(Language language, int numberOfWords, PartOfSpeech partOfSpeech)
        {
            var expected = new Word[]
            {
                new Word
                {
                    Id = 1,
                    Value ="飛行機",
                    PartOfSpeech =1
                }
            };

            var entity = 
        }

        public Task DisposeAsync()
        {
            (_inMemoryContextOptions as IDisposable)?.Dispose();
            return Task.CompletedTask;
        }
    }
}