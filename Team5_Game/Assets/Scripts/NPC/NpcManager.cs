using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcManager : MonoBehaviour
{
    public Text talkText;
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject talkPanel;
    public bool isAction;
    public int talkIndex;
    public int questId;
    public GameObject NextSceneButton;

    //int clickCount = 0;


    
    public void Awake()
    {
        talkPanel.SetActive(isAction);
        NextSceneButton.SetActive(false);
        //Talk(objData.id, objData.isNpc);
        //씬 전환되면 자동으로 시작하도록 구현필요
    }
    void update()
    {
       // if (Input.GetMouseButtonDown(0))
       // {
         //   if(ClickCount == 0)
           // {

          //  }
       // }
    }
    void Talk(int id, bool isNpc)
    {
        //int questTalkIndex = talkManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null )
        {
            //NextSceneButton.SetActive(true);
            isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        talkIndex++;

    }

   
    
}
