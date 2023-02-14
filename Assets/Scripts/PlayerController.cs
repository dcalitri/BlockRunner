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
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && isOnGround && !isGameOver)
        {
            Touch touch = Input.GetTouch(0);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
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
            playerAudio.PlayOneShot(deathSound, 1.0f);
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            playerAudio.PlayOneShot(pickUpSound, 1.0f);
        }
    }
}
