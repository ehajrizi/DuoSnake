using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using UnityEngine;

public class DatabaseAccess : MonoBehaviour
{

    MongoClient client = new MongoClient("mongodb+srv://test:test@cluster0.bmttq.mongodb.net/DuoSnakeDB?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    IMongoCollection<BsonDocument> sentenceCollection;

    // Start is called before the first frame update
    void Start()
    {
        database = client.GetDatabase("DuoSnakeDB");
        collection = database.GetCollection<BsonDocument>("WordCollection2");
        sentenceCollection = database.GetCollection<BsonDocument>("SentencesCollection");
        
    }

    public async Task<List<Sentence>> GetSentencesFromDatabase()
    {

        var allSentencesTask = sentenceCollection.FindAsync(new BsonDocument());
        var sentencesAwaited = await allSentencesTask;

        List<Sentence> sentencesSelected = new List<Sentence>();
        foreach (var text in sentencesAwaited.ToList())
        {
            sentencesSelected.Add(DeserializeSentence(text.ToString()));
        }

        return sentencesSelected;
    }

    private Sentence DeserializeSentence(string rawJson)
    {
        var bsonDocument = BsonDocument.Parse(rawJson);
        var sentence = BsonSerializer.Deserialize<Sentence>(bsonDocument);

        return sentence;
    }


}
