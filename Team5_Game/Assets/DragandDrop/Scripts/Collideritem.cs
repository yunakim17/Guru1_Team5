using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Collideritem : MonoBehaviour, IPointerDownHandler
{
    public static Collideritem Instance;//다른 스크립트에서 이 스크립트의 함수를 호출할 때 필요

    private void Awake()
    {
        if (Collideritem.Instance == null)//다른 스크립트에서 이 스크립트의 함수를 호출할 때 필요

        {
            Collideritem.Instance = this;
        }
    }


    public Image itemImage;


    //public GameObject currentItem;



    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemImage != null && eventData.pointerCurrentRaycast.gameObject == itemImage.gameObject)
        {


            GameObject currentItem = eventData.pointerCurrentRaycast.gameObject;

            if (currentItem != null)
            {
                Debug.Log("현재 선택된 아이템: " + currentItem.name);

            }
            else
            {
                Debug.Log("현재 선택된 아이템이 없습니다.");
            }
        }
    }
}



 





