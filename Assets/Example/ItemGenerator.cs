using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [Header("Item Generator")]
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private int _itemCount;

    public void Clear()
    {
        foreach (Item item in GetComponentsInChildren<Item>())
        {
            DestroyImmediate(item.gameObject);
        }
    }

    public void GenerateItems()
    {
        for (int i = 0; i < _itemCount; i++)
        {
            Instantiate(_itemPrefab, transform).Initialise();
        }
    }
}
