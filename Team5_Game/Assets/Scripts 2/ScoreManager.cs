using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; //전체 씬에서 접근 가능

    public static void AddScore(int s)
    {
        ScoreManager.score += s; //ScoreManager 스크립트의 static 정수형 변수 score에 점수 s를 누적 저장
    }
}
