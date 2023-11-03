using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    public Player1 player1;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI FirstText;

    //background gameobjects
    public GameObject StartBackground;
    public GameObject medievalBackground;
    public GameObject DarkBackground;
    public GameObject DessertBackground;
    public GameObject snowBackground;
    public GameObject urbanBackground;
    public GameObject FinalBackground;
    string currentBackground = "Start";
    public GameObject backGrounds;
    


    public enum TurnState
    {
        PlayerTurn,
        EnemyTurn,
    }


    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();

    }

    private void Update()
    {
        if (score > 50)
        {
            StartBackground.gameObject.SetActive(false);
            medievalBackground.gameObject.SetActive(true);
            currentBackground = "medieval";
            Debug.Log(currentBackground);
        }
        if (score > 100)
        {
            DarkBackground.gameObject.SetActive(true);
            medievalBackground.gameObject.SetActive(false);
            currentBackground = "Dark";
            Debug.Log(currentBackground);
        }
        if (score > 150)
        {
            DessertBackground.gameObject.SetActive(true);
            DarkBackground.gameObject.SetActive(false);
            currentBackground = "Dessert";
            Debug.Log(currentBackground);
        }
        if (score > 200)
        {
            snowBackground.gameObject.SetActive(true);
            DessertBackground.gameObject.SetActive(false);
            currentBackground = "snow";
            Debug.Log(currentBackground);
        }
        if (score > 250)
        {
            urbanBackground.gameObject.SetActive(true);
            snowBackground.gameObject.SetActive(false);
            currentBackground = "urban";
            Debug.Log(currentBackground);
        }
        if (score > 300)
        {
            FinalBackground.gameObject.SetActive(true);
            urbanBackground.gameObject.SetActive(false);
            currentBackground = "Final";
            Debug.Log(currentBackground);
        }
    }

    public Zombie zombie;

    public  TurnState currentState;

    public TurnState CurrentState
    {
        get { return currentState; }
    }



    public void EndPlayerTurn()
    {
        //currentState = TurnState.EnemyTurn;
        player1.hasMoved = false; 
        //Debug.Log(currentState);
        foreach(GameObject z in GameObject.FindGameObjectsWithTag("Zombie"))
        {
            z.GetComponent<Zombie>().Move();
        }
    }

    //public void EndEnemyTurn()
    //{
       // currentState = TurnState.PlayerTurn;
       // Debug.Log(currentState);
    //}
}
