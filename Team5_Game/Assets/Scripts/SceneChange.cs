using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
 

    public void GameScenesCtrl()
    {
        SceneManager.LoadScene("Maze");
        Debug.Log("Game Scene Go");
    }

    public void GameScenesCtrl2()
    {
        SceneManager.LoadScene("PotionRule");
        Debug.Log("Game Scene Go");
    }

    public void GameScenesCtrl3()
    {
        SceneManager.LoadScene("PotionMaking");
        Debug.Log("Game Scene Go");
    }

    public void GameScenesCtrl4()
    {
        SceneManager.LoadScene("Ending");
        Debug.Log("Game Scene Go"); //pass�� -> ending��
    }

    public void GameScenesCtrl5()
    {
        SceneManager.LoadScene("StartScene");
        Debug.Log("Game Scene Go"); //fail�� -> start��
        ScoreManager.score = 0; //Ȯ���� ���� 0���� �ʱ�ȭ
    }

    public void GameScenesCtrl6()
    {
        SceneManager.LoadScene("CreatureFight");
        Debug.Log("Game Scene Go"); //ũ��ó �� -> ũ��ó����Ʈ
      
    }
}
