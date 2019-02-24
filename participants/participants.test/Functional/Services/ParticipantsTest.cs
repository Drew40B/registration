using System;
using Microsoft.Extensions.Configuration;
using Xunit;
using participants.api.Services;
using participants.api.Models;
using MongoDB.Driver;

namespace participants.test.Functional.Services
{

    public class ParticipantsTest : IDisposable
    {

        private IConfiguration _config;


        private string _prefix;

        public ParticipantsTest()
        {
            _config = TestHelper.GetIConfigurationRoot();
            _prefix = this.GetType().Name + "_" + Guid.NewGuid();
        }

        public async void Dispose()
        {
            // remove all unit test records
            var service = new ParticipantService(_config);
   //         await service.Delete(p => p.firstName.StartsWith(_prefix));
        }

        [Fact]
        public async void UpsertDoesNotExist()
        {
            var service = new ParticipantService(_config);
            var participant = new Participant()
            {
                firstName = _prefix + ".UpsertDoesNotExist"
            };


            var result = await service.Upsert(participant);
            Assert.NotNull(result);
            Assert.Equal(result.matchedCount, 0);

            service = new ParticipantService(_config);
            var findResult = await service.Find(p => p.firstName == participant.firstName);

            Assert.Equal(findResult.Count, 1);
            Assert.Equal(findResult[0].Id, participant.Id);

        }

        [Fact]
        public async void UpsertExists()
        {
            var service = new ParticipantService(_config);
            var participant = new Participant()
            {
                firstName = _prefix + ".UpsertDoesNotExist"
            };

            // Create a participant
            var result = await service.Upsert(participant);
            Assert.NotNull(result);
            Assert.Equal(result.matchedCount, 0);


            //Update participant
            participant.lastName = "Different";
            result = await service.Upsert(participant);
            Assert.NotNull(result);
            Assert.Equal(result.matchedCount, 1);


            //verify update
            service = new ParticipantService(_config);
            var findResult = await service.Find(p => p.firstName == participant.firstName);

            Assert.Equal(findResult.Count, 1);
            Assert.Equal(findResult[0].Id, participant.Id);
            Assert.Equal(findResult[0].lastName, "Different");
        }


        [Fact]
        public async void List()
        {

            var service = new ParticipantService(_config);

            var result = await service.List();

            Assert.NotNull(result);
        }
    }
}