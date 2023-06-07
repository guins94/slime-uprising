using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventsManager
{
    public static Action GoldCoinCollected = null;
    public static Action<int> GoldCoinWasted = null;
}
