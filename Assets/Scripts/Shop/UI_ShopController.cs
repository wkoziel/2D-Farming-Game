using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UI_ShopController : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    [SerializeField] private MoneyController money;
    public Button btn;
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] GameObject inventoryPanel;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
    }

    private void Start()
    {
        CreateItemButton(Resources.Load<Sprite>("starter_hoe"), "Hoe", 30, 0, "Hoe");        //to jest ten sam obiekt, który jest domyślnie utworzony jako shopItemTemplate
        CreateItemButton(Resources.Load<Sprite>("starter_shovel"), "Shovel", 30, 1, "Shovel");
        CreateItemButton(Resources.Load<Sprite>("WateringCan"), "WateringCan", 50, 2, "Watering Can");
        //CreateItemButton(Resources.Load<Sprite>("backpack"), "Backpack", 100, 5);

        Dictionary<string, Sprite> plantsDictionary = CreateSeedsFromSprite();
        CreateItemButton(plantsDictionary["Seed3"], "Seed3", 100, 3, "50 red seeds");
        CreateItemButton(plantsDictionary["Seeds1"], "Seeds1", 100, 4, "50 yellow seeds");

        // to nie dziala ponizej na razie:
        //CreateItemButton(plantsDictionary["Corn_0"], "Corn_0", 100, 3, "4 corn seeds");
        //CreateItemButton(plantsDictionary["Parsley_0"], "Parsley_0", 100, 4, "3 parsley seeds");

        gameObject.SetActive(false);
        Hide();
    }

    private Dictionary<string, Sprite> CreateSeedsFromSprite()
    {
        Dictionary<string, Sprite> plantsDictionary = new Dictionary<string, Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Plants");

        foreach (Sprite sprite in sprites)
        {
            plantsDictionary.Add(sprite.name, sprite);
        }

        return plantsDictionary;

    }

    private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int positionIndex, string displayedName)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, 200 + (-shopItemHeight * positionIndex));
        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(displayedName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemIcon").GetComponent<Image>().sprite = itemSprite;

        Item newItem = ScriptableObject.CreateInstance<Item>();

        foreach (ItemSlot itemSlot in GameManager.instance.allItemsContainer.slots)
        {
            if (itemSlot.item.Name == itemName)
            {
                newItem = itemSlot.item;
            }
        }

        btn = shopItemTransform.GetComponent<Button>();
        btn.onClick.AddListener(delegate { TaskWithParameters(itemCost, newItem); });
    }

    void TaskWithParameters(long itemCost, Item item)
    {
        money.substractMoney(itemCost);
        //Debug.Log(itemCost);

        if (money.canBuyItems(itemCost))
        {
            // w tym miejscu trzeba bedzie zrobic if dla kazdego z rodzajow nasiona
            if (item.Name.Contains("Seed"))
            {
                GameManager.instance.inventoryContainer.Add(item, 50);
            }
            else
            {
                GameManager.instance.inventoryContainer.Add(item);
            }
        }
        

        toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        toolbarPanel.SetActive(true);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        inventoryPanel.SetActive(false);
        toolbarPanel.SetActive(true);
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    //dodać obsługę kliknięcia i zakup przedmiotu
}
