//using System;
//namespace AssemblyCSharp
//{
//    public class ok
//    {
//        public ok()
//        {
//        }

//        private async void OnCollisionEnter2D(Collision2D collision)
//        {
//            Movement snake = collision.collider.GetComponent<Movement>();

//            if (snake != null)
//            {
//                var wo = DisplaySentenceFromDB();
//                var res = await wo;
//                string[] w = res;


//                //string[] correctWordss = null;

//                //gOtext += gameObject.GetComponent<TextMeshPro>().text;
//                Debug.Log(gameObject.GetComponent<TextMeshPro>().text);

//                for (int i = 0; i < w.Length; i++)
//                {

//                    if (w.Contains(gameObject.GetComponent<TextMeshPro>().text))
//                    {
//                        Debug.Log("Bravo!");
//                        correctWord += " " + gameObject.GetComponent<TextMeshPro>().text;
//                        //correctWordss[i++] = gameObject.GetComponent<TextMeshPro>().text;
//                        //correctWord += correctWordss[i];
//                        correctWords.text = correctWord;
//                        correctWords.color = Color.green;
//                        correctWords.GetComponentInChildren<RectTransform>().position = new Vector3(0.3f, 8.5f, 0);
//                        gameObject.SetActive(false);
//                        break;
//                    }


//                    if (w.Contains(gameObject.GetComponent<TextMeshPro>().text) && !(w[i].Equals(gameObject.GetComponent<TextMeshPro>().text)))
//                    {
//                        Debug.Log("Rendi Gabim!");
//                        gameObject.SetActive(false);
//                        break;
//                    }
//                    if (!(w.Contains(gameObject.GetComponent<TextMeshPro>().text)))
//                    {
//                        Debug.Log("LOSER!");
//                        gameObject.SetActive(false);
//                        break;
//                    }
//                    gameObject.SetActive(false);
//                }
//                Debug.Log("Correct word: " + correctWord);
//                gameObject.SetActive(false);

//            }
//        }
//}
