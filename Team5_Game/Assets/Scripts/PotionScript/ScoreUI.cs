using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;

    private void Update()
    {
        // ���� UI ������Ʈ
        scoreText.text = " x " + ScoreManager.score.ToString();
    }

    private void Start()
    {
        scoreText.text = " xs " + ScoreManager.score.ToString();
    }

    //����
    
}
