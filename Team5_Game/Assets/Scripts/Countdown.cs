using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] float setTime = 10.0f;
    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        countdownText.Text = setTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        setTime -= Time.deltaTime;
        countdownText.Text = setTime.ToString();
    }
}
