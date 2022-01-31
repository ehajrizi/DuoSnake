using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayWord : MonoBehaviour
{
    private DatabaseAccess databaseAccess;
    private WordGenerator wordGenerator;

    
    //private TextMeshPro[] wordOutput;
    private TextMeshPro wordOutput;

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
        rectTra = GetComponentInChildren<RectTransform>();
        rectTra.anchoredPosition = pos;
        Invoke("ShowWords",0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (i >= 7) {
        //    CancelInvoke("ShowWords");
        //}

        CancelInvoke("ShowWords");
    }

    /* private async void DisplayWordsFromDB()
     {
         var task = databaseAccess.GetWordsFromDatabase();
         var result = await task;
         var output = "";
         foreach (var text in result)
         {
             output += text.Text + " Language: " + text.Language;
         }
         wordOutput.text = output;
         wOutput.text = output;
     }**/

    //private async void DisplayWordsFromDB()
    //{
    //    var task = databaseAccess.GetWordsFromDatabase();
    //    var result = await task;
    //    var output = " ";
    //    foreach (var text in result)
    //    {
    //        output = text.Text;
    //    }
    //    wOutput.text = output;
    //    wordOutput.text = output;

    //}
    public string ShowSentence() {

       
        string sentence = wordGenerator.GetSentence();
        //if (wordGenerator.isChosen)
        //{

        
        //}
        return sentence;
    }

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

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movement snake = collision.collider.GetComponent<Movement>();

        if (snake != null)
        {
            string[] s = ShowSentence().Split(' ');
            Debug.Log(gameObject.GetComponent<TMP_Text>().text);
            for (int i = 0; i < s.Length; i++) {
                if (s[i].Equals(gameObject.GetComponent<TMP_Text>().text) && collision.GetType() == gameObject.GetType())
                {
                    Debug.Log("Bravo!");
                    //Destroy(gameObject);
                    return;
                }
                else if (s[i].Equals(gameObject.GetComponent<TMP_Text>().text))
                {
                    Debug.Log("Rendi gabim!");
                    //Destroy(gameObject);
                    return;
                }
                else if(!(s[i].Equals(gameObject.GetComponent<TMP_Text>().text))) {
                    Debug.Log("LOSER!");
                    //Destroy(gameObject);
                    
                }

                //databaseAccess.SaveWordToDatabase(gameObject.GetComponent<TMP_Text>().text, "Italian");
                Destroy(gameObject);
            }
        }
    }


}

