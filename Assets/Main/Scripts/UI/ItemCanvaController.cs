using UnityEngine.UI;
using UnityEngine;

public class ItemCanvaController : MonoBehaviour
{
    [SerializeField] Image[] vectorItemImage = null;
    [SerializeField] Image fixedItemImage = null;

    private int itemIndex = 0;

    public void FixedItemImage(Sprite itemImage)
    {
        fixedItemImage.sprite = itemImage;
    }

    public void GetItemImage(Sprite itemImage)
    {
        if (itemIndex < vectorItemImage.Length - 1)
        {
            vectorItemImage[itemIndex].sprite = itemImage;
            itemIndex ++;
        }
    }

}
