using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject loseArea;
    [SerializeField] private GameObject winArea;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void RestartGama()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowLoseArea()
    {
        loseArea.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowWinArea()
    {
        winArea.SetActive(true);
        Time.timeScale = 0;
    }
}
