using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amongUsBoss : MonoBehaviour
{
    public GameObject player;

    public GameObject knife;
    public int knifesSpawn = 10;

    private Rigidbody2D rb;

    public static bool isAiming = true;

    public GameObject redWarning, yellowWarning;
    public static bool goRedCannon = false;
    public static bool goYellowCannon = false;

    public Transform[] knifeSpawns;

    public Transform[] knifeInvocation;
    public GameObject knifeCircleInvocation;

    // Start is called before the first frame update
    void Start()
    {
        rb = knife.GetComponent<Rigidbody2D>();
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

        knifeCircleInvocation.transform.Rotate(Vector3.forward * 50 * Time.deltaTime);

    }

    IEnumerator KnifeAttack()
    {
        bossKnife.knifeSpeed = 0;
        isAiming = true;

        for (int i = 0; i < knifesSpawn; i++)
        {
            GameObject newKnife = Instantiate(knife, new Vector2(Random.Range(-5.3f, 5.3f), Random.Range(2.19f, 3.93f)), Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
        }

        isAiming = false;
        bossKnife.knifeSpeed = 10;
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

        print("He acabado xd");
        yield return null;
    }

    IEnumerator KnifeCircle()
    {
        bossKnife.knifeSpeed = 0;
        isAiming = true;

        for (int i = 0; i < knifeSpawns.Length - 1; i++)
        {
            GameObject newKnife = Instantiate(knife, knifeSpawns[i].position, Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
        }

        isAiming = false;
        bossKnife.knifeSpeed = 10;
    }

    IEnumerator KnifeInvocation()
    {
        bossKnife.knifeSpeed = 0;
        isAiming = true;

        for (int i = 0; i < knifeInvocation.Length -1; i++)
        {
            GameObject newKnife = Instantiate(knife, knifeInvocation[i].position, Quaternion.identity);

            newKnife.transform.Rotate(Vector3.forward * 5 * Time.deltaTime);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
