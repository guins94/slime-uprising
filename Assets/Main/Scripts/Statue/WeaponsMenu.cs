using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponsMenu : MonoBehaviour
{
    [Header("Weapons Menu Pop Up References")]
    [SerializeField] Canvas WeaponsCanva;

    [SerializeField] Button rigthButton = null;
    [SerializeField] Button leftButton = null;
    [SerializeField] Button resumeButton = null;
    [SerializeField] Image HolderSprite;
    [SerializeField] Item[] ItemArray;

    int index = 0;

    private void Start()
    {
        rigthButton.onClick.AddListener(SwapWeaponRigth);
        leftButton.onClick.AddListener(SwapWeaponLeft);
        resumeButton.onClick.AddListener(SwapWeaponRigth);
    }

    // OnDestroy is called when the script is being destroyed.
    void OnDestroy()
    {
        rigthButton.onClick.RemoveListener(SwapWeaponRigth);
        leftButton.onClick.RemoveListener(SwapWeaponLeft);
        resumeButton.onClick.RemoveListener(ChangeWeapon);
    } 

    private void Update()
    {
        HolderSprite.sprite = ItemArray[index].ItemSpriteRenderer.sprite;
    }

    private void ChangeWeapon()
    {
        
    }

    private void SwapWeaponRigth()
    {
        if (index + 1 >= ItemArray.Length)
        {
            index = 0;
        }
        else
        {
            index = index + 1;
        }
    }

    private void SwapWeaponLeft()
    {
        if (index - 1 <= 0)
        {
            index = ItemArray.Length;
        }
        else
        {
            index = index - 1;
        }
    }
        
    

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Debug.Log("Button Pressed");
        WeaponsCanva.enabled = true;
    }
}
