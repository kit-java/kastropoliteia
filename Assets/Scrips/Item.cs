using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Data")]
    [SerializeField] private string itemName;
    [SerializeField] private int quantity = 1;
    [SerializeField] private Sprite sprite;
    [TextArea][SerializeField] private string itemDescription;

    [Header("Inventory Ref")]
    [SerializeField] public InventoryManager inventoryManager;

    private void Awake()
    {
        if (inventoryManager == null)
        {
            // Βρες το InventoryManager με όνομα αντικειμένου ή μπορείς να βάλεις Tag και να το βρίσκεις με FindWithTag
            GameObject go = GameObject.Find("InventoryCanvas");
            if (go != null) inventoryManager = go.GetComponent<InventoryManager>();
        }

        // Βοηθητικό assertion για να μη ξεχνάμε icon
        if (sprite == null)
        {
            Debug.LogWarning($"{name}: Δεν έχει οριστεί sprite στο Item!", this);
        }
    }

    // Αν το pickup είναι TRIGGER (IsTrigger = true)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            TryPickup();
    }

    // Αν το pickup είναι κανονικός collider (όχι trigger)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            TryPickup();
    }

    private void TryPickup()
    {
        if (inventoryManager == null) return;

        int leftOver = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
        if (leftOver <= 0)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("not Destroy");
            quantity = leftOver;
        }
    }
}
