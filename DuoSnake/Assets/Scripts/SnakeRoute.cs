using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SnakeRoute : MonoBehaviour
{
    private DatabaseAccess databaseAccess;

    private GameObject wordOutput;
    [SerializeField]
    private GameObject wordOutputPrefab;

    private TextMeshPro sentenceOutput;
    private TextMeshPro correctWords;
    
    private RectTransform rectTra;

    private static int count;

    float x;
    float y;
    float z;

    Vector3 pos;

    static int index;
    static string correctWord;
    string[] correctWordss;
    public List<GameObject> colliderArray;

    private List<GameObject> colliders;

    void Start()
    {
        x = Random.Range(1, 7);
        y = Random.Range(4, -2);
        z = 0;
        pos = new Vector3(x, y, z);

        /*x = Random.Range(-7, 7);
        y = Random.Range(-8, 6);
        z = 0;*/

        pos = new Vector3(x, y, z);
     
        databaseAccess = GameObject.FindGameObjectWithTag("DatabaseAccess").GetComponent<DatabaseAccess>();
        sentenceOutput = GameObject.FindGameObjectWithTag("SentenceOutput").GetComponentInChildren<TextMeshPro>();
        correctWords = GameObject.FindGameObjectWithTag("CorrectWord").GetComponentInChildren<TextMeshPro>();

        if (wordOutput != null)
        {
            rectTra = GetComponentInChildren<RectTransform>();
            rectTra.anchoredPosition = pos;
        }
        
        correctWord = "";
        colliders = new List<GameObject>();

       
        Invoke("DisplaySentenceFromDB", 0f);

    }

  
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync("GoodJob");
    }
    public void LoadSceneGameOver()
    {
        SceneManager.LoadSceneAsync("GameOver");
    }
    

    private async Task<string[]> DisplaySentenceFromDB()
    {
        var task = databaseAccess.GetSentencesFromDatabase();
        var result = await task;
       
        Sentence s = result[index];
        string sentence = s.sentence;

        sentenceOutput.text = sentence;
        sentenceOutput.GetComponentInChildren<RectTransform>().position = new Vector3(-0.01995162f, 9.16f, 0);

        string[] words2 = s.words;
        string[] extraWords = s.extra_words;
        string translation = s.translation;
        
        count++; //1

        int a = 0;
        int b = 0;

        if (count >= 1 && count < words2.Length)
        {
            while (a < words2.Length)
            {
                wordOutput = Instantiate(wordOutputPrefab, pos, Quaternion.identity) as GameObject;
                wordOutputPrefab.GetComponentInChildren<TextMeshPro>().text = words2[a];
                a++;
            }

            while (b < 2)
            {
                wordOutput = Instantiate(wordOutputPrefab, pos, Quaternion.identity) as GameObject;
                wordOutputPrefab.GetComponentInChildren<TextMeshPro>().text = extraWords[UnityEngine.Random.Range(0, extraWords.Length)];
                b++;
            }
        }

        if (index == result.Count)
        {
            index = 0;
        }
        return words2;
    }

    private async void OnCollisionEnter2D(Collision2D collision)
    {

        DuoSnake snake = collision.collider.GetComponent<DuoSnake>();
        ContactPoint2D[] contactPoints = collision.contacts;
        if (snake != null)
        {
            var wo = DisplaySentenceFromDB();
            var res = await wo;
            string[] w = res;
            foreach (ContactPoint2D contact in collision.contacts)
            {
                print(contact.collider.name + " hit " + contact.otherCollider.name);
            }


            for (int i = 0; i < w.Length; i++)
            {
                if (w.Contains(gameObject.GetComponent<TextMeshPro>().text))
                {
                    Debug.Log(gameObject.GetComponent<TextMeshPro>().text);
                    correctWord += gameObject.GetComponent<TextMeshPro>().text + " ";

                    if (w[i].Equals(correctWord.Split(' ')[i]))
                    {
                        gameObject.SetActive(false);
                        correctWords.text = correctWord;
                        correctWords.color = Color.green;
                        correctWords.GetComponentInChildren<RectTransform>().position = new Vector3(0.4528f, 7.4f, 0);
                        break;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                        SceneManager.LoadScene("GameOver");
                        break;
                    }
                }
                else if (!(w.Contains(gameObject.GetComponent<TextMeshPro>().text)))
                {
                    gameObject.SetActive(false);
                    SceneManager.LoadScene("GameOver");
                    break;
                }
                gameObject.SetActive(false);

            }
            correctWordss = correctWord.Split(' ');
            correctWordss = correctWordss.Take(correctWordss.Length - 1).ToArray();
            if (correctWord.Split(' ').Length == (w.Length + 1) && Enumerable.SequenceEqual(correctWordss, w))
            {
                SceneManager.LoadSceneAsync("GoodJob");
            }
            else if (correctWord.Split(' ').Length == (w.Length + 1) && !(Enumerable.SequenceEqual(correctWordss, w)))
            {
                correctWords.color = Color.red;
                Invoke("LoadSceneGameOver", 1);
            }


        }


    }

}
