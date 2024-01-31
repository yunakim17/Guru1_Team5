using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Consumables,
    Etc
}
[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;
   // public Item item;
   // public SpriteRenderer image;
    
    public bool use()
    {
        return false;
    }
    //public void SetItem(Item _item)
    //{
       // Item.itemName = _item.itemName;
      //  item.itemImage = _item.itemImage;
       // item.itemType = item.itemType;

      //  image.sprite = item.itemImage;
  //  }
    //public Item GetItem()
   // {
     //   return item;

 //   }

    
}
    

    
    // Start is called before the first frame update
    
    // Update is called once per frame
   