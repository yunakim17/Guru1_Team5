using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    PlayerMove playerMove;

    public enum GameState
    {
        Ready,
        Run,
        StageClear,
        Failed,
        ReturnToPickUp
    }

    public GameState gState;
    
    Text gameText;

    public GameObject gameLabel;

    public Timer timer;

    public GameObject nextSceneButton;



    public GameObject certificate;

    PlayerMove Player;

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();

        timer = GameObject.Find("TimeBar").GetComponent<Timer>();

        nextSceneButton.SetActive(false);

        certificate.SetActive(false);

        gameText.text = "Stage 1";

        StartCoroutine(ReadyToStart());

    }

    IEnumerator ReadyToStart()
    {
        Debug.Log("ReadyToStart Coroutine Started");

        
        yield return new WaitForSeconds(2f);

        gameText.text = "Start!";

        yield return new WaitForSeconds(1f);

        gameLabel.SetActive(false);

        gState = GameState.Run;

        Player = GameObject.Find("Player").GetComponent<PlayerMove>();

        
    }
    
    // Update is called once per frame
    void Update()
   {
       if(GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
       }

    }

    void OnTriggerEnter(Collider Scroll)
    {

        if (Scroll.tag == "Player")
        {
         

            if (GameObject.FindWithTag("Item") == null && timer.uiText.text != "00:00")
            {
                Debug.Log("아이템 획득 성공");
                GameClear();

                gameLabel.SetActive(true);

                Destroy(this.gameObject);
            }
            else if (GameObject.FindWithTag("Item") != null && timer.uiText.text != "00:00")
            {
                
                Debug.Log("아이템을 모두 획득하세요");

                StartCoroutine(ReturnTo());

                if (GameObject.FindWithTag("Item") == null && timer.uiText.text != "00:00")
                {
                    GameClear();
                }
                else if(timer.uiText.text == "00:00")
                {
                    GameFailed();
                }
            }

           else if(GameObject.FindWithTag("Item") == null && timer.uiText.text == "00:00")
            {
               Debug.Log("시간 초과");
                GameFailed();

                gameLabel.SetActive(true);

                Destroy(this.gameObject);
           }



           // gameLabel.SetActive(true);

           // Destroy(this.gameObject);
        }

        
        
    }
    
    void GameClear()
    {
        gState = GameState.StageClear;
        gameText.text = "STAGE CLEAR!";

        nextSceneButton.SetActive(true);

        ScoreManager.AddScore(1);
       

        // 스테이지 클리어에 대한 추가 로직.
    }

  IEnumerator ReturnTo()
    {
        gState = GameState.ReturnToPickUp;
        gameText.text = "Pick Up All Items";

        gameLabel.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameLabel.SetActive(false);

    }

    void GameFailed()
    {
        gState = GameState.Failed;
        gameText.text = "FAILED...";

        nextSceneButton.SetActive(true);
        // 실패에 대한 추가 로직
    }

   
}
