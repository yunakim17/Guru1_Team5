using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public float distance;
    public LayerMask isLayer;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestoryMagic", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestoryMagic()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            DestoryMagic();

            Enemy hitenemy = other.gameObject.GetComponent<Enemy>();

            GameObject playerObject = GameObject.Find("Player");
            PlayerAttack playerAttackScript = playerObject.GetComponent<PlayerAttack>();


            // null 체크 추가
            if (hitenemy != null && playerAttackScript != null)
            {
                hitenemy.HitEnemy(playerAttackScript.MagicPower);
            }
            else
            {
                Debug.LogError("Enemy component or PlayerAttack component not found on the collided objects.");
            }

            //hitenemy.HitEnemy(playerAttackScript.MagicPower);
        }

    }


}
