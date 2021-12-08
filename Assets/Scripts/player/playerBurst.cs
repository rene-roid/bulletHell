using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class playerBurst : MonoBehaviour
{
    public static float pointsGiven = 0;
    [Range(0, 1)] public float noPlayerBurst;
    [Range(0, 60)]public float plyr1Burst, plyr2Burst, plyr3Burst;

    // GhostBurst
    public GameObject ghost;

    // SlowmotionBurst
    public static bool isTimeStop = false;
    public float timeStopDuration;
    private float timeStopTime;
    public AudioClip stopSFX;
    public AudioSource audioSource;

    public PostProcessVolume volume;
    private LensDistortion _LensDistortion;
    private ChromaticAberration _ChromaticAberration;

    public ParticleSystem explosion;

    private void Start()
    {
        plyr1Burst = 0;
        plyr2Burst = 0;
        plyr3Burst = 0;

        timeStopTime = 0;

        volume.profile.TryGetSettings(out _LensDistortion);
        volume.profile.TryGetSettings(out _ChromaticAberration);
    }

    private void Update()
    {
        playerValues.plyrBurst1 = plyr1Burst;
        playerValues.plyrBurst2 = plyr2Burst;
        playerValues.plyrBurst3 = plyr3Burst;

        burstController();

        if (Input.GetKeyDown(KeyCode.Q) && playerValues.partyMember == 1 && plyr1Burst == 60)
        {
            ghostBurst();
            plyr1Burst = 0;
        } else if (Input.GetKeyDown(KeyCode.Q) && playerValues.partyMember == 2 && plyr2Burst == 60 && !isTimeStop)
        {
            audioSource.clip = stopSFX;
            audioSource.Play();

            TimeStop();
            plyr2Burst = 0;
        } else if (Input.GetKeyDown(KeyCode.Q) && playerValues.partyMember == 3 && plyr3Burst == 60)
        {
            ScreenNuke();
            plyr3Burst = 0;
        }

        TurnOffTimeStop();

        if (Input.GetKeyDown(KeyCode.P))
        {
            plyr1Burst = 60;
            plyr2Burst = 60;
            plyr3Burst = 60;
        }
    }

    private void burstController()
    {

        // Add points
        if (playerValues.partyMember == 1)
        {
            plyr1Burst += pointsGiven;
            plyr2Burst += pointsGiven * noPlayerBurst;
            plyr3Burst += pointsGiven * noPlayerBurst;
            pointsGiven = 0;
        } else if (playerValues.partyMember == 2)
        {
            plyr1Burst += pointsGiven * noPlayerBurst;
            plyr2Burst += pointsGiven;
            plyr3Burst += pointsGiven * noPlayerBurst;
            pointsGiven = 0;

        } else if (playerValues.partyMember == 3)
        {
            plyr1Burst += pointsGiven * noPlayerBurst;
            plyr2Burst += pointsGiven * noPlayerBurst;
            plyr3Burst += pointsGiven;
            pointsGiven = 0;
        }

        // Don't pass the limits
        if (plyr1Burst > 60) { plyr1Burst = 60; } else if (plyr2Burst > 60) { plyr2Burst = 60; } else if (plyr3Burst > 60) { plyr3Burst = 60; }

    }

    private void ghostBurst() // Need to add timed ghost
    {
        ghost.SetActive(true);
    }

    private void TimeStop()
    {
        isTimeStop = true;
        timeStopTime = Time.unscaledTime + timeStopDuration;
        Time.timeScale = 0;

        PostProcessingEffect();
    }

    private void PostProcessingEffect()
    {
        _LensDistortion.enabled.Override(true);
        _LensDistortion.intensity.Override(-16f);

        _ChromaticAberration.enabled.Override(true);
        _ChromaticAberration.intensity.Override(1f);
    }

    private void TurnOffTimeStop()
    {
        if (Time.unscaledTime > timeStopTime && isTimeStop)
        {
            Time.timeScale = 1f;
            isTimeStop = false;

            _LensDistortion.intensity.Override(0f);
            _ChromaticAberration.intensity.Override(0f);
        }
    }

    private void ScreenNuke()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        explosion.Play();
    }
}
