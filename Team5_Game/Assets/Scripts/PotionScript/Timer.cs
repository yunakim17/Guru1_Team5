using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{


    public static Timer Instance;

    private void Awake()
    {
        if (Timer.Instance == null)
        {
            Timer.Instance = this;
        }
    }


    public int totalTime = 4; // �� �ð�
    private int currentTime;   // ���� �ð�

    public Text countdownText; //ī��Ʈ�ٿ��ϴ� �ؽ�Ʈ

    void Start()
    {
        gameObject.SetActive(false);
    }


    public void TimerStart()
    {


        gameObject.SetActive(true);
        currentTime = totalTime;
        UpdateUI();
        InvokeRepeating("UpdateCountdown", 1f, 1f); // 1�ʸ��� UpdateCountdown �Լ��� ȣ��


    }

    void UpdateCountdown()
    {
        if (currentTime > 0)
        {
            currentTime--;
            UpdateUI();
        }
        else
        {
            CancelInvoke("UpdateCountdown");
            gameObject.SetActive(false);


        }
    }

    void UpdateUI()
    {

        countdownText.text = currentTime.ToString();
    }





}
