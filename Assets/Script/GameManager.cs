using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Obstacle> obstacles = new List<Obstacle>();
    public static GameManager gameManager;
    [SerializeField] private GameObject[] panels; // панели победы и проигрыша 
    [SerializeField] private Player player;
    [SerializeField] private Animator doel;
    private void Awake()
    {
        doel.enabled = false;
        player.notify += EndGame;
        if (gameManager == null) gameManager = this;
        else return;
    }
    public void AddListObstacles(Obstacle _obstacle)
    {
        obstacles.Add(_obstacle);
    }

    public void DeleteItemObstacles(Obstacle _obstacle) 
    {
        obstacles.Remove(_obstacle);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void EndGame(int index)
    {
        if (index == 2)
        {
            doel.enabled = true;
        }
        else panels[index].SetActive(true);
    }

}
