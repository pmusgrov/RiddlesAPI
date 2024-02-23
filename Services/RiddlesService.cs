using RiddlesAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RiddlesAPI.Services
{
    public class RiddlesService
    {
        private readonly IMongoCollection<Riddles> _riddlesCollection;

        public RiddlesService(
            IOptions<RiddlesDatabaseSettings> riddlesDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                riddlesDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                riddlesDatabaseSettings.Value.DatabaseName);

            _riddlesCollection = mongoDatabase.GetCollection<Riddles>(
                riddlesDatabaseSettings.Value.RiddlesCollectionName);
        }

        public async Task<List<Riddles>> GetAsync() =>
            await _riddlesCollection.Find(_ => true).ToListAsync();

        public async Task<Riddles?> GetAsync(string id) =>
            await _riddlesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Riddles?> GetByNumberAsync(int number) =>
           await _riddlesCollection.Find(x => x.Number == number).FirstOrDefaultAsync();

        public async Task CreateAsync(Riddles newRiddles) =>
            await _riddlesCollection.InsertOneAsync(newRiddles);

        public async Task UpdateAsync(string id, Riddles updatedRiddles) =>
            await _riddlesCollection.ReplaceOneAsync(x => x.Id == id, updatedRiddles);

        public async Task RemoveAsync(string id) =>
            await _riddlesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
