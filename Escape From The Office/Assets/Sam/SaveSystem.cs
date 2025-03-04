using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    string password = "1234567890"; // For encryption (optional)
    CharacterController characterController;
    private InventoryUIManager inventoryUIManager;
    private DoorInteraction[] doors;

    // Save path
    string savePath;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inventoryUIManager = FindObjectOfType<InventoryUIManager>();  // Get InventoryUIManager
        doors = FindObjectsOfType<DoorInteraction>();  // Get all the doors

        savePath = Application.persistentDataPath + "/" + gameObject.name + "_checkpoint.txt";  // Save location
    }

    // Save method
    public void Save()
    {
        SaveData saveData = new SaveData();

        // Save the player's position
        saveData.playerX = transform.position.x;
        saveData.playerY = transform.position.y;
        saveData.playerZ = transform.position.z;

        // Save inventory
        saveData.inventoryItems = new List<string>();
        if (inventoryUIManager.HasKey()) saveData.inventoryItems.Add("Key");
        if (inventoryUIManager.HasKeyCard()) saveData.inventoryItems.Add("KeyCard");

        // Save destroyed doors
        saveData.destroyedDoors = new List<string>();
        foreach (var door in doors)
        {
            if (door == null) continue;  // Safety check in case doors are removed
            if (door.requiresKey || door.requiresKeyCard)  // If the door requires a key or keycard
            {
                saveData.destroyedDoors.Add(door.gameObject.name);
            }
        }

        // Save whether the player has a key and keycard
        saveData.hasKey = inventoryUIManager.HasKey();
        saveData.hasKeyCard = inventoryUIManager.HasKeyCard();

        // Convert to JSON
        string jsonData = JsonUtility.ToJson(saveData);

        // Encrypt the data before saving (optional)
        jsonData = EncryptDecryptData(jsonData);  // Optional encryption

        // Save to file
        File.WriteAllText(savePath, jsonData);
        Debug.Log("Game Saved.");
    }

    // Load method
    public void Load()
    {
        if (File.Exists(savePath))
        {
            // Read the saved file
            string jsonData = File.ReadAllText(savePath);

            // Decrypt the data (optional)
            jsonData = EncryptDecryptData(jsonData);  // Optional decryption

            // Deserialize the data into SaveData
            SaveData loadedData = JsonUtility.FromJson<SaveData>(jsonData);

            // Load player position
            transform.position = new Vector3(loadedData.playerX, loadedData.playerY, loadedData.playerZ);

            // Load inventory items
            foreach (var item in loadedData.inventoryItems)
            {
                if (item == "Key") inventoryUIManager.AddItem("Key");
                else if (item == "KeyCard") inventoryUIManager.AddItem("KeyCard");
            }

            // Load destroyed doors
            foreach (var doorName in loadedData.destroyedDoors)
            {
                DoorInteraction door = FindDoorByName(doorName);
                if (door != null)
                {
                    door.MarkAsInteracted();  // Mark the door as interacted (open, unlock, etc.)
                }
            }

            // Load key and keycard status
            if (loadedData.hasKey) inventoryUIManager.AddItem("Key");
            if (loadedData.hasKeyCard) inventoryUIManager.AddItem("KeyCard");

            Debug.Log("Game Loaded.");
        }
        else
        {
            Debug.LogError("No save data found.");
        }
    }

    // Method to find a door by name
    private DoorInteraction FindDoorByName(string doorName)
    {
        DoorInteraction[] allDoors = FindObjectsOfType<DoorInteraction>();
        foreach (var door in allDoors)
        {
            if (door.gameObject.name == doorName)
            {
                return door;
            }
        }
        return null;
    }

    // Encrypt/Decrypt data method
    public string EncryptDecryptData(string data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ password[i % password.Length]);
        }
        return result;
    }

    // Trigger save/load when pressing keys
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9)) // Press 9 to save
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) // Press 0 to load
        {
            Load();
        }
    }
}
