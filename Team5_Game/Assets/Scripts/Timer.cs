using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Timer UI references : ")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private Text uiText;

    public int Duration { get; private set; }

    public string thisScene;

    private int remainingDuration;

   

    private void Awake()
    {
        ResetTimer();
       GameManager Instance = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void ResetTimer()
    {
        uiText.text = "00:00";
        uiFillImage.fillAmount = 0f;

        Duration = remainingDuration = 0;
    }

    public Timer SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        yield return new WaitForSeconds(3f);
        while (remainingDuration > 0)
        {
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
    }

    private void UpdateUI(int seconds)
    {
        uiText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }

    //void OnTriggerEnter(Collider Scroll)
   // {

    //    if (Scroll.tag == "Player")
     //   {
    //        End();
     //   }
   // }

    public void End()
    {
       ResetTimer();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}

//void OnPlayerCollision(Collider Scroll)
   // {
        // 여기서 충돌 시간을 멈추는 로직을 추가
 //       if (Scroll.tag == "Player")
 //       {
 //           AnotherPause();
 //       }
           
 //   }

 //   void AnotherPause()
 //   {
 //       Time.timeScale = 0;
  //  }

