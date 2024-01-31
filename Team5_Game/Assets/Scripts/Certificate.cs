using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Certificate : MonoBehaviour
{
    private Camera mainCamera;
    private bool isMoving;
    private float moveTime;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false && Input.GetMouseButtonDown(0))
        {
            startPosition = transform.position;
            targetPosition = mainCamera.ScreenToWorldPoint(new Vector3(-301, 148, mainCamera.nearClipPlane));
            moveTime = 0;
            isMoving = true;
        }

        if (isMoving)
        {
            moveTime += Time.deltaTime;
            float t = moveTime / 1f;

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            if (t >= 1f)
            {
                transform.position = targetPosition;
                isMoving=false;
                Debug.Log("µµÂø");
            }
        }
    }
}
