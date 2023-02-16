using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;
    private PlayerController playerController;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI mainMenu;
    public TextMeshProUGUI gameOverScreen;
    public int size;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        sizeText.text = "Size: " + size;
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
