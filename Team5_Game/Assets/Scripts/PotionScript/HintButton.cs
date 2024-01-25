using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{
    public static HintButton Instance;

    int hintCount = 3; //주어진 힌트는 3번

    public Button HintBtn;

    

    private void Awake()
    {
        if (HintButton.Instance == null)
        {
            HintButton.Instance = this;
        }
    }
    void Start()
    {
        gameObject.SetActive(false);//시작할때는 안보이게
       
    }

    public void HintBtnPressed()
    {
       
        HintRecipe.Instance.HintBtnPressedRecipe();//버튼 클릭하면 랜덤 레시피 하나 생성해서 보여주는 함수 호출
        
        hintCount--;//힌트 버튼 클릭할 때마다 힌트가 하나씩 줄어든다

        LeftHint.Instance.HintCountText.text = "남은 힌트 : " + hintCount + "번";

        Timer.Instance.TimerStart();//타이머 호출

        Invoke("HintBtnFalse", 0f);//누르자마자 힌트버튼 상호작용 불가능하게 -> 힌트버튼을 계속헤서 누를 수 없게함

        Invoke("HintBtnTrue", 4f);//힌트시간 = 4초 지나면 다시 상호작용 가능하게 만들기 



        if (hintCount ==0) //힌트를 다 썼을 때
        {
            Invoke("HintButtonDisappear", 4f);//5초 후에 힌트버튼과 레시피 사라지게하는 함수 호출
        }


    }


    void HintBtnFalse()
    {
        HintBtn.interactable = false;
    }

    void HintBtnTrue()
    {
        HintBtn.interactable = true;
    }

    void HintButtonDisappear()
    {
        
        GameObject.Find("HintButton").SetActive(false);
         //버튼과 레시피가 게임창에서 사라짐

    }
}
