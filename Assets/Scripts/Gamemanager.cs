using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gamemanager : MonoBehaviour
{

    public int lives = 3;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public void OnPlayerHit()
    {
        lives--;

        UpdateHeartsUI();

        if (lives <= 0)
        {
            Debug.Log("Game Over!");
            // You can add a Game Over screen here later
        }
    }

    void UpdateHeartsUI()
    {
        if (lives <= 2) heart3.enabled = false;
        if (lives <= 1) heart2.enabled = false;
        if (lives <= 0) heart1.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
