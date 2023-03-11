using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUIMessager : MonoBehaviour
{
    [SerializeField] DamageMessage messagePrefab = null;
    public void ShowDamageUI(string damageText, Vector2 location)
    {
        DamageMessage newMessage = Instantiate(messagePrefab, location, Quaternion.identity);
        newMessage.ChangeText(damageText);
    }
}
