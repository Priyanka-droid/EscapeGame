using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainSceneUI : MonoBehaviour
{
   public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void HomeButton(){
         SceneManager.LoadScene("Menu");
   }

   public void QuitGame(){
      Application.Quit();
   }
}
