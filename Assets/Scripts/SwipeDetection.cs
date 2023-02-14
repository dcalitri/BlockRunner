using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    bool isFingerDown;
    private Vector3 startPos;
    private int swipeDistance = 10;
    private int leftBound = -2;
    private int rightBound = 2;

    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isFingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            isFingerDown = true;
        }

        if (isFingerDown)
        {
            if (Input.touches[0].position.x >= startPos.x + swipeDistance && transform.position.x >= rightBound)
            {
                isFingerDown = false;
                playerController.Move(Vector3.right);
                Debug.Log("Swipe Right");
            }
            else if (Input.touches[0].position.x >= startPos.x + swipeDistance && transform.position.x <= leftBound)
            {
                isFingerDown = false;
                playerController.Move(Vector3.left);
                Debug.Log("Swipe Left");
            }
            else if (Input.touches[0].position.y >= startPos.y + swipeDistance)
            {
                isFingerDown = false;
                playerController.Jump();
                Debug.Log("Swipe Up");
            }

            if (isFingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {
                isFingerDown = false;
            }
        }
    }
}
