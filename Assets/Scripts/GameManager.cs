using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    BaseShape[] shapes;

    [SerializeField]
    GameObject gameOverScreen;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    TextMeshProUGUI bestScoreText;

    [SerializeField]
    TextMeshProUGUI playerNameText;

    [SerializeField]
    TextMeshProUGUI bottomText;



    [SerializeField]
    float startTime = 3.0f;
    [SerializeField]
    float timeToSelection;
    [SerializeField]
    float delay;


    string gamePhase;

    float timer;
  

    void Start()
    {
        //playerNameText.text = Main.s.namePlayer;
        Invoke("StartGame", 3.0f);

        playerNameText.text = Main.s.namePlayer;

        UpdateBestScore();

    }

    void StartGame()
    {
        timeToSelection = 3.0f;
        delay = 3.0f;

        SetGamePhase("pre_start");

        Invoke("NewRandomSelection", startTime);
    }

    void NewRandomSelection()
    {
        SetGamePhase("active");

        StartCoroutine("SelectRandomShape");
    }

    IEnumerator SelectRandomShape()
    {
        int ind = Random.Range(0, shapes.Length);

        shapes[ind].HighlightAction(true);

        yield return new WaitWhile( () => timer > 0 );

        shapes[ind].HighlightAction(false);
        GameOver();
    }



    void GameOver()
    {
        ResetBlinks();
        SetGamePhase("");
        gameOverScreen.SetActive(true);

        UpdateBestScore();
    }


    private void UpdateBestScore()
    {
        Main.s.CheckBestScore();
        bestScoreText.text = $"Best Score: {Main.s.bestScore}";
    }

    public void RestartRound()
    {
        gameOverScreen.SetActive(false);

        Main.s.ResetScore();
        UpdateScores();

        StartGame();
    }

    public void BackToMainMenu()
    {
        Main.s.ResetScore();
        SceneManager.LoadScene(0);
    }


    public void Check()
    {
        StopCoroutine("SelectRandomShape");
        Main.s.AddScore(1);
        UpdateScores();

        delay *= 0.95f;
        timeToSelection *= 0.9f;

        SetGamePhase("pre_start");
        Invoke("NewRandomSelection", timeToSelection);
    }

    public void UpdateScores()
    {
        scoreText.text = $"Score: {Main.s.score}";
    }


    void ResetBlinks()
    {
        foreach (BaseShape shape in shapes)
        {
            shape.Blink(false);
        }
    }


    void SetGamePhase( string phase )
    {
        switch (phase)
        {
            case "pre_start":

                gamePhase = "pre_start";
                timer = timeToSelection;

            break;

            case "active":

                gamePhase = "active";
                timer = delay;

            break;

            default:

                gamePhase = "";
                bottomText.text = "";

            break;
        }

    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(gamePhase == "pre_start")
        {
            bottomText.text = $"Ready {timer.ToString("0.0")}sec";
            timer -= Time.deltaTime;
        }

        if (gamePhase == "active")
        {
            bottomText.text = timer.ToString("0.0");
            timer -= Time.deltaTime;
        }


        if ( timer < 0 ) { timer = 0; }


    }
}
