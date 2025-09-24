using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyItme : MonoBehaviour
{
    [Header("Item Data")]
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;
    [SerializeField] private float itemPrice;
    [TextArea][SerializeField] private string itemDescription;

    [Header("Inventory Ref")]
    [SerializeField] public InventoryManager inventoryManager;

    public Image myImage;
    public TextMeshProUGUI txtPrice;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI myMoney;
    public int quantity = 1;
    public Button buyB;

    private void Awake()
    {
        if (inventoryManager == null)
        {
            // Βρες το InventoryManager με όνομα αντικειμένου ή μπορείς να βάλεις Tag και να το βρίσκεις με FindWithTag
            GameObject go = GameObject.Find("InventoryCanvas");
            if (go != null) inventoryManager = go.GetComponent<InventoryManager>();
        }
        myMoney = FindInactiveByName("MoneyNumber").GetComponent<TextMeshProUGUI>();

        myImage = transform.Find("ItemBackGroud/ItemImage").GetComponent<Image>();
        myImage.sprite = sprite;

        buyB = transform.Find("BuyItem").GetComponent<Button>();
        buyB.onClick.AddListener(BuyAnItem);

        txtPrice = transform.Find("Price").GetComponent<TextMeshProUGUI>();
        txtName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();

        txtPrice.text = itemPrice.ToString();
        txtName.text = itemName;
    }
    public void BuyAnItem() {
        if (inventoryManager == null) {
            Debug.LogError("inventoryManager not found in BuyItem");
        }
        if ((itemDescription == null) && (itemName == null) && (sprite == null))
        {
            Debug.LogError("Item does not have itemDescription, itemName, sprite");
        }

        float myMoneyfloat = float.Parse(myMoney.text);

        if (myMoneyfloat > itemPrice)
        {
            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            myMoney.text = (myMoneyfloat - itemPrice).ToString();
        }
        else {
            Debug.Log("You dont have enough money!!!");
        }
    }

    public static GameObject FindInactiveByName(string objectName)
    {
        return Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(go => go.name == objectName && go.scene.isLoaded);
    }
}
