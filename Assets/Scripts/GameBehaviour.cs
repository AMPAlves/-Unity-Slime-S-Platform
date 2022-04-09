using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public GameObject player;
    private bool gameRunning;
    private HealthSystem hpSystem;
    private PointSystem pointSystem;
    private Color orange = new Color(1.0f, 0.64f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
        hpSystem = new HealthSystem(100);
        pointSystem = new PointSystem(3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            takeDamage(25);
            Debug.Log("BIDA DO MORCOUM " + hpSystem.getHPPercentile());
        }
        playerHPChecker();
    }

    private void OnGUI()
    {
        if (gameRunning)
        {
            GUI.contentColor = Color.black;
            GUI.skin.label.fontSize = 40;
            GUI.Label(new Rect(10, 20, 400, 100), "Collected: " + pointSystem.getPoints() + " / " + pointSystem.getMaxPoints());
            GUI.Label(new Rect(10, 50, 400, 100), "Health " + hpSystem.getHPPercentile() * 100 + "%");
            GUI.Label(new Rect(10, 85, 500, 120), "Charged Jumping: " + player.GetComponent<PlayerBehaviour>().hasJumpPowerUp());
        } else 
        {
            GUI.contentColor = Color.red;
            GUI.skin.label.fontSize = 80;
            GUI.Label(new Rect(475, 225, 600, 300), "Game Over");
        }
    }

    public void playerHPChecker()
    {
        var pHP = hpSystem.getHPPercentile();
        player.GetComponent<Renderer>().material.color = pHP >= 1
            ? player.GetComponent<Renderer>().material.color
            : pHP >= 0.75
                ? Color.yellow
                : pHP >= 0.5
                    ? orange
                    : pHP >= 0.25
                        ? Color.red
                        : Color.black;
        if(pHP <= 0)
        {
            gameOver();
        }
    }

    public void takeDamage(int damage)
    {
        hpSystem.takeDamage(damage);
    }

    public void addPoints()
    {
        pointSystem.addPoints();
    }

    private void gameOver()
    {
        gameRunning = false;
        Time.timeScale = 0;
    }
}
