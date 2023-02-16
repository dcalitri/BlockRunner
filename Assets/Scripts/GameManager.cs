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
    public int distance;

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
        if (isGameActive == true)
        {
            StartCoroutine(IncreaseDistance());
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateDistance()
    {
        distanceText.text = $"Distance: " + distance;
    }
    IEnumerator IncreaseDistance()
    {
        while (isGameActive)
        {
            UpdateDistance();

            yield return new WaitForSeconds(1);
            distance++;
        }
    }
}
