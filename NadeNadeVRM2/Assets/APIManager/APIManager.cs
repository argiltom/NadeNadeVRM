using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct APIKey
{
    public string apiName;
    public string apiKey;
}

public class APIManager : MonoBehaviour
{
    public static APIManager instance;
    
    public string fileName;
    [HideInInspector] List<APIKey> apiKeys = new List<APIKey>();

    void InitAPIKeys(string fileName)
    {
        apiKeys = JsonReadWriter.ReadData<List<APIKey>>(fileName);
    }
    private void Awake()
    {
        InitAPIKeys(fileName);
    }
    public string GetAPIKey(string apiName)
    {
        foreach (APIKey apiKey in apiKeys)
        {
            if (apiName.Equals(apiName))
            {
                return apiKey.apiKey;
            }
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


