using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject deadpanel;
    [SerializeField] private Gamemanager gameManager;

    public void ShowPanel()
    {
        panel.SetActive(true);
        gameManager.PauseGame();

    }
    public void HidePanel()
{
    panel.SetActive(false);
        gameManager.ResumeGame();

}
    public void Restart()
{
    panel.SetActive(false);
        gameManager.RestartGame();

}
public void dead()
    {
        deadpanel.SetActive(true);
        gameManager.PauseGame(); 
        
    }
}