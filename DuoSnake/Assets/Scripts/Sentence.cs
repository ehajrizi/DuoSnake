using MongoDB.Bson;
using System.Collections;
using UnityEngine;

public class Sentence 
{
    public ObjectId _id { get; set; }
    public string sentence { get; set; }
    public string[] words { get; set; }
    public string[] extra_words { get; set; }
    public string translation { get; set; }
}
