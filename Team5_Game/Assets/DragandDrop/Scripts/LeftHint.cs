using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHint : MonoBehaviour
{

    public static LeftHint Instance;

    private void Awake()
    {
        if (LeftHint.Instance == null)
        {
            LeftHint.Instance = this;
        }
    }



    int hintCount = 3; //주어진 힌트는 3번

    public Text HintCountText;


    void Start()
    {
        gameObject.SetActive(false);
        HintCountText.text = "남은 힌트 : " + hintCount + "번"; //처음엔 3번이 나와야함
    }

    
}
