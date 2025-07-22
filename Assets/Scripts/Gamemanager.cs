using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gamemanager : MonoBehaviour
{
    public GameObject GameOverText;

    
    public Transform[] leftTargets;
    public Transform[] rightTargets;

    public Playercontroller eraserman;

    private int currentRow = 0;
    private bool hasJumped = false;

    public EnemyShooter enemyshooter;
    private bool BulletFlying = false;

    public int lives = 4;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;

    public Text Timer;
    private float timer;
    private bool timerON = false;

    public void OnPlayerHit()
    {
        lives--;

        UpdateHeartsUI();

        if (lives <= 0)
        {
            Debug.Log("Game Over!");
            GameOverText.SetActive(true);
            
        }
    }

    void UpdateHeartsUI()
    {
        if (lives <= 3) heart4.enabled = false;
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
        timer = 11f;
        timerON = true;
        TimerUI();

    }

    private void Update()
    {
        if (timerON)
        {
            timer -= Time.deltaTime;
            TimerUI();

            if (timer <= 0f)
            {
                timerON = false;
                timer = 0f;
                TimesUp();
            }
        }
    }

    void TimerUI()
    {
        int displayTime = Mathf.Max(0, Mathf.FloorToInt(timer));
        Timer.text = displayTime.ToString();
    }

    void TimesUp()
    {
        lives--;
        UpdateHeartsUI();
    }
    




    public void JumpLeft()
    {
        if (hasJumped || BulletFlying || currentRow >= leftTargets.Length) return;

        Vector3 jumpTarget = leftTargets[currentRow].position + Vector3.up * 0.5f;
        eraserman.JumpTarget(jumpTarget);

        hasJumped = true;
        currentRow++;
        timerON = false;

        FindObjectOfType<CameraMovement>().CameraMove();
        StartCoroutine(JumpAgain());
    }

    

    public void JumpRight()
    {
        if (hasJumped || BulletFlying || currentRow >= rightTargets.Length) return;

        Vector3 jumpTarget = rightTargets[currentRow].position + Vector3.up * 0.5f;
        eraserman.JumpTarget(jumpTarget);

        hasJumped = true;
        currentRow++;
        timerON = false;

        FindObjectOfType<CameraMovement>().CameraMove();
        StartCoroutine(JumpAgain());
    }

    public void PlayerLanded()
    {
        BulletFlying = true;
        enemyshooter.FireBullet();
    }

    public void BulletFinished()
    {
        BulletFlying = false;
        StartTurn();
    }



    private IEnumerator JumpAgain()
    {
        yield return new WaitForSeconds(1f); 
        hasJumped = false;
    }

}
