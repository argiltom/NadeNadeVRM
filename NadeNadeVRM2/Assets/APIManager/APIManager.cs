using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct APIKeyJsonUnit
{
    public string apiName;
    public string apiKey;
}
//UnityでJSONで扱う際はListをオブジェクトでラッピングしないといけない
[System.Serializable]
public struct APIKeys
{
    public List<APIKeyJsonUnit> apiKeyList;
    public APIKeys(List<APIKeyJsonUnit> apiKeys)
    {
        this.apiKeyList = apiKeys;
    }
}

public class APIManager : MonoBehaviour
{
    public static APIManager instance;
    
    public string fileName;
    [HideInInspector] public APIKeys apiKeys;

    void InitAPIKeys(string fileName)
    {
        apiKeys =JsonReadWriter.ReadData<APIKeys>(fileName);
    }
    void PrintToCosole()
    {
        Debug.Log("炎の心");
        foreach (APIKeyJsonUnit apiKey in apiKeys.apiKeyList)
        {
            Debug.Log(apiKey.apiName + ":" + apiKey.apiKey+"\n");
        }
    }
    private void Awake()
    {
        instance = this;
        
    }
    public static string GetAPIKey(string apiName)
    {
        foreach (APIKeyJsonUnit apiKey in instance.apiKeys.apiKeyList)
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
        InitAPIKeys(fileName);
        PrintToCosole();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


