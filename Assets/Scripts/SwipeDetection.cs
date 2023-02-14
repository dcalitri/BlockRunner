using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    bool isFingerDown;
    private Vector3 startPos;
    private int swipeDistance = 2;
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
            if (Input.touches[0].position.x >= startPos.x + swipeDistance)
            {
                isFingerDown = false;
                playerController.Move(Vector3.right);
            }
            else if (Input.touches[0].position.x <= startPos.x + swipeDistance)
            {
                isFingerDown = false;
                playerController.Move(Vector3.left);
            }

            if (isFingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {
                isFingerDown = false;
            }
        }
    }
}
