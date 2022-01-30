using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWord : MonoBehaviour
{
    private DatabaseAccess databaseAccess;

    private TextMeshPro wordOutput;
    private TextMeshPro wOutput;

    private RectTransform rectTra;

    float x;
    float y;
    float z;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(1, 7);
        y = Random.Range(4, -2);
        z = 0;
        pos = new Vector3(x, y, z);
        databaseAccess = GameObject.FindGameObjectWithTag("DatabaseAccess").GetComponent<DatabaseAccess>();
        wordOutput = GetComponentInChildren<TextMeshPro>();
        wOutput = GetComponentInChildren<TextMeshPro>();
        rectTra = GetComponentInChildren<RectTransform>();
        rectTra.anchoredPosition = pos;
        Invoke("DisplayWordsFromDB", 0f);
    }

    // Update is called once per frame
    void Update()
    {

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

    private async void DisplayWordsFromDB()
    {
        var task = databaseAccess.GetWordsFromDatabase();
        var result = await task;
        var output = " ";
        foreach (var text in result)
        {
            output = text.Text;
        }
        wOutput.text = output;
        wordOutput.text = output;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movement snake = collision.collider.GetComponent<Movement>();

        if (snake != null)
        {
            Debug.Log(gameObject.GetComponent<TMP_Text>().text);
            //databaseAccess.SaveWordToDatabase(gameObject.GetComponent<TMP_Text>().text, "Italian");
            Destroy(gameObject);
            return;
        }
    }
}

