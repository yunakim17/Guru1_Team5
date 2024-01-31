using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questData 
{
    public string questName;
    public int[] npcId;

    public questData(string name, int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}
