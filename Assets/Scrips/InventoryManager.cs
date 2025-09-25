using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject inventoryMenu;

    [Header("ItemSlot")]
    [SerializeField] public ItemSlot[] itemSlots;

    public ItemSO[] itemSos;

    private bool menuActivated;
    public TextMeshProUGUI money;

    private void Update()
    {
        // Άνοιγμα κλείσιμο inventory με το Ι
        if (Input.GetKeyDown(KeyCode.I) && inventoryMenu != null)
        {
            menuActivated = !menuActivated;
            inventoryMenu.SetActive(menuActivated);

            if (menuActivated)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    public int AddItem(string itemName, int quantity, Sprite icon, string description)
    {
        if (quantity <= 0) return 0;

        // 1) Απόπειρα stack σε ίδια είδη
        for (int i = 0; i < itemSlots.Length; i++)
        {
            var s = itemSlots[i];
            if (!s.IsEmpty && !s.IsFull && s.ItemName == itemName)
            {
                quantity = s.AddItem(itemName, quantity, icon, description);
                if (quantity == 0) return 0;
            }
        }

        // 2) Γέμισμα άδειων slots
        for (int i = 0; i < itemSlots.Length; i++)
        {
            var s = itemSlots[i];
            if (s.IsEmpty)
            {
                quantity = s.AddItem(itemName, quantity, icon, description);
                if (quantity == 0) return 0;
            }
        }

        // Δεν χωράει άλλο
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].SetSelected(false);
        }
    }
}
