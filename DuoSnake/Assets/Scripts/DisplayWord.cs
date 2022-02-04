using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DisplayWord : MonoBehaviour
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
    //bool indexChanged = false;
    static string correctWord;
    static string c;

    public List<GameObject> colliderArray;
    private List<GameObject> colliders;

    string[] correctWordss;


    void Start()
    {

        x = Random.Range(-7, 7);
        y = Random.Range(-8, 6);
        z = 0;
        pos = new Vector3(x, y, z);
        //if (!indexChanged)
        //{
        //    index = 0;
        //}//playAgain me u ndrru
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

    // Update is called once per frame
    void Update()
    {
       

    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync("GoodJob");
    }
    public void LoadSceneGameOver()
    {
        SceneManager.LoadSceneAsync("GameOver");
    }
    

    public async Task<int> ReturnCount()
    {
        var task = databaseAccess.GetSentencesFromDatabase();
        var result = await task;
        int nr = result.Count;
        return nr;
    }

    //public async Task<int> GenerateRandomNumber()
    //{
    //    var nr = ReturnCount();
    //    bound = await nr;
    //    randomIndex = UnityEngine.Random.Range(0, bound);
    //    return randomIndex;
    //}

    private async Task<string[]> DisplaySentenceFromDB()
    {
        var task = databaseAccess.GetSentencesFromDatabase();
        var result = await task;
        //var task2 = GenerateRandomNumber();
        //int nr = await task2;
        //bound = result.Count;
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
                //wordOutputPrefab.GetComponentInChildren<TextMeshPro>().GetComponentInChildren<RectTransform>().position = pos;
                a++;
            }

            while (b < 2)
            {
                wordOutput = Instantiate(wordOutputPrefab, pos, Quaternion.identity) as GameObject;
                wordOutputPrefab.GetComponentInChildren<TextMeshPro>().text = extraWords[UnityEngine.Random.Range(0, extraWords.Length)];
                //wordOutputPrefab.GetComponentInChildren<TextMeshPro>().GetComponentInChildren<RectTransform>().position = pos;
                b++;
            }
        }

        //index++;
        //indexChanged = true;
        Debug.Log(index);
        if (index == result.Count)
        {
            index = 0;
        }
        return words2;
    }


    private async void OnCollisionEnter2D(Collision2D collision)
    {

        Movement snake = collision.collider.GetComponent<Movement>();
        ContactPoint2D[] contactPoints = collision.contacts;
        if (snake != null)
        {
            var wo = DisplaySentenceFromDB();
            var res = await wo;
            string[] w = res;
            foreach (ContactPoint2D contact in collision.contacts)
            {
                print(contact.collider.name + " hit " + contact.otherCollider.name);
                // Visualize the contact point
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }


            for (int i = 0; i < w.Length; i++)
            {
                if (w.Contains(gameObject.GetComponent<TextMeshPro>().text))
                {
                    Debug.Log(gameObject.GetComponent<TextMeshPro>().text);
                    correctWord += gameObject.GetComponent<TextMeshPro>().text + " ";

                    if (w[i].Equals(correctWord.Split(' ')[i]))
                    {
                        Debug.Log("Bravo!" + gameObject.GetComponent<TextMeshPro>().text);
                        gameObject.SetActive(false);
                        correctWords.text = correctWord;
                        correctWords.color = Color.green;
                        correctWords.GetComponentInChildren<RectTransform>().position = new Vector3(0.4528f, 7.4f, 0);
                        break;
                    }
                    else
                    {
                        Debug.Log("Rendi Gabim!");
                        gameObject.SetActive(false);
                        SceneManager.LoadScene("GameOver");
                        break;
                    }
                }
                else if (!(w.Contains(gameObject.GetComponent<TextMeshPro>().text)))
                {
                    Debug.Log(gameObject.GetComponent<TextMeshPro>().text);

                    Debug.Log("LOSER!");
                    gameObject.SetActive(false);
                    SceneManager.LoadScene("GameOver");
                    break;
                }
                gameObject.SetActive(false);

            }
            Debug.Log("Correct word: " + correctWord);
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
