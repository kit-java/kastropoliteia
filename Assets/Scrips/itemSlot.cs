using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("UI Refs")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private GameObject selectedHighlight;
    [SerializeField] private Image ImageDescription;
    [SerializeField] private TextMeshProUGUI ItemDescriptionNameText;
    [SerializeField] private TextMeshProUGUI ItemDescriptionText;

    [Header("Stacking")]
    [SerializeField] private int maxNumberOfItems = 99;

    public string ItemName { get; private set; }
    public int Quantity { get; private set; }
    public string ItemDescription { get; private set; }
    public Sprite ItemIcon { get; private set; }

    public bool IsEmpty => Quantity <= 0;
    public bool IsFull => Quantity >= maxNumberOfItems;

    private InventoryManager manager;

    private void Awake()
    {
        manager = GetComponentInParent<InventoryManager>();

        iconImage = transform.Find("ItemImage").GetComponent<Image>();
        quantityText = transform.Find("QuantityText").GetComponent<TextMeshProUGUI>();
        selectedHighlight = transform.Find("SelectedPanel").gameObject;
        ImageDescription = GameObject.Find("ImageDescription").GetComponent<Image>();
        ItemDescriptionNameText = GameObject.Find("ItemDescriptionNameText").GetComponent<TextMeshProUGUI>();
        ItemDescriptionText = GameObject.Find("ItemDescriptionText").GetComponent<TextMeshProUGUI>();

        RefreshUI();
        SetSelected(false);
    }

    public int AddItem(string itemName, int quantity, Sprite icon, string description)
    {
        if (quantity <= 0) return 0;

        // Αν είναι άδειο slot, "δέσμευσέ" το για αυτό το είδος
        if (IsEmpty)
        {
            ItemName = itemName;
            ItemDescription = description;
            ItemIcon = icon;

            Debug.Log(icon);
        }
        else if (ItemName != itemName)
        {
            // Διαφορετικό είδος -> τίποτα δεν αλλάζει
            return quantity;
        }

        int spaceLeft = Mathf.Max(0, maxNumberOfItems - Quantity);
        int toAdd = Mathf.Min(spaceLeft, quantity);

        Quantity += toAdd;
        RefreshUI();

        return quantity - toAdd; // leftover
    }

    public void Clear()
    {
        ItemName = null;
        ItemDescription = null;
        ItemIcon = null;
        Quantity = 0;
        RefreshUI();
        SetSelected(false);
    }

    private void RefreshUI()
    {
        if (iconImage != null)
        {
            iconImage.sprite = ItemIcon;
            iconImage.enabled = ItemIcon != null && !IsEmpty;
            if (iconImage != null) iconImage.preserveAspect = true;
        }

        if (quantityText != null)
        {
            quantityText.enabled = !IsEmpty;
            // Κρύψε την ποσότητα όταν είναι 0 ή 1 (αν προτιμάς να φαίνεται πάντα, άλλαξέ το)
            if (IsEmpty) quantityText.text = "";
            else quantityText.text = (Quantity > 1) ? Quantity.ToString() : "";
        }
    }

    public void SetSelected(bool selected)
    {
        if (selectedHighlight != null)
            selectedHighlight.SetActive(selected);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) {
            OnleftRight();
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnleftClick();
        }
    }

    public void OnleftClick()
    {
        if (manager != null)
            manager.DeselectAllSlots();

        // Τoggle επιλογής slot
        bool nowSelected = selectedHighlight == null ? false : !selectedHighlight.activeSelf;
        SetSelected(nowSelected);

        if (nowSelected) {
            ImageDescription.preserveAspect = true;
            ImageDescription.sprite = ItemIcon;
            ItemDescriptionNameText.text = ItemName;
            ItemDescriptionText.text = ItemDescription;
        }
        else
        {
            ClearDescription();
        }
    }

    public void OnleftRight() {
        Clear();
        RefreshUI();
        ClearDescription();
    }

    private void ClearDescription() {
        ItemDescriptionText.text = "";
        ItemDescriptionNameText.text = "";
        ImageDescription.sprite = null;
    }
}
