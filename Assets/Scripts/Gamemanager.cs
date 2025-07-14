using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gamemanager : MonoBehaviour
{
    public Transform[] leftTargets;
    public Transform[] rightTargets;

    public Playercontroller eraserman;

    private int currentRow = 0;
    private bool hasJumped = false;

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
            //add a Game Over screen here later
        }
    }

    void UpdateHeartsUI()
    {
        if (lives <= 2) heart3.enabled = false;
        if (lives <= 1) heart2.enabled = false;
        if (lives <= 0) heart1.enabled = false;
    }
    void Start()
    {
        StartTurn();
    }

    public void StartTurn()
    {
        hasJumped = false;
    }

    public void JumpLeft()
    {
        if (hasJumped || currentRow >= leftTargets.Length) return;

        Vector3 jumpTarget = leftTargets[currentRow].position + Vector3.up * 0.5f;
        eraserman.JumpTarget(jumpTarget);

        hasJumped = true;
        currentRow++;


        StartCoroutine(JumpAgain());
    }

    public void JumpRight()
    {
        if (hasJumped || currentRow >= rightTargets.Length) return;

        Vector3 jumpTarget = rightTargets[currentRow].position + Vector3.up * 0.5f;
        eraserman.JumpTarget(jumpTarget);

        hasJumped = true;
        currentRow++;

        StartCoroutine(JumpAgain());
    }



    private IEnumerator JumpAgain()
    {
        yield return new WaitForSeconds(1f); 
        hasJumped = false;
    }

}
