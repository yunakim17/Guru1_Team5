using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; //��ü ������ ���� ����

    public static void AddScore(int s)
    {
        ScoreManager.score += s; //ScoreManager ��ũ��Ʈ�� static ������ ���� score�� ���� s�� ���� ����
    }
}
