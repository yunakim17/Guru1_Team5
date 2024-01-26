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

    public void StartBtnAppear()
    {
        gameObject.SetActive(true);
    }

    public void GameScenesCtrl()
    {
        SceneManager.LoadScene("PotionMaking");//��ȣ �� �̸��� ������ ü���� - ù��° ���� ���� scene�̸�����!!!
       

    }
}
