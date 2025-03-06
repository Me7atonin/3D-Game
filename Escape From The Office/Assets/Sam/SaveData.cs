using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    MonoBehaviour m_Instance;
    public float playerX;
    public float playerY;
    public float playerZ;
    public List<string> inventoryItems;
    public bool hasKey;
    public bool hasKeyCard;
    public List<string> destroyedDoors;
}
