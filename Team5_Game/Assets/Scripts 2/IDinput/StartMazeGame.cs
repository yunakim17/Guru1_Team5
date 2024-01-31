using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMazeGame : MonoBehaviour
{
    public static StartMazeGame Instance;

    private void Awake()
    {
        if (StartMazeGame.Instance == null)
        {
            StartMazeGame.Instance = this;
        }
    }

   void Start()
    {
        gameObject.SetActive(false);
    }


    public void GameScenesCtrl()
    {
        SceneManager.LoadScene("Npc");//괄호 안 이름의 씬으로 체인지 - 첫번째 게임 설명 Npc 로!!!
       

    }
}
