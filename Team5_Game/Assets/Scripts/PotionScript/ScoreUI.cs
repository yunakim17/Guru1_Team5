using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;

    private void Update()
    {
        // 점수 UI 업데이트
        scoreText.text = "현재 학점 : " + ScoreManager.score.ToString();
    }

    private void Start()
    {
        scoreText.text = "현재 학점 : " + ScoreManager.score.ToString();
    }
}
