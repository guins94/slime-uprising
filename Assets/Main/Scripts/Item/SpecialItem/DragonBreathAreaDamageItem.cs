using System.Collections;

public class DragonBreathAreaDamageItem : Item
{
    public override IEnumerator ItemEffect()
    {
        DragonBreathDamageArea playerDamageArea = FindObjectOfType<DragonBreathDamageArea>();
        if (playerDamageArea != null) playerDamageArea.ActivateDamageArea(); 
        yield return null;
    }
}
