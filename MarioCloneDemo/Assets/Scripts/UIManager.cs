using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI pointText;
    private int currentPoints = 0;
    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }


    public void IncreaseScore(int points)
    {
        currentPoints += points;
        pointText.text = "x" + currentPoints;
    }

    public void endGame()
    {
        Time.timeScale = 0;
        pointText.text = "You win with " + currentPoints + " points! Press Enter to Restart.";
        gameEnded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1; //resume
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
