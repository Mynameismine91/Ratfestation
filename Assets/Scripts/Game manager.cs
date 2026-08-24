using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{
public int points = 0;
  [SerializeField] private TMP_Text scoreText;

  public void UpdateScoreText()
    {
        scoreText.text = "Score: " + points;
    }





}
