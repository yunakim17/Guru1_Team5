using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 70;
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);

        transform.position += dir * speed * Time.deltaTime;
        //print("h:"+ h ",v:" +v);
        //transform.Translate(Vector3.right * 5 * Time.deltaTime);

        //Vector3 dir = Vector3.right * h + Vector3.up * v;
       
    }
}
