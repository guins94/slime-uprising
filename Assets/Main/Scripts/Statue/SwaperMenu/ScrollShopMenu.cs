using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollShopMenu : SwaperMenu, ISaveData
{
    [Header("Scroll Shop References")]
    [SerializeField] Canvas ScrollCanva;
    [SerializeField] Image HolderSprite;
    [SerializeField] Button rigthButton = null;
    [SerializeField] Button leftButton = null;
    [SerializeField] Button purchaseButton = null;

    [Header("Text Price Reference")]
    [SerializeField] Text ScrollPrice;
    [SerializeField] Image ItemPurchased;
    [SerializeField] Image ItemLookedImage;

    //Cached Components
    int price = 5;
    private bool[] ScrollShopIndexVector = new bool[] {false, false, false, false};

    private void Start()
    {
        rigthButton.onClick.AddListener(SwapWeaponRigth);
        leftButton.onClick.AddListener(SwapWeaponLeft);
        purchaseButton.onClick.AddListener(BuyWithScroll);
    }

    // OnDestroy is called when the script is being destroyed.
    void OnDestroy()
    {
        rigthButton.onClick.RemoveListener(SwapWeaponRigth);
        leftButton.onClick.RemoveListener(SwapWeaponLeft);
        purchaseButton.onClick.AddListener(BuyWithScroll);
    } 

    private void Update()
    {
        HolderSprite.sprite = ItemArray[Index].ItemSpriteRenderer.sprite;
        if (ScrollShopIndexVector[Index] == true)
        {
            ScrollPrice.text = "0";
            ItemPurchased.enabled = true;
        }
        else
        {
            ScrollPrice.text = "" + price;
            ItemPurchased.enabled = false;
        }
    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Debug.Log("Button Pressed");
        ScrollCanva.enabled = true;
    }

    void BuyWithScroll()
    {
        int scrollToWaste = price;
        if (GameManager.GameManagerInstance.scroll < scrollToWaste) return;

        ScrollPrice.text = "0";
        ItemPurchased.enabled = true;
        GameEventsManager.ScrollWasted(scrollToWaste);
        ScrollShopIndexVector[Index] = true;
    }

    private void UpdateShopIndex()
    {
        for (int i = 0; i >= ScrollShopIndexVector.Length - 1; i++)
        {
            if (ScrollShopIndexVector[i] == true)
            {

            }
        }
    }

    // ISaveManager needed functions
    public void LoadData(GameData data)
    {
        this.ScrollShopIndexVector = data.ScrollShopIndexVector;
        //UpdateShopIndex();
    }

    public void SaveData(ref GameData data)
    {
        data.ScrollShopIndexVector = this.ScrollShopIndexVector;
    }
}
