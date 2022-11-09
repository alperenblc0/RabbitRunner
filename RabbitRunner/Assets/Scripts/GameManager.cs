using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
   public void startgame()
   {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
   }
    public void quitgame()
    {
        Application.Quit();
    }
}
