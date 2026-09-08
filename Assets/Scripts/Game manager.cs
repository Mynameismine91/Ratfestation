using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public int numberofrats;
public int points = 0;
public int CheeseOnDeck = 0;
  [SerializeField] private TMP_Text scoreText;
  [SerializeField] private TMP_Text FinalText;
  [SerializeField] private UIManager UI;
  public void UpdateScoreText()
    {
        scoreText.text = "Score: " + points;

        if(numberofrats >= 50)
        {
            UpdateFinalText();
            PauseGame();
            UI.dead();
        }
      
    }

  public void UpdateFinalText()
    {
        FinalText.text = "" + points;
      
    }
    public void PauseGame()
{
    Time.timeScale = 0f;
}

public void ResumeGame()
{
    Time.timeScale = 1f;
}

public void RestartGame()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}






}
