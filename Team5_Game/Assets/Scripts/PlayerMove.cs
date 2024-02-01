using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private GameManager GamemanagerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float moveSpeed = 11f;
    //Vector3 lookDirection;
    
    // Update is called once per frame
    void Update()
    {
       
            // 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다.
         if (GameManager.gm.gState != GameManager.GameState.Run && GameManager.gm.gState != GameManager.GameState.ReturnToPickUp)
         {
            return;
         }


            float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        //Vector3 dir = new Vector3(h, 0, v);
        //dir = dir.normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
        //print("h:"+ h ",v:" +v);
        //transform.Translate(Vector3.right * 5 * Time.deltaTime);

        //Vector3 dir = Vector3.right * h + Vector3.up * v;
       // transform.rotation = Quaternion.LookRotation(lookDirection);
   
    }
}
