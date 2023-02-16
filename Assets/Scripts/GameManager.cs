using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;
    private PlayerController playerController;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI mainMenu;
    public TextMeshProUGUI gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;
        playerController.isGameOver = false;
    }

    public void GameOver()
    {
        if (playerController.isGameOver == true)
        {
            isGameActive = false;
            gameOverScreen.enabled = true;
        }
    }
}
