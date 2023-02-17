using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    bool isFingerDown;
    private Vector2 startPos;
    private int swipeDistance = 10;
    public GameObject player;
    public GameManager gameManager;
    private Touch touch;

    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameManager.isGameActive == true)
        {
            if (!isFingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                startPos = Input.touches[0].position;
                isFingerDown = true;
            }

            if (isFingerDown)
            {
                if (Input.touches[0].position.y >= startPos.y + swipeDistance)
                {
                    isFingerDown = false;
                    playerController.Jump();
                    Debug.Log("Swipe Up");
                }
                
               /* if (Input.touches[0].position.y <= startPos.y - swipeDistance)
                {
                    isFingerDown = false;
                    Debug.Log("Swipe Down");
                }
               */

                if (Input.touches[0].position.x >= startPos.x + swipeDistance)
                {
                    isFingerDown = false;
                    playerController.Move(Vector3.right);
                    Debug.Log("Swipe Right");
                }
                
                if (Input.touches[0].position.x <= startPos.x - swipeDistance)
                {
                    isFingerDown = false;
                    playerController.Move(Vector3.left);
                    Debug.Log("Swipe Left");
                }
            }
            if (isFingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            {
                isFingerDown = false;
            }
        }
    }
}
