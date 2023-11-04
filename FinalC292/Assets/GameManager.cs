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
    //GameObjects
    public Player1 player;
    //Score Int
    public int score = 0;
    //UI 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI FirstText;
    public TextMeshProUGUI FirstTeleportText;
    public TextMeshProUGUI FishingText; 
    //UI Bools
    public bool FirstTeleportBool = false;
    public bool FishingBool = false;

    //background gameobjects
    public GameObject StartBackground;
    public GameObject medievalBackground;
    public GameObject DarkBackground;
    public GameObject snowBackground;
    public GameObject urbanBackground;
    public GameObject FinalBackground;
    public GameObject backGrounds;

    //Spawn Points
    public GameObject spawnMedieval;
    public GameObject spawnZLS;
    public GameObject spawnZRS;
    public GameObject spawnZLM;
    public GameObject spawnZRM;


    bool MedTeleport = true;
    


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

    private void Start()
    {
        spawnZLM.SetActive(false);
        spawnZRM.SetActive(false);
    }

    public void StartFishingSequence()
    {
            FirstText.gameObject.SetActive(false);
            StartCoroutine(ShowFishingTextWithDelay(4f));
            FishingBool = true;
            player.isFishing = false;
    }
    private IEnumerator ShowFishingTextWithDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);

        
        FishingText.gameObject.SetActive(true);
    }
    private void Update()
    {

        if(player.isFishing == true)
        {
            StartFishingSequence();
        }
        if (score == 50 && MedTeleport == true)
        {
            StartBackground.gameObject.SetActive(false);
            medievalBackground.gameObject.SetActive(true);
            player.transform.position = spawnMedieval.transform.position;
            foreach (GameObject zombie in GameObject.FindGameObjectsWithTag("Zombie")) GameObject.Destroy(zombie);
            EndPlayerTurn();
            spawnZLS.gameObject.SetActive(false);
            spawnZRS.gameObject.SetActive(false);
            spawnZLM.gameObject.SetActive(true);
            spawnZRM.gameObject.SetActive(true);
            FirstTeleportText.gameObject.SetActive(true);
            FirstTeleportBool = true;
            player.isStart = false;
            MedTeleport = false;
        }
        if (score == 100)
        {
            DarkBackground.gameObject.SetActive(true);
            medievalBackground.gameObject.SetActive(false);
        }
        if (score == 150)
        {
            snowBackground.gameObject.SetActive(true);
            DarkBackground.gameObject.SetActive(false);
        }
        if (score == 200)
        {
            urbanBackground.gameObject.SetActive(true);
            snowBackground.gameObject.SetActive(false);
        }
        if (score == 250)
        {
            FinalBackground.gameObject.SetActive(true);
            urbanBackground.gameObject.SetActive(false);
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
        player.hasMoved = false; 
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
