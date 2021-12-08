using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using System;

public class DiscordController : MonoBehaviour
{
    public enum Status { Menu, Level1, Level2, Level3, Level4, Amogus }
    public Status status;

    public static Discord.Discord discord;
    public ActivityManager activityManager;

    public Discord.Activity activity;

    private long presenceKey = 897413097151692820;
    private bool isDiscord = false;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                if (p.ToString() == "System.Diagnostics.Process (Discord)")
                {
                    isDiscord = true;
                    break;
                }
            }
        } catch
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (isDiscord)
            {
                discord = new Discord.Discord(presenceKey, (System.UInt64)Discord.CreateFlags.Default);
                activityManager = discord.GetActivityManager();

                switch (status)
                {
                    case Status.Menu:
                        InMenu();
                        break;
                    case Status.Level1:
                        Level1();
                        break;
                    case Status.Level2:
                        break;
                    case Status.Level3:
                        break;
                    case Status.Level4:
                        break;
                    case Status.Amogus:
                        break;
                    default:
                        break;
                }
            }
        }
        catch
        {

        }
        try
        {
            if (isDiscord)
            {
                discord.RunCallbacks();
            }
        } catch
        {

        }

    }

    void InMenu()
    {
        if (isDiscord)
        {
            activity.Party.Size.CurrentSize = 0;
            activity.Party.Size.MaxSize = 0;

            activity.State = "In menu";
            activity.Timestamps.Start = 0;

            activity.Assets.SmallImage = "";
            activity.Assets.SmallText = "";

            activity.Assets.LargeImage = "steve";
            activity.Assets.LargeText = "Hello im steve";

            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res == Discord.Result.Ok)
                {
                    print("Updated!");
                }
            });
        }
    }

    void Level1()
    {
        if (isDiscord)
        {
            activity.Party.Size.CurrentSize = 0;
            activity.Party.Size.MaxSize = 0;

            activity.State = "Level 1";
            activity.Timestamps.Start = 0;

            activity.Assets.SmallImage = "Steve";
            activity.Assets.SmallText = "Hi! Im still here";

            activity.Assets.LargeImage = "karen";
            activity.Assets.LargeText = "Hello im steve";

            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res == Discord.Result.Ok)
                {
                    print("Updated!");
                }
            });
        }
    }
}
