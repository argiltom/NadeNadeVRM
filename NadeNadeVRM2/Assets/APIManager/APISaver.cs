using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UnityScene‚ÌÄ¶‚ÉAAPIKeys.json‚ğ•Û‘¶‚·‚é
/// </summary>
public class APISaver : MonoBehaviour
{
    [SerializeField] List<APIKeyJsonUnit> saveAPIKeys;
    // Start is called before the first frame update
    void Start()
    {
        JsonReadWriter.WriteData(new APIKeys(saveAPIKeys), "APIKeys");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
