using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
   

   
     public void QuitApp()
     {
        Application.Quit();
        Debug.Log("Application has quit.");
        SceneManager.LoadScene("GameOver");
    }

}
