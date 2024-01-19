using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MagicPotDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if(eventData.pointerDrag != null)
        {
           
           //if(GetComponent<"item">) 
            
            //연기..뭔가 들어갔다는 효과 주기
            //레시피대로 들어가면 
        }
    }
}
