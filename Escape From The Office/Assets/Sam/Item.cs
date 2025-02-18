using UnityEngine;

public enum ItemType { Keycard, Key }

public class Item : MonoBehaviour
{
    public ItemType itemType;  
    public string itemName;    
    public Sprite itemIcon;    

    
}
