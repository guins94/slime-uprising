using System;

public static class GameEventsManager
{
    public static Action GoldCoinCollected = null;
    public static Action<int> GoldCoinWasted = null;
    public static Action ScrollCollected = null;
    public static Action<int> ScrollWasted = null;

    public static Action EnemyDefeated = null;
}
