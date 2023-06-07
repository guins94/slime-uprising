using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainShopStatue : MonoBehaviour, ISaveData
{
    [Header("Canva References")]
    [SerializeField] Canvas MainsShopCanva = null;

    [Header("Button References")]
    [SerializeField] Button armorButton = null;
    [SerializeField] Button healthButton = null;
    [SerializeField] Button attackButton = null;
    [SerializeField] Button magicButton = null;

    [Header("Text References")]
    [SerializeField] Text armorText = null;
    [SerializeField] Text healthText = null;
    [SerializeField] Text attackText = null;
    [SerializeField] Text magicText = null;

    [Header("Upgrade Text References")]
    [SerializeField] Text armorUpgradeText = null;
    [SerializeField] Text healthUpgradeText = null;
    [SerializeField] Text attackUpgradeText = null;
    [SerializeField] Text magicUpgradeText = null;

    [Header("Prices References")]
    [SerializeField] int[] prices = new int[] {30, 40, 50, 60, 70, 80, 90, 100, 110, 120};

    //Cached Components
    private int[] MainShopIndexVector = new int[] {0, 0, 0, 0};

    //Cached int reference
    int goldIndex = 0;

    void Start()
    {
        // Load game index
        // TO DO
        // Listener for the button
        armorButton.onClick.AddListener(BuyArmor);
        healthButton.onClick.AddListener(BuyArmor);
        attackButton.onClick.AddListener(BuyArmor);
        magicButton.onClick.AddListener(BuyArmor);
        
    }

    void OnDestroy()
    {
        armorButton.onClick.RemoveListener(BuyArmor);
        healthButton.onClick.RemoveListener(BuyArmor);
        attackButton.onClick.RemoveListener(BuyArmor);
        magicButton.onClick.RemoveListener(BuyArmor);
    }

    void BuyArmor()
    {
        
        int goldToWaste = prices[goldIndex];
        if (GameManager.GameManagerInstance.gold < goldToWaste) return;
        if (goldIndex < prices.Length - 1)
        {
            goldIndex++;
            armorText.text = "" + prices[goldIndex];
            armorUpgradeText.text = "" + goldIndex;
            GameEventsManager.GoldCoinWasted(goldToWaste);
            MainShopIndexVector[0] = goldIndex;
        }
    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Debug.Log("Button Pressed");
        MainsShopCanva.enabled = true;
    }

    private void UpdateShopIndex()
    {
        goldIndex = this.MainShopIndexVector[0];
        armorText.text = "" + prices[goldIndex];
        armorUpgradeText.text = "" + goldIndex;
    }

    // ISaveManager needed functions
    public void LoadData(GameData data)
    {
        this.MainShopIndexVector = data.mainShopIndexVector;
        UpdateShopIndex();
    }

    public void SaveData(ref GameData data)
    {
        data.mainShopIndexVector = this.MainShopIndexVector;
    }
}
