using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    
    public int score = 0;

    //* public int health = 0;
    public GameObject pickupParent;

    public TextMeshProUGUI healthText;

    public int totalPickups = 0;

    public TextMeshProUGUI scoreText;

    public PlayerControls player;

    public EnemyFollow enemy;

    public GameObject victoryText;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Cannot have more than one instance of [GameManager]in the sece! Deleted exra copy");
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void Start()
    {
        score = 0;

        victoryText.SetActive(false);
        //* health = 3;
      
        
        totalPickups = pickupParent.transform.childCount;
    }

    public void UpdateScore(int amount)
    {
 
        score = score + amount;
        UpdateScoreText();

        if (totalPickups <= 0)
        {
            WinGame();
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void WinGame()
    {
        victoryText.SetActive(true);
        GameOver();
    }

    public void GameOver()
    {
        Invoke("LoadCurrentLevel", 2f);
    }

    private void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseGame()
    {
        if(player.health <= 0)
        {
            GameOver();
        }
    }


}
