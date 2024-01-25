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


    public int totalTime = 4; // 총 시간
    private int currentTime;   // 현재 시간

    public Text countdownText; //카운트다운하는 텍스트

    void Start()
    {
        gameObject.SetActive(false);
    }


    public void TimerStart()
    {


        gameObject.SetActive(true);
        currentTime = totalTime;
        UpdateUI();
        InvokeRepeating("UpdateCountdown", 1f, 1f); // 1초마다 UpdateCountdown 함수를 호출


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
