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
        Failed
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

        if (timer != null)
        {
            timer.Being(60); // Replace yourDurationValue with the desired duration.
        }
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
         

            if (GameObject.FindWithTag("Item") == null)
            {
                Debug.Log("������ ȹ�� ����");
                GameClear();

                if(timer == null)
                {
                    Debug.Log("�ð� �� ���� ����");
                    GameFailed();
                }
            }
            else
            {
                Debug.Log("������ ȹ�� ����");
                GameFailed();
            }

            gameLabel.SetActive(true);

            Destroy(this.gameObject);
        }

        
        
    }
    
    void GameClear()
    {
        gState = GameState.StageClear;
        gameText.text = "STAGE CLEAR";

        certificate.SetActive(true);

        nextSceneButton.SetActive(true);
        // �������� Ŭ��� ���� �߰� ������ ���⿡ �߰��ϼ���.
    }

    void GameFailed()
    {
        gState = GameState.Failed;
        gameText.text = "FAILED";

        nextSceneButton.SetActive(true);
        // ���п� ���� �߰� ������ ���⿡ �߰��ϼ���.
    }

   
}
