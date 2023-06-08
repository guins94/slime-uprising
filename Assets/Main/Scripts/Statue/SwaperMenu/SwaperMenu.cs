using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwaperMenu : MonoBehaviour
{
    [SerializeField] Item[] itemArray;

    int index = 0;
    
    //Cached References
    public Item[] ItemArray => itemArray;
    public int Index => index;

    
    public void SwapWeaponRigth()
    {
        if (index + 1 >= itemArray.Length)
        {
            index = 0;
        }
        else
        {
            index = index + 1;
        }
    }

    public void SwapWeaponLeft()
    {
        if (index - 1 <= 0)
        {
            index = itemArray.Length;
        }
        else
        {
            index = index - 1;
        }
    }
}
