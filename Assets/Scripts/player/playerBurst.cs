using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBurst : MonoBehaviour
{
    [SerializeField]
    public static float pointsGiven = 0;
    [Range(0, 1)] public float noPlayerBurst;
    [Range(0, 60)]public float plyr1Burst, plyr2Burst, plyr3Burst;

    private void Start()
    {
        plyr1Burst = 0;
        plyr2Burst = 0;
        plyr3Burst = 0;
    }

    private void Update()
    {
        burstController();
    }

    private void burstController()
    {
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
    }

    private void ghostBurst()
    {

    }
}
