using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject adButton;

    private int gameScene = 0;
    private bool hasUsedExtraLife = false;
    private PlayerMovement playerSpeed;
    private Rigidbody player;
    private UIManager uIManager;
    private SphereCollider sphereCollider;

    void Awake()
    {
        playerSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        sphereCollider = GameObject.Find("Player").GetComponent<SphereCollider>();
    }

    void Start()
    {
        if (!uIManager)
            return;

        Time.timeScale = 0;
        uIManager.inPauseUI.SetActive(false);
        uIManager.menuUI.SetActive(true);
        uIManager.inGameUI.SetActive(false);
        uIManager.gameOverMenuUI.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        uIManager.menuUI.SetActive(false);
        uIManager.inPauseUI.SetActive(true);
        uIManager.inGameUI.SetActive(false);
        uIManager.gameOverMenuUI.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        uIManager.menuUI.SetActive(false);
        uIManager.inPauseUI.SetActive(false);
        uIManager.inGameUI.SetActive(true);
        uIManager.gameOverMenuUI.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void PlayerDeath()
    {
        Time.timeScale = 0;
        uIManager.menuUI.SetActive(false);
        uIManager.inPauseUI.SetActive(false);
        uIManager.inGameUI.SetActive(false);
        uIManager.gameOverMenuUI.SetActive(true);

        if(hasUsedExtraLife)
        {
            adButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            adButton.GetComponent<Button>().enabled = false;
        }
    }

    public void ExtraLife()
    {
        hasUsedExtraLife = true;

        sphereCollider.enabled = false;
        uIManager.menuUI.SetActive(false);
        uIManager.inPauseUI.SetActive(false);
        uIManager.inGameUI.SetActive(true);
        uIManager.gameOverMenuUI.SetActive(false);
        StartCoroutine(ExtraChance(1.5f));
        Time.timeScale = 1;
    }

    IEnumerator ExtraChance(float waitTime)
    {
        //parar o player
        player.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(waitTime);

        // retornar a mover
        player.constraints = RigidbodyConstraints.FreezePositionY;
        sphereCollider.enabled = true;
        
        if (playerSpeed.speed >= 2500)
            playerSpeed.speed = 2500f;
    }
}
