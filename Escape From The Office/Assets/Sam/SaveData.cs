using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public float playerX;
    public float playerY;
    public float playerZ;
    public List<string> inventoryItems;
    public bool hasKey;
    public bool hasKeyCard;
    public List<string> destroyedDoors;
}
