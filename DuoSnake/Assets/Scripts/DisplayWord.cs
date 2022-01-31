using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class DisplayWord : MonoBehaviour
{
    private DatabaseAccess databaseAccess;
    private WordGenerator wordGenerator;


    //private TextMeshPro[] wordOutput;
    private TextMeshPro wordOutput;
    private TextMeshPro sentenceOutput;

    private RectTransform rectTra;
    private static int i;

    float x;
    float y;
    float z;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        x = UnityEngine.Random.Range(1, 7);
        y = UnityEngine.Random.Range(4, -2);
        z = 0;
        i = 0;
        pos = new Vector3(x, y, z);
        databaseAccess = GameObject.FindGameObjectWithTag("DatabaseAccess").GetComponent<DatabaseAccess>();
        wordGenerator = GameObject.FindGameObjectWithTag("WordGenerator").GetComponent<WordGenerator>();
        wordOutput = GetComponentInChildren<TextMeshPro>();
        sentenceOutput = GameObject.FindGameObjectWithTag("SentenceOutput").GetComponentInChildren<TextMeshPro>();
        rectTra = GetComponentInChildren<RectTransform>();
        rectTra.position = pos;

       // DisplaySentencesFromDB();
        Invoke("DisplaySentencesFromDB", 0f);
        //Invoke("ShowWords", 0f);
        //Invoke("ShowChosenSentence", 0f);

    }

    // Update is called once per frame
    void Update()
    {
        //if (i >= 7) {
        //    CancelInvoke("ShowWords");
        //}

        //CancelInvoke("ShowWords");
    }

 
    private async void DisplayWordsFromDB() //extra words
    {
        var task = databaseAccess.GetWordsFromDatabase();
        var result = await task;
        var output = "";
        foreach (var text in result)
        {
            output = text.TEXT;
        }
        wordOutput.text = output;
    }

    private async void DisplaySentencesFromDB()
    {
        var task = databaseAccess.GetSentencesFromDatabase();
        var result = await task;

        int randomIndex = UnityEngine.Random.Range(0, result.Count);
        Debug.Log("RANDOM INDEX: "+ randomIndex);
        string sentence = result[randomIndex].sentence.ToString();

        sentenceOutput.text = sentence;
        sentenceOutput.GetComponentInChildren<RectTransform>().position = new Vector3(0, 10, 0);

        string[] words = result[randomIndex].words;

        if (i < words.Length)
        {
            wordOutput.text = words[i];
            i++;
        }

        /*
        foreach (var text in result)
        {
            output = text.sentence;
        }
        sentenceOutput.text = output;
        **/
    }

    public string ShowSentence()
    {


        string sentence = wordGenerator.GetSentence();
        //if (wordGenerator.isChosen)
        //{

        return sentence;
    }
    /*
    public void ShowChosenSentence()
    {
        string sentence = wordGenerator.GetChosenSentence();

        sentenceOutput.text = sentence;
        sentenceOutput.GetComponentInChildren<RectTransform>().position = new Vector3(0, 10, 0);
    }

    **/
    /*
    public void ShowWords()
    {
        string s = ShowSentence();

        string[] words = s.Split(' ');

        if (i < words.Length)
        {
            wordOutput.text = words[i];
            i++;
        }

    
        //for (i = 0; i < words.Length; i++) {
        //    wordOutput.text = words[i];
        //}
        //   Instantiate(wordOutput, pos, Quaternion.identity);
        //++i;

        //    return;

        //}

        //wordOutput[i].text = words[i];

        //GameObject.FindObjectOfType<TextMeshPro>().text = words[i];

        //foreach (string w in words)
        //{
        //    TextMeshPro tmp = Instantiate(wordOutput, transform.position, Quaternion.identity);
        //    tmp.text = w;
        //}

    }**/

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movement snake = collision.collider.GetComponent<Movement>();

        if (snake != null)
        {
            //string[] s = ShowSentence().Split(' ');
            List<string> s = ShowSentence().Split(' ').ToList();
            Debug.Log(gameObject.GetComponent<TextMeshPro>().text);

            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].Equals(gameObject.GetComponent<TextMeshPro>().text))
                {
                    Debug.Log("Bravo!");
                    break;
                    //return;
                }
                if (s.Contains(gameObject.GetComponent<TextMeshPro>().text) && !(s[i].Equals(gameObject.GetComponent<TextMeshPro>().text)))
                {
                    Debug.Log("Rendi Gabim!");
                    break;

                }
                if (!(s.Contains(gameObject.GetComponent<TextMeshPro>().text)))
                {
                    Debug.Log("LOSER!");
                    break;
                }
                Destroy(gameObject);
            }

            Destroy(gameObject);
        }
    }

}

