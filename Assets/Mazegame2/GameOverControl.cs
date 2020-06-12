using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{

    public void start()
    {
       Application.LoadLevel("MazeGame2");
    }

   //public void LoadScene(string SceneName)
   // {
       
   //    SceneManager.LoadScene("MazeGame2");

   // }
}
