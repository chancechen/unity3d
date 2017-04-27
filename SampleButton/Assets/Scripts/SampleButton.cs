using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour {

    public Button button;
    public Text itemName;
    public Text itemPrict;
    public Image itemIcon;

    private Item item;
    private ShopScrollList scrollList;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(OnClick);
    }

    public void Setup(Item currentItem, ShopScrollList list) {

        item = currentItem;
        scrollList = list;

        itemName.text = item.itemName;
        itemPrict.text = item.price.ToString();
        itemIcon.sprite = item.icon;
    }

    public void OnClick()  {

        scrollList.TryTransferItemToOtherShop(item);
    }
}
