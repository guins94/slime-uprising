using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponsMenu : SwaperMenu
{
    [Header("Weapons Menu Pop Up References")]
    [SerializeField] Canvas WeaponsCanva;
    [SerializeField] Button rigthButton = null;
    [SerializeField] Button leftButton = null;
    [SerializeField] Button resumeButton = null;
    [SerializeField] Image HolderSprite;

    private void Start()
    {
        rigthButton.onClick.AddListener(SwapWeaponRigth);
        leftButton.onClick.AddListener(SwapWeaponLeft);
    }

    // OnDestroy is called when the script is being destroyed.
    void OnDestroy()
    {
        rigthButton.onClick.RemoveListener(SwapWeaponRigth);
        leftButton.onClick.RemoveListener(SwapWeaponLeft);
    } 

    private void Update()
    {
        HolderSprite.sprite = ItemArray[Index].ItemSpriteRenderer.sprite;
    }

    private void ChangeWeapon()
    {
        
    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Debug.Log("Button Pressed");
        WeaponsCanva.enabled = true;
    }
}
