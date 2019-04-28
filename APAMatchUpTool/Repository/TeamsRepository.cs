using APAMatchUpTool.Interfaces;
using APAMatchUpTool.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APAMatchUpTool.Repository
{
    public class TeamsRepository : ITeamsRepository
    {
        public async Task<List<Teams>> GetTeams()
        {

            var client = new MongoClient("mongodb+srv://ayirak:!!Konacoffee629@apaorangecounty-3jogl.azure.mongodb.net/test?retryWrites=true");

            IMongoDatabase db = client.GetDatabase("APA");

            var collection = db.GetCollection<BsonDocument>("Teams");

            List<Teams> teamModelList = new List<Teams>(); 

            using (var cursor = await collection.Find(new BsonDocument()).ToCursorAsync())
            {
                while (await cursor.MoveNextAsync())
                {

                    foreach (var doc in cursor.Current)
                    {
                        teamModelList.Add(BsonSerializer.Deserialize<Models.Teams>(doc.ToJson()));
                    }
                }
            }

            return teamModelList;
        }
    }
}
