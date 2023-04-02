using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
public enum GameState {MainMenu, Paused, Playing, GameOver};
    public GameState currentState;
    public TextMeshProUGUI ammoText;
    public Image redKeyUI, blueKeyUI, greenKeyUI;
    public GameObject allGameUI, mainMenuPanel, pauseMenuPanel, gameOverPanel, titleText, hitScreen, lowHealth;
    public float UIHealth;
    // Start is called before the first frame update
    private void Awake() {
        if (SceneManager.GetActiveScene().name == "Menu") {
            CheckGameState(GameState.MainMenu);
        }
        else {
            CheckGameState(GameState.Playing);
        }
        CheckPlayerHealth();
        
    }

    public void CheckPlayerHealth(){
        UIHealth = PlayerHealth.health;
    }

    
    public void CheckGameState(GameState newGameState){
        currentState = newGameState;
        switch(currentState){
            case GameState.MainMenu:
                MainMenuSetup();
                break;
            case GameState.Paused:
                GamePaused();
                Manager.isPaused = true;
                Time.timeScale = 0f;
                break;
            case GameState.Playing:
                GameActive();
                Manager.isPaused = false;
                Time.timeScale = 1f;
                break;
            case GameState.GameOver:
                GameOver();
                Manager.isPaused = true;
                Time.timeScale = 0f;
                break;
        }
    }
    public void MainMenuSetup(){
        allGameUI.SetActive(false);
        mainMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
        hitScreen.SetActive(false);
        lowHealth.SetActive(false);
    }

    public void GameActive(){
        allGameUI.SetActive(true);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        titleText.SetActive(false);
        lowHealth.SetActive(false);
        
    }

    public void GamePaused(){
        allGameUI.SetActive(true);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
        hitScreen.SetActive(false);
    }

    public void GameOver(){
        allGameUI.SetActive(false);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        titleText.SetActive(true);
        hitScreen.SetActive(false);
        lowHealth.SetActive(false);
    }

    public void HitEffect(){
        StartCoroutine(HitEffectRoutine());
    } 

    IEnumerator HitEffectRoutine(){
        hitScreen.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hitScreen.SetActive(false);
    }

    public void LowHealthEffect(){
        if(GameState.Playing == currentState){
        if (UIHealth <= 2){
            lowHealth.SetActive(true);
        }
        else{
            lowHealth.SetActive(false);
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckPlayerHealth();
        LowHealthEffect();
    }


    void CheckInput(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (currentState == GameState.Playing){
                CheckGameState(GameState.Paused);
            }
            else if (currentState == GameState.Paused){
                CheckGameState(GameState.Playing);
            }
        }
    }
    public void StartGame(){
        SceneManager.LoadScene("Level1");
        CheckGameState(GameState.Playing);
    }
    public void PauseGame(){
        CheckGameState(GameState.Paused);
    }

    public void ResumeGame(){
        CheckGameState(GameState.Playing);
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("Menu");
        CheckGameState(GameState.MainMenu);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void UpdateAmmo(){
        ammoText.text = Manager.ammoCount.ToString();
    }

    public void UpdateKeys(Manager.DoorKeyColours keyColour){
        switch(keyColour){
            case Manager.DoorKeyColours.Red:
                redKeyUI.GetComponent<Image>().color = Color.red;
                break;
            case Manager.DoorKeyColours.Blue:
                blueKeyUI.GetComponent<Image>().color = Color.blue;
                break;
            case Manager.DoorKeyColours.Green:
                greenKeyUI.GetComponent<Image>().color = Color.green;
                break;
        }
        
    }
}
