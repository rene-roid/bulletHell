using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class amongUsBoss : MonoBehaviour
{
    public float bossHP = 1000;
    private float maxBossHP;

    public GameObject player;

    public GameObject knife;
    public int knifesSpawn = 10;

    private Rigidbody2D rb;

    public static bool isAiming = true;

    public GameObject redWarning, yellowWarning;
    public static bool goRedCannon = false;
    public static bool goYellowCannon = false;

    public Transform[] knifeSpawns;

    public GameObject knifeCircleInvocation;
    public int divisions = 23;
    public static GameObject[] knifes = new GameObject[23];

    public static int votes = 0;
    public Text voteText;

    public GameObject[] ghosts;

    public enum stateBoss { ATTACKING, WAITING, NORMAL, ENRAGED };
    public stateBoss state = stateBoss.WAITING;
    public stateBoss status = stateBoss.NORMAL;

    // Start is called before the first frame update
    void Start()
    {
        rb = knife.GetComponent<Rigidbody2D>();
        votes = 0;

        maxBossHP = bossHP;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(KnifeAttack());
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(CannonAttack());
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(KnifeCircle());
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(KnifeInvocation());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(CannonWave());
        }

        Attacks();

        voteText.text = "Votos: " + votes.ToString() + "/5";

        knifeCircleInvocation.transform.Rotate(Vector3.forward * 50 * Time.deltaTime);


        BossHP();


    }

    private void Attacks()
    {
        if (state == stateBoss.WAITING)
        {
            if (status == stateBoss.NORMAL)
            {
                int attack = Random.Range(0, 5);

                switch (attack)
                {
                    case 0:
                        state = stateBoss.ATTACKING;
                        KnifeAtt();
                        break;
                    case 1:
                        state = stateBoss.ATTACKING;
                        CannonAtt();
                        break;
                    case 2:
                        state = stateBoss.ATTACKING;
                        KnifeCircl();
                        break;
                    case 3:
                        state = stateBoss.ATTACKING;
                        KnifeInvo();
                        break;
                    case 4:
                        state = stateBoss.ATTACKING;
                        CannonWav();
                        break;
                }
            }
        }
    }

    private void KnifeAtt()
    {
        StartCoroutine(KnifeAttack());
    }
    private void CannonAtt()
    {
        StartCoroutine(CannonAttack());
    }
    private void KnifeCircl()
    {
        StartCoroutine(KnifeCircle());
    }
    private void KnifeInvo()
    {
        StartCoroutine(KnifeInvocation());
    }
    private void CannonWav()
    {
        StartCoroutine(CannonWave());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player_bullet")
        {
            bossHP -= playerValues.playerBulletDMG;
            print(bossHP);
        }
    }

    private void BossHP()
    {
        float primerFantasma = maxBossHP * 0.8f;
        float segundoFantasma = maxBossHP * 0.6f;
        float tercerFantasma = maxBossHP * 0.4f;
        float cuartoFantasma = maxBossHP * 0.2f;
        float quintoFantasma = maxBossHP * 0.0f;

        try
        {
            if (primerFantasma >= bossHP) { ghosts[0].SetActive(true); }
        }
        catch { }
        try
        {
            if (segundoFantasma >= bossHP) { ghosts[1].SetActive(true); }
        }
        catch { }
        try
        {
            if (tercerFantasma >= bossHP) { ghosts[2].SetActive(true); }
        }
        catch { }
        try
        {
            if (cuartoFantasma >= bossHP) { ghosts[3].SetActive(true); }
        }
        catch { }
        try
        {
            if (quintoFantasma >= bossHP) { ghosts[4].SetActive(true); }
        }
        catch { }
    }

    IEnumerator KnifeAttack()
    {
        bossKnife.knifeSpeed = 0;
        isAiming = true;

        for (int i = 0; i < knifesSpawn; i++)
        {
            GameObject newKnife = Instantiate(knife, new Vector2(Random.Range(-5.3f, 5.3f), Random.Range(2.19f, 3.93f)), Quaternion.identity);
            newKnife.GetComponent<bossKnife>().backWardKnife = true;

            yield return new WaitForSeconds(0.1f);
        }

        isAiming = false;
        bossKnife.knifeSpeed = 10;

        yield return new WaitForSeconds(1f);
        state = stateBoss.WAITING;
    }

    IEnumerator CannonAttack()
    {
        redWarning.SetActive(true);
        yield return new WaitForSeconds(1f);

        redWarning.SetActive(false);
        goRedCannon = true;
        yield return new WaitForSeconds(1f);

        yellowWarning.SetActive(true);
        yield return new WaitForSeconds(1f);

        yellowWarning.SetActive(false);
        goYellowCannon = true;
        yield return new WaitForSeconds(2f);
        goYellowCannon = false;
        goRedCannon = false;

        yield return new WaitForSeconds(1f);
        state = stateBoss.WAITING;
    }

    IEnumerator KnifeCircle()
    {
        int count = 23;
        bossKnife.knifeSpeed = 0;
        isAiming = true;

        for (int i = 0; i < count; i++)
        {
            GameObject newKnife = Instantiate(knife, player.transform.position + new Vector3(Mathf.Sin(((float)i / count) * 2 * Mathf.PI), Mathf.Cos(((float)i / count) * 2 * Mathf.PI)) * 3, Quaternion.identity);
            newKnife.GetComponent<bossKnife>().backWardKnife = false;
            // newKnife.transform.Rotate(Vector3.forward * 50 * Time.deltaTime);

            yield return new WaitForSeconds(0.1f);
        }

        isAiming = false;
        bossKnife.knifeSpeed = 10;

        yield return new WaitForSeconds(1f);
        state = stateBoss.WAITING;
    }

    IEnumerator KnifeInvocation()
    {
        bossKnife.knifeSpeed = 0;
        isAiming = true;

        for (int i = 0; i < divisions; i++)
        {

            GameObject newKnife = Instantiate(knife, transform.position + new Vector3(Mathf.Sin(((float)i/divisions) * 2 * Mathf.PI), Mathf.Cos(((float)i / divisions) * 2 * Mathf.PI)) * 2, Quaternion.identity);
            knifes[i] = newKnife;

            yield return new WaitForSeconds(0.1f);
        }

        isAiming = false;
        bossKnife.knifeSpeed = 10;

        yield return new WaitForSeconds(1f);
        state = stateBoss.WAITING;
    }

    public GameObject[] CannonsWave = new GameObject[13];
    public GameObject[] AlertWave = new GameObject[13];
    IEnumerator CannonWave()
    {
        AlertWave[0].SetActive(true);
        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < 13; i++)
        {
            CannonsWave[i].GetComponent<bossCannonWave>().goCannon = true;
            AlertWave[i].SetActive(false);
            if (i < 12)
            {
                AlertWave[i + 1].SetActive(true);
            }


            yield return new WaitForSeconds(0.25f);
        }
        AlertWave[12].SetActive(false);

        yield return new WaitForSeconds(1f);
        state = stateBoss.WAITING;
    }

}
