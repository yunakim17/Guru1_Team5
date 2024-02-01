using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFinalCheck : MonoBehaviour
{
  public void NextBtnPressed()
    {
        if (ScoreManager.score >= 3)
        {
            SceneManager.LoadScene("Pass");
        }
        else
        {
            SceneManager.LoadScene("Fail");
        }
       
    }
}
