using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
   

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
     public void QuitApp()
     {
        Application.Quit();
        Debug.Log("Application has quit.");
     }

}
