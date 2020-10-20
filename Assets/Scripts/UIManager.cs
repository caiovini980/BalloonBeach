using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public TextMeshProUGUI highScoreUI;
    private PlayerMovement player;
    public GameObject inGameUI, inPauseUI, gameOverMenuUI, menuUI;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        inGameUI = GameObject.Find("InGame_UI");
        inPauseUI = GameObject.Find("InPause_UI");
        gameOverMenuUI = GameObject.Find("GameOverMenu_UI");
        menuUI = GameObject.Find("Menu_UI");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!inGameUI || !inPauseUI || !gameOverMenuUI)
            return;

        scoreText.text = "" + 0;
        highScoreUI.text = "" + 0;
    }

    // Update is called once per frame
    public void UpdateScore(int playerScore)
    {
        scoreText.text = playerScore.ToString();
    }
}
