using System;
using Microsoft.Extensions.Configuration;
using Xunit;
using participants.api.Services;
using participants.api.Models;

namespace participants.test.Functional.Services
{

    public class ParticipantsTest
    {

        private IConfiguration _config;

        public ParticipantsTest()
        {
            _config = TestHelper.GetIConfigurationRoot();
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