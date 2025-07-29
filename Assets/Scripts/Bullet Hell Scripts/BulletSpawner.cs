using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletSpawner : MonoBehaviour
{
    private Vector2 N, NE, E, SE, S, SW, W, NW;
    public GameObject BulletPrefab;
    public Transform[] spawnpoints;


    public TMP_Text Timer;
    private float timer;
    private bool timerON = false;
    public bool bluecolor = false;

    public TMP_Text Move;
    public TMP_Text Laugh;
    public TMP_Text Laugh2;
    public TMP_Text Idiot;


    // Start is called before the first frame update
    void Start()
    {
        timerON = true;
        timer = 60f;

        N = Vector2.up;
        NE = new Vector2(1, 1).normalized;
        E = Vector2.right;
        SE = new Vector2(1, -1).normalized;
        S = Vector2.down;
        SW = new Vector2(-1, -1).normalized;
        W = Vector2.left;
        NW = new Vector2(-1, 1).normalized;



        StartCoroutine(Allwaves());



    }
    // Update is called once per frame
    void Update()
    {
        if (timerON)
        {
            timer -= Time.deltaTime;
            TimerUI();

            if (timer <= 0f)
            {
                timerON = false;
                timer = 0f;

            }
        }
    }

    void TimerUI()
    {
        int displayTime = Mathf.Max(0, Mathf.FloorToInt(timer));
        Timer.text = displayTime.ToString();
    }

    void FireBullet(Transform spawnpoint, Vector2 Direction, float startSpeed, float maxSpeed, float delay)
    {
        GameObject bullet = Instantiate(
            BulletPrefab,
            spawnpoint.position,
            Quaternion.identity



            );

        Bullett bulletScript = bullet.GetComponent<Bullett>();


        bulletScript.direction = Direction;
        bulletScript.startspeed = startSpeed;
        bulletScript.maxspeed = maxSpeed;
        bulletScript.delay = delay;

        if (bluecolor)
        {
            SpriteRenderer sp = bullet.GetComponent<SpriteRenderer>();
            sp.color = Color.blue;
        }


    }

    IEnumerator Allwaves()
    {
        yield return Wave1();
        yield return new WaitForSeconds(1f);
        yield return Wave2();
        yield return new WaitForSeconds(0.5f);
        yield return Wave3();
        yield return new WaitForSeconds(0.2f);
        yield return Wave4();
        yield return new WaitForSeconds(1.7f);
        yield return Wave5();
        yield return new WaitForSeconds(1.2f);
        yield return Wave6();
        yield return new WaitForSeconds(2f);
        yield return Wave7();
        yield return new WaitForSeconds(16f);
        Move.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        Move.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Laugh.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Laugh2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Idiot.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Laugh.gameObject.SetActive(false);
        Laugh2.gameObject.SetActive(false);
        Idiot.gameObject.SetActive(false);





    }

    IEnumerator Wave1()
    {
        for (int i = 0; i <= 3; i++)
        {
            FireBullet(spawnpoints[i], Vector2.right, 4f, 4f, 0f);
        }
        for (int i = 10; i <= 13; i++)
        {
            FireBullet(spawnpoints[i], Vector2.left, 4f, 4f, 0f);
        }

        yield return null;


    }

    IEnumerator Wave2()
    {
        for (int i = 27; i <= 37; i++)
        {
            FireBullet(spawnpoints[i], SE, 3f, 3f, 0f);
            yield return new WaitForSeconds(0.3f);
        }

        for (int i = 0; i <= 4; i++)
        {
            FireBullet(spawnpoints[i], E, 2f, 2f, 0f);
            yield return new WaitForSeconds(0.2f);
        }


    }

    IEnumerator Wave3()
    {
        for (int i = 25; i >= 15; i--)
        {
            FireBullet(spawnpoints[i], N, 2.5f, 2.5f, 0f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Wave4()
    {
        for (int i = 4; i <= 6; i++)
        {
            FireBullet(spawnpoints[i], E, 5f, 5f, 0f);

        }

        for (int i = 11; i <= 13; i++)
        {
            FireBullet(spawnpoints[i], W, 5f, 5f, 0f);
        }

        yield return null;
    }

    IEnumerator Wave5()
    {

        bluecolor = true;
        for (int i = 7; i <= 11; i++)
        {
            FireBullet(spawnpoints[i], W, 0.5f, 8f, 1.5f);
        }

        bluecolor = false;

        yield return null;
    }


    IEnumerator Wave6()
    {
        FireBullet(spawnpoints[7], W, 1f, 0.5f, 0f);
        FireBullet(spawnpoints[10], W, 1f, 0.5f, 0f);
        FireBullet(spawnpoints[13], W, 1f, 0.5f, 0f);

        for(int i = 27; i <=29; i++)
        {
            FireBullet(spawnpoints[i], S, 1.8f, 1.8f, 0f);
        }

        for(int i = 5; i <= 6; i++)
        {
            FireBullet(spawnpoints[i], NE, 1.8f, 1.8f, 0f);
        }
        for(int i = 3; i <= 4; i++)
        {
            FireBullet(spawnpoints[i], E, 1.8f, 1.8f, 0f);
        }

        yield return null;

        
    }

    IEnumerator Wave7()
    {

        StartCoroutine(Row1());
       
        StartCoroutine(Row2());
        
        StartCoroutine(Row3());
       
        StartCoroutine(Row4());
       
        StartCoroutine(Row5());
       
        StartCoroutine(Row6());
        
        StartCoroutine(Row7());

        yield return null;

        
    }

    IEnumerator Row1()
    {
        for (int i = 0; i <= 15; i++)
        {
            FireBullet(spawnpoints[33], S, 8f, 8f, 0f);
            yield return new WaitForSeconds(0.2f);
        }

        
        
    }

    IEnumerator Row2()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i <= 15; i++)
        {
            FireBullet(spawnpoints[19], N, 8f, 8f, 0f);
            yield return new WaitForSeconds(0.2f);
        }
    

    }

    IEnumerator Row3()
    {
        yield return new WaitForSeconds(4f);
        for (int i = 0; i <= 15; i++)
        {
            FireBullet(spawnpoints[19], N, 8f, 8f, 0f);
            yield return new WaitForSeconds(0.2f);
        }

    }

    IEnumerator Row4()
    {
        yield return new WaitForSeconds(6f);
        for (int i = 0; i <= 15; i++)
        {
            FireBullet(spawnpoints[31], S, 8f, 8f, 0f);
            yield return new WaitForSeconds(0.2f);
        }
        
    }

    IEnumerator Row5()
    {
        yield return new WaitForSeconds(8f);
        for (int i = 0; i <= 15; i++)
        {
            FireBullet(spawnpoints[17], N, 8f, 8f, 0f);
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    IEnumerator Row6()
    {
        yield return new WaitForSeconds(10f);
        for (int i = 0; i <= 15; i++)
        {
            FireBullet(spawnpoints[29], S, 8f, 8f, 0f);
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    
    IEnumerator Row7()
    {
        yield return new WaitForSeconds(12f);
        for (int i = 0; i <= 15; i++)
        {
            FireBullet(spawnpoints[15], N, 8f, 8f, 0f);
            yield return new WaitForSeconds(0.2f);
        }
    }

    


        




}