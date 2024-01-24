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
            Debug.Log("�̷�Ż�� ����");

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
        // �������� Ŭ��� ���� �߰� ������ ���⿡ �߰��ϼ���.
    }

    void GameFailed()
    {
        gState = GameState.Failed;
        gameText.text = "FAILED";
        // ���п� ���� �߰� ������ ���⿡ �߰��ϼ���.
    }
}
