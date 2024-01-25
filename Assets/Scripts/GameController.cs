using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Puck puck;
    public GameObject Respawner;
    public TMP_Text scoreText;
    public TMP_Text annocument;

    public GameObject paddleOne;
    public GameObject paddleTwo;

    private Vector3 startingPositionPuck;
    private Vector3 startingPositionPaddle;

    [SerializeField]private int player_OneScore = 0;
    [SerializeField]private int player_TwoScore = 0;
    private bool isGameOver;
    private float resetTimer = 5f;

    void Start()
    {
        puck.OnGoal += OnGoal; // Storing OnGoal method to puck
        startingPositionPuck = Respawner.transform.position;
        startingPositionPaddle = Respawner.transform.position;
        puck.transform.position = startingPositionPuck;
        scoreText.text = player_OneScore + " - " + player_TwoScore;
        annocument.text = "";
        ResetPaddles();
    }

    private void Update()
    {
        if (isGameOver)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0 )
            {
                SceneManager.LoadScene("Game");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void OnGoal()
    {
        if (puck.transform.position.x > 0)
        {
            player_OneScore++;
            ResetPuck(true);
        }
        else if (puck.transform.position.x < 0)
        {
            player_TwoScore++;
            ResetPuck(false);
        }
        else
        {
            puck.transform.position = startingPositionPuck;
        }

        ResetPaddles();
        scoreText.text = player_OneScore + " - " + player_TwoScore;

        if (player_OneScore == 3)
        {
            isGameOver = true;
            puck.gameObject.SetActive(false);
            annocument.text = "Player One Wins!";
        } else if (player_TwoScore == 3)
        {
            isGameOver = true;
            puck.gameObject.SetActive(false);
            annocument.text = "Player Two Wins!";
        }
    }

    void ResetPuck(bool isscored)
    {
        puck.transform.position = new Vector3(
            startingPositionPuck.x + ( isscored ? -1.5f : 1.5f),
            startingPositionPuck.y,
            startingPositionPuck.z
            );
    }

    void ResetPaddles()
    {
        paddleOne.transform.position = new Vector3(
            startingPositionPaddle.x = -4.15f,
            startingPositionPaddle.y + .1f,
            startingPositionPaddle.z
            );
        paddleTwo.transform.position = new Vector3(
            startingPositionPaddle.x = 4.15f,
            startingPositionPaddle.y + .1f,
            startingPositionPaddle.z
            );
    }
}
