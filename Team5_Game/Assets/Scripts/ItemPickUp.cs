using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ĳ���� �浹");
            Destroy(this.gameObject);
        }
    }

    public string itemName = "DefaultItem";

    public string GetItemName()
    {
        return itemName;
    }

   
}
