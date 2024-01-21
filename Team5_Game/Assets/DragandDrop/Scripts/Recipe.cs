using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Recipe : MonoBehaviour
{
    public static Recipe Instance;//�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�

    private void Awake()
    {
        if (Recipe.Instance == null)//�ٸ� ��ũ��Ʈ���� �� ��ũ��Ʈ�� �Լ��� ȣ���� �� �ʿ�

        {
            Recipe.Instance = this;
        }
    }


    public List<GameObject> Recipe1Objects = new List<GameObject>(); //�� ������ ��ῡ �ش��ϴ� ���� ������Ʈ���� ��� ���� ����Ʈ
    public List<GameObject> Recipe2Objects = new List<GameObject>();
    public List<GameObject> Recipe3Objects = new List<GameObject>();

    public bool FirstRecipeOn = false;
    public bool SecondRecipeOn = false;
    public bool ThirdRecipeOn = false;


    public GameObject objectToDrag;
    public GameObject objectDragToPos;

    public float Dropdistance;


    public void DragObject()
    {
        objectToDrag.transform.position = Input.mousePosition;// ��ü�� Ŀ���� ���󰡰���
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPos.transform.position);

        if (FirstRecipeOn == true && Recipe1Objects.Contains(gameObject))
        {
            objectToDrag.transform.position = objectDragToPos.transform.position;
            Debug.Log("1�� ������ ��� ����");

        }
        else if (SecondRecipeOn == true && Recipe2Objects.Contains(gameObject))
        {
            objectToDrag.transform.position = objectDragToPos.transform.position;
            Debug.Log("2�� ������ ��� ����");
        }
       
        else if (ThirdRecipeOn == true && Recipe3Objects.Contains(gameObject))
        {
            objectToDrag.transform.position = objectDragToPos.transform.position;
            Debug.Log("3�� ������ ��� ����");
        }
        else
        {
            Debug.Log("�� ��� �ƴ�!!");

        }

    }

    //&& Distance < Dropdistance
    //EventSystem.current.currentSelectedGameObject

    public void FirstRecipe() //ù��° �����ǰ� ȣ��Ǹ�
    {
        FirstRecipeOn = true;
        Debug.Log("first");
    }

    public void SecondRecipe() //ù��° �����ǰ� ȣ��Ǹ�
    {
        SecondRecipeOn = true;
        Debug.Log("second");
    }
    
    public void ThirdRecipe() //ù��° �����ǰ� ȣ��Ǹ�
    {
        ThirdRecipeOn = true;
        Debug.Log("third");
    }
}
