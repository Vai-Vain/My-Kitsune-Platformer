using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics //: MonoBehaviour
{
    public int numCritter;
    public int wisdom;
    public int time;

    public void Reset()
    {
        numCritter = 0;
        wisdom = 0;
        time = 0;
    }
}