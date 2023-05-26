using System.Collections;

public class AreaDamageItem : Item
{
    public override IEnumerator ItemEffect()
    {
        SmudgeDamageArea playerDamageArea = FindObjectOfType<SmudgeDamageArea>();
        if (playerDamageArea != null) playerDamageArea.ActivateDamageArea(); 
        yield return null;
    }
}
