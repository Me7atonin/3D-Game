using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveSystemBackup : MonoBehaviour
{
    string password = "1234567890";
    CharacterController characterController;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }*/
    }

    public void Save()
    {
        //string result = EncryptDecryptData("a");
        //Debug.Log(result);
        //Checkpoint myData = new Checkpoint();
        //myData.x = transform.position.x;
        //myData.y = transform.position.y;
        //myData.z = transform.position.z;
        //myData.levelName = "Level1";
        //string myDataString = JsonUtility.ToJson(myData);
        //myDataString = EncryptDecryptData(myDataString);
        //string file = Application.persistentDataPath + "/" + gameObject.name + "json";
        string file = Application.persistentDataPath + "/" + gameObject.name + "_checkpoint.json";
        //System.IO.File.WriteAllText(file, myDataString);
        //Debug.Log(file);
    }

    public void Load()
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + "json";
        if (File.Exists(file))
        {
            string jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            //SaveData myData = JsonUtility.FromJson<SaveData>(jsonData);
            characterController.enabled = false;
            //transform.position = new Vector3(myData.x, myData.y, myData.z);
            characterController.enabled = true;
        }
    }

    public string EncryptDecryptData(string data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ password[i % password.Length]);
        }
        return result;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SaveTrigger"))
        {
            Save();
        }
    }
}


//[System.Serializable]
/*public class SaveData
{
    public float x;
    public float y;
    public float z;
    public int level;
}*/

/*[System.Serializable]
public class Checkpoint
{
    public string levelName;
}*/
