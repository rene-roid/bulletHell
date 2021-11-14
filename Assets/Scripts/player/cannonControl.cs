using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonControl : MonoBehaviour
{
    private float fireRate;
    public static float fireRateShip;
    private float timepassed;
    public GameObject bullet;

    public GameObject fireEffect;

    // Ammo values
    public int amo1;
    public int amo2;
    public int amo3;

    // Reloading values
    private bool isReloading1 = false;
    private bool isReloading2 = false;
    private bool isReloading3 = false;

    // Start is called before the first frame update
    void Start()
    {
        timepassed = Time.time;
        fireRate = fireRateShip;

        amo1 = playerValues.maxAmmo1;
        amo2 = playerValues.maxAmmo2;
        amo3 = playerValues.maxAmmo3;
    }

    // Update is called once per frame
    void Update()
    {
        // Update ship firerate
        fireRate = fireRateShip;

        // Firerate shoot
        if (Input.GetKey(KeyCode.Space) && Time.time > timepassed)
        {
            if (playerValues.partyMember == 1 && amo1 > 0 && !isReloading1)
            {
                GameObject bulletCopy = Instantiate(bullet, transform.position, Quaternion.identity);
                timepassed = Time.time + fireRate;
                amo1--;
            }
            else if (playerValues.partyMember == 2 && amo2 > 0 && !isReloading2)
            {
                GameObject bulletCopy = Instantiate(bullet, transform.position, Quaternion.identity);
                timepassed = Time.time + fireRate;
                amo2--;
            }
            else if (playerValues.partyMember == 3 && amo3 > 0 && !isReloading3)
            {
                GameObject bulletCopy = Instantiate(bullet, transform.position, Quaternion.identity);
                timepassed = Time.time + fireRate;
                amo3--;
            }
        }

        StartCoroutine(Reloading());
        StartCoroutine(autoReload());

        // Fire effect when shooting
        if (timepassed - fireRate + 0.05f > Time.time)
        {
            fireEffect.SetActive(true);
        } else
        {
            fireEffect.SetActive(false);
        }

    }

    IEnumerator Reloading()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (playerValues.partyMember == 1 && !isReloading1)
            {
                isReloading1 = true;
                yield return new WaitForSeconds(2);
                amo1 = playerValues.maxAmmo1;
                yield return isReloading1 = false;
            }
            else if (playerValues.partyMember == 2 && !isReloading2)
            {
                isReloading2 = true;
                yield return new WaitForSeconds(2);
                amo2 = playerValues.maxAmmo2;
                yield return isReloading2 = false;
            }
            else if (playerValues.partyMember == 3 && !isReloading3)
            {
                isReloading3 = true;
                yield return new WaitForSeconds(2);
                amo3 = playerValues.maxAmmo3;
                yield return isReloading3 = false;

            }
        }

        yield return null;
    }

    IEnumerator autoReload()
    {
        if (playerValues.partyMember == 1 && amo1 == 0)
        {
            isReloading1 = true;
            yield return new WaitForSeconds(2);
            amo1 = playerValues.maxAmmo1;
            yield return isReloading1 = false;
        }
        else if (playerValues.partyMember == 2 && amo2 == 0)
        {
            isReloading2 = true;
            yield return new WaitForSeconds(2);
            amo2 = playerValues.maxAmmo2;
            yield return isReloading2 = false;
        }
        else if (playerValues.partyMember == 3 && amo3 == 0)
        {
            isReloading3 = true;
            yield return new WaitForSeconds(2);
            amo3 = playerValues.maxAmmo3;
            yield return isReloading3 = false;
        }
    }
}
