using System.Collections;

public class ScrollCollectable : Item
{
    public override IEnumerator ItemEffect()
    {
        GameEventsManager.ScrollCollected?.Invoke();
        yield return null;
    }
}