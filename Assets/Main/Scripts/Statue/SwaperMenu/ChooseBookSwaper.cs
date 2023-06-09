using UnityEngine;
using UnityEngine.UI;

public class ChooseBookSwaper : SwaperMenu
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
        resumeButton.onClick.AddListener(ResumeGame);
    }

    // OnDestroy is called when the script is being destroyed.
    void OnDestroy()
    {
        rigthButton.onClick.RemoveListener(SwapWeaponRigth);
        leftButton.onClick.RemoveListener(SwapWeaponLeft);
        resumeButton.onClick.RemoveListener(ResumeGame);
    } 

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        WeaponsCanva.enabled = false;
        //if (GameManager.GameManagerInstance != null) GameManager.GameManagerInstance.Player.LevelUp
        if (ItemArray.Length - 1 >= Index) StartCoroutine(ItemArray[Index].ItemEffect());
    }

    private void Update()
    {
        HolderSprite.sprite = ItemArray[Index].ItemSpriteRenderer.sprite;
    }

    private void ChangeWeapon()
    {
        
    }
}
