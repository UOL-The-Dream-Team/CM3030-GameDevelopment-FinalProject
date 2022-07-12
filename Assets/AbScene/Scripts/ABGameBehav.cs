using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ABGameBehav : MonoBehaviour
{
    public int enemyDestroyed = 0;
    public int playerHP = 5;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP == 0)
        {
            Time.timeScale = 0f;
            gameOver = true;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20,20,150,25), "Player Health:" + playerHP);
        GUI.Box(new Rect(20,50,150,25), "Enemy Destroyed:" + enemyDestroyed);

        if (gameOver)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "GAME OVER"))
            {
                SceneManager.LoadScene(1);
                Time.timeScale = 1.0f;
            }
        }
    }
}
