using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDemo : MonoBehaviour
{
    [SerializeField] Timer timer;

    private void Start()
    {
        timer.SetDuration(60). Begin();
    }
}
