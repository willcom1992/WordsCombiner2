//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using WordsCombiner.Shared.Model;
//using Microsoft.EntityFrameworkCore.InMemory;
//using Microsoft.EntityFrameworkCore;
//using WordsCombiner.Server.Data;
//using System.Threading.Tasks;
//using System;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using Xunit;
//using System.Collections;
//using System.Collections.Generic;

//namespace WordsCombiner.ServerTest
//{
//    [TestClass]
//    public class UnitTest1 : IAsyncLifetime
//    {
//        private DbContextOptions<AppDbContext> _inMemoryContextOptions;

//        public Task InitializeAsync()
//        {
//            _inMemoryContextOptions = new DbContextOptionsBuilder<AppDbContext>()
//                .UseInMemoryDatabase(Guid.NewGuid().ToString(), opt => opt.EnableNullChecks(false))
//                .ConfigureWarnings(opt => { opt.Ignore(InMemoryEventId.TransactionIgnoredWarning); })
//                .Options;

//            return Task.CompletedTask;
//        }

        
//        public static IEnumerable<object[]> SearchWordsAsyncTestData
//        {
//            get
//            {
//                yield return MakeSearchWordsAsyncTestData();
//            }
//        }

//        private static object[] MakeSearchWordsAsyncTestData()
//        {
//            return new object[] { };
//        }

//        [Theory]
//        [MemberData(nameof(MakeSearchWordsAsyncTestData))]
//        public void SearchWordsAsync()
//        {
//            var expected = new JapaneseWord[]
//            {
//                new JapaneseWord
//                {
//                    Id = 1,
//                    Value ="îÚçsã@",
//                    PartOfSpeech =1
//                }
//            };

//            var entity = 
//        }

//        public Task DisposeAsync()
//        {
//            (_inMemoryContextOptions as IDisposable)?.Dispose();
//            return Task.CompletedTask;
//        }
//    }
//}