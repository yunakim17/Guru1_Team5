using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    [SerializeField] Text startPauseText;
    bool pauseActive = false;

    public void pauseBtn()
    {
        if (pauseActive)
        {
            Debug.Log("일시정지");
            Time.timeScale = 1;
            pauseActive = false;
        }
        else
        {
            Time.timeScale = 0;
            pauseActive = true;
        }
        startPauseText.text = pauseActive ? "START" : "PAUSE";
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
