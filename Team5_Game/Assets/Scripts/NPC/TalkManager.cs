using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;

    void Awake()
    {
      portraitData = new Dictionary<int, Sprite>();
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "NPC 대사1" });

        talkData.Add(2000, new string[] { "플레이어 대사1" });

        talkData.Add(1000, new string[] { "NPC 대사2" });

        talkData.Add(2000, new string[] { "플레이어 대사2" });

        //portraitData.Add(1000, portraitArr[0]);
        //portraitData.Add(2000, portraitArr[1]);
    }
    // Update is called once per frame
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        } 
    }
        public Sprite GetPortrait(int id, int portraitIndex)
        {
            return portraitData[id + portraitIndex];
        }
        
    
}
