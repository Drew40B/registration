using System.Collections.Generic;
using System.Linq;
using participants.api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace participants.api.Services
{
    public class ParticipantService
    {
        private readonly IMongoCollection<Participant> _participants;


        public ParticipantService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("RegistrationDb"));
            var database = client.GetDatabase("registrationDb");
            _participants = database.GetCollection<Participant>("participants");

        }

        public async Task<List<Participant>> List()
        {

            var result = await _participants.FindAsync(participant => true);
            return result.ToList();
        }
    }
}