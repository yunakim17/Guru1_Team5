using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinClear : MonoBehaviour
{
    //[SerializeField] GameObject finText;
    public GameObject gameLabel;
    Text gameText;
    public GameState gState;

    public enum GameState
    {
        Ready,
        Run,
        StageClear,
        Failed
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider Scroll)
    {

        if (Scroll.tag == "Player")
        {
            Debug.Log("미로탈출 성공");

            if (GameObject.FindWithTag("Item") == null)
            {
                GameClear();
            }
            else
            {
                GameFailed();
            }

            gameLabel.SetActive(true);

            Destroy(Scroll.gameObject);
        }
    }

    void GameClear()
    {
        gState = GameState.StageClear;
        gameText.text = "STAGE CLEAR";
        // 스테이지 클리어에 대한 추가 로직을 여기에 추가하세요.
    }

    void GameFailed()
    {
        gState = GameState.Failed;
        gameText.text = "FAILED";
        // 실패에 대한 추가 로직을 여기에 추가하세요.
    }
}
