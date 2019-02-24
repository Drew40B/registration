using System.Collections.Generic;
using System.Linq;
using participants.api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using MongoDB.Bson;

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

        public async Task<List<Participant>> Find(Expression<Func<Participant,bool>> filter)
        {
              var result = await _participants.FindAsync(filter);
            return result.ToList();
        }

        public async Task<long> Delete(Expression<Func<Participant,bool>> filter)
        {
              var result = await _participants.DeleteManyAsync(filter);
            return result.DeletedCount;
        }

        public async Task<(Participant result, long matchedCount)> Upsert(Participant participant)
        {

            if (participant.Id == null || participant.Id == ObjectId.Empty){
                participant.Id = ObjectId.GenerateNewId();
            }
            var options = new UpdateOptions();
            options.IsUpsert = true;
          
            var result = await _participants.ReplaceOneAsync<Participant>(p => p.Id == participant.Id
                    , participant
                    , options);

            return  (result:participant, matchedCount :result.MatchedCount);

        }
    }
}