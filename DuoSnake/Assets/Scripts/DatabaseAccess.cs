using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;

public class DatabaseAccess : MonoBehaviour
{

    MongoClient client = new MongoClient("mongodb+srv://test:test@cluster0.bmttq.mongodb.net/DuoSnakeDB?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        database = client.GetDatabase("DuoSnakeDB");
        collection = database.GetCollection<BsonDocument>("WordCollection");

    }

    public async Task<List<Word>> GetWordsFromDatabase(){

        var allWordsTask = collection.FindAsync(new BsonDocument());
        var wordsAwaited = await allWordsTask;

        List<Word> wordsSelected = new List<Word>();
        foreach (var text in wordsAwaited.ToList()) {
            wordsSelected.Add(Deserialize(text.ToString()));
        }

        return wordsSelected;
    }


    private Word Deserialize(string rawJson) {
        var word = new Word();

        var stringWithoutID = rawJson.Substring(rawJson.IndexOf("),") + 4);

        var text = stringWithoutID.Substring(0, stringWithoutID.IndexOf(":") - 2);
        var language = stringWithoutID.Substring(stringWithoutID.IndexOf(":") + 2, stringWithoutID.IndexOf("}") - stringWithoutID.IndexOf(":") - 8);
        word.Text = text;
        word.Language = language;
        return word;
    }

}

public class Word{
    public string Text { get; set; }
    public string Language { get; set; }
}
