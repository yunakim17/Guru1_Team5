using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
  

    public void GameScenesCtrl()
    {
        SceneManager.LoadScene("Ending");// 미니게임 3 설명 씬으로 체인지


    }
}
