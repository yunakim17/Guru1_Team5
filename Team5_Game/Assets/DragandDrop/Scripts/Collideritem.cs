using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Collideritem : MonoBehaviour, IPointerDownHandler
{
    public static Collideritem Instance;//�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�

    private void Awake()
    {
        if (Collideritem.Instance == null)//�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�

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
                Debug.Log("���� ���õ� ������: " + currentItem.name);

            }
            else
            {
                Debug.Log("���� ���õ� �������� �����ϴ�.");
            }
        }
    }
}



 





