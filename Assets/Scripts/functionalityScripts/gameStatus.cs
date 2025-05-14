using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStatus : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject youWinUI;
    public int portalsLeftToDestroy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        portalsLeftToDestroy = 5;
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
    public void youWin()
    {
        Time.timeScale = 0;
        youWinUI.SetActive(true);
    }
    public void Retry()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(portalsLeftToDestroy==0)
        {
            youWin();
        }
    }
}
