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
            
            //����..���� ���ٴ� ȿ�� �ֱ�
            //�����Ǵ�� ���� 
        }
    }
}
