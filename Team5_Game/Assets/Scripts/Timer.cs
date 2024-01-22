using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Pause = !Pause;
    }

    [Header("Timer UI references : ")]
    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;

    public int Duration;

    private int remainingDuration;

    private bool Pause;

    private void Start()
    {
        Being(Duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }

    private void OnEnd()
    {
        print("End");
    }

    //private IEnumerator UpdateTimer()
    //{
    //    while (remainingDuration >= 0)
    //    {
    //        uiText.text = $"{remaingDuration / 60:00} : {remainingDuration % 60:00}";
    //        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
    //        remainingDuration--;
    //        yield return new WaitForSeconds(1f);
    //    }
    //}
   

    //private void ResetTimer()
    //{
    //    uiText.text = "00:00";
    //    uiFillImage.fillAmount = 0f;

    //    Duration = remainingDuration = 0;
    //}

    //public Timer SetDuration(int seconds)
    //{
    //    Duration = remainingDuration = 0;
    //    return this;
    //}

    //public void Begin()
    //{
    //    StopAllCoroutines();
    //    StartCoroutine(UpdateTimer());
    //}


    //private void UpdateUI(int seconds)
    //{
    //    uiText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
    //    uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    //}

    //public void End()
    //{
    //    ResetTimer();
    //}

    //private void OnDestroy()
    //{
    //    StopAllCoroutines();
    //}

    //private void Awake()
    //{
    //    ResetTimer();
    //}
    // Start is called before the first frame update
}
