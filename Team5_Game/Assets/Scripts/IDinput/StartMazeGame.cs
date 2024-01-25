using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMazeGame : MonoBehaviour
{
    public void GameScenesCtrl()
    {
        SceneManager.LoadScene("PotionMaking");//괄호 안 이름의 씬으로 체인지 - 첫번째 게임 설명 scene이름으로!!!
       

    }
}
