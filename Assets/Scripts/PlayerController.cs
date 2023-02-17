using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip dodgeSound;
    public AudioClip deathSound;
    public AudioClip pickUpSound;
    public bool isOnGround = true;
    public bool isGameOver = false;
    private GameManager gameManager;
    public float moveSpeed;
    private Vector3 targetPos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        targetPos = transform.position;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();    
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
    public void Move(Vector3 moveDirection)
    {
        targetPos += moveDirection;
        playerAudio.PlayOneShot(dodgeSound, 1.0f);
    }

    public void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            gameManager.GameOver();
            playerAudio.PlayOneShot(deathSound, 1.0f);
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            transform.localScale += new Vector3(0, 1.4f, 0);
            gameManager.size += 1;
            playerAudio.PlayOneShot(pickUpSound, 1.0f);
            if (gameManager.size > PlayerPrefs.GetInt("Largest Size", 0))
            {
                PlayerPrefs.SetInt("Largest Size", gameManager.size);
            } 
        }
    }
}
