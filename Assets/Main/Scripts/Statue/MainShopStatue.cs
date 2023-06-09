using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainShopStatue : MonoBehaviour, ISaveData
{
    [Header("Canva References")]
    [SerializeField] Canvas MainsShopCanva = null;

    [Header("Button References")]
    [SerializeField] Button armorButton = null;
    [SerializeField] Button magicButton = null;
    [SerializeField] Button healthButton = null;
    [SerializeField] Button damageButton = null;

    [Header("Text References")]
    [SerializeField] Text armorText = null;
    [SerializeField] Text magicText = null;
    [SerializeField] Text healthText = null;
    [SerializeField] Text damageText = null;

    [Header("Upgrade Text References")]
    [SerializeField] Text armorUpgradeText = null;
    [SerializeField] Text magicUpgradeText = null;
    [SerializeField] Text healthUpgradeText = null;
    [SerializeField] Text damageUpgradeText = null;

    [Header("Prices References")]
    [SerializeField] int[] prices = new int[] {30, 40, 50, 60, 70, 80, 90, 100, 110, 120};

    //Cached Components
    private int[] MainShopIndexVector = new int[] {0, 0, 0, 0};

    //Cached int reference
    int goldArmorIndex = 0;
    int goldMagicIndex = 0;
    int goldHealthIndex = 0;
    int goldDamageIndex = 0;

    void Start()
    {
        // Load game index
        // TO DO
        // Listener for the button
        armorButton.onClick.AddListener(BuyArmor);
        magicButton.onClick.AddListener(BuyMagicArmor);
        healthButton.onClick.AddListener(BuyHealth);
        damageButton.onClick.AddListener(BuyDamage);
    }

    void OnDestroy()
    {
        armorButton.onClick.RemoveListener(BuyArmor);
        magicButton.onClick.RemoveListener(BuyMagicArmor);
        healthButton.onClick.RemoveListener(BuyHealth);
        damageButton.onClick.RemoveListener(BuyDamage);
    }

    void BuyArmor()
    {
        int goldToWaste = prices[goldArmorIndex];
        if (GameManager.GameManagerInstance.gold < goldToWaste) return;
        if (goldArmorIndex < prices.Length - 1)
        {
            goldArmorIndex++;
            armorText.text = "" + prices[goldArmorIndex];
            armorUpgradeText.text = "" + goldArmorIndex;
            GameEventsManager.GoldCoinWasted(goldToWaste);
            MainShopIndexVector[0] = goldArmorIndex;
        }
    }

    void BuyMagicArmor()
    {
        int goldToWaste = prices[goldMagicIndex];
        if (GameManager.GameManagerInstance.gold < goldToWaste) return;
        if (goldMagicIndex < prices.Length - 1)
        {
            goldMagicIndex++;
            magicText.text = "" + prices[goldMagicIndex];
            magicUpgradeText.text = "" + goldMagicIndex;
            GameEventsManager.GoldCoinWasted(goldToWaste);
            MainShopIndexVector[1] = goldMagicIndex;
        }
    }

    void BuyHealth()
    {
        int goldToWaste = prices[goldHealthIndex];
        if (GameManager.GameManagerInstance.gold < goldToWaste) return;
        if (goldHealthIndex < prices.Length - 1)
        {
            goldHealthIndex++;
            healthText.text = "" + prices[goldHealthIndex];
            healthUpgradeText.text = "" + goldHealthIndex;
            GameEventsManager.GoldCoinWasted(goldToWaste);
            MainShopIndexVector[2] = goldHealthIndex;
        }
    }

    void BuyDamage()
    {
        int goldToWaste = prices[goldDamageIndex];
        if (GameManager.GameManagerInstance.gold < goldToWaste) return;
        if (goldDamageIndex < prices.Length - 1)
        {
            goldDamageIndex++;
            damageText.text = "" + prices[goldDamageIndex];
            damageUpgradeText.text = "" + goldDamageIndex;
            GameEventsManager.GoldCoinWasted(goldToWaste);
            MainShopIndexVector[3] = goldDamageIndex;
        }
    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        MainsShopCanva.enabled = true;
    }

    private void UpdateShopIndex()
    {
        goldArmorIndex = this.MainShopIndexVector[0];
        armorText.text = "" + prices[goldArmorIndex];
        armorUpgradeText.text = "" + goldArmorIndex;

        goldMagicIndex = this.MainShopIndexVector[1];
        magicText.text = "" + prices[goldMagicIndex];
        magicUpgradeText.text = "" + goldMagicIndex;

        goldHealthIndex = this.MainShopIndexVector[2];
        healthText.text = "" + prices[goldHealthIndex];
        healthUpgradeText.text = "" + goldHealthIndex;

        goldDamageIndex = this.MainShopIndexVector[3];
        damageText.text = "" + prices[goldDamageIndex];
        damageUpgradeText.text = "" + goldDamageIndex;
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
