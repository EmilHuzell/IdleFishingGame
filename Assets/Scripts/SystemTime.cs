using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemTime : MonoBehaviour
{
    static System.DateTime startTime;
    static System.DateTime endTime;
    public static System.TimeSpan difference;

    static double DifferenceInSeconds { get => difference.TotalSeconds; }

    void Start()
    {
        //Store the current time when it starts
        startTime = System.DateTime.Now;

        //Grab the old time from the player prefs as a long
        long temp;
        if (PlayerPrefs.HasKey("savedTime"))
        {
            //Convert the old time from binary to a DataTime variable
            temp = System.Convert.ToInt64(PlayerPrefs.GetString("savedTime"));
            endTime = System.DateTime.FromBinary(temp);
        }
        else
        {
            endTime = System.DateTime.Now;
        }
        print("Loading time from prefs: " + endTime);

        //Use the Subtract method and store the result as a timespan variable
        difference = startTime.Subtract(endTime);
        print("Difference: " + difference);
    }

    void OnApplicationQuit()
    {
        //Save the current system time as a string in the player prefs class
        PlayerPrefs.SetString("savedTime", System.DateTime.Now.ToBinary().ToString());

        Debug.Log("Saving time to prefs: " + System.DateTime.Now);
    }
}