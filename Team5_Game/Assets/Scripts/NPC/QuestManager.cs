using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;

    Dictionary<int, questData> questList;

    void Awake()
    {
        questList = new Dictionary<int, questData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(1000, new questData("교수님과 대화", new int[] { 1000 }));
    }

    public int GetQuestTalkIndex(int id)
   {
        return questId;
    }
}
