using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("캐릭터 충돌");
            Destroy(this.gameObject);
        }
    }

    public string itemName = "DefaultItem";

    public string GetItemName()
    {
        return itemName;
    }

   
}
