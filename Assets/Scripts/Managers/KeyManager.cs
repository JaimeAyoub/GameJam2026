using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils;

public class KeyManager : Singleton<KeyManager>
{
    public List<KeyType> keys = new List<KeyType>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKey(KeyType key)
    {
        keys.Add(key);
    }
    public void RemoveKey(KeyType key) {
        if(keys.Contains(key))
            keys.Remove(key);
    }

    public bool HasKey(DoorType doorType)
    {
        KeyType keyType = (KeyType)Enum.Parse(typeof(KeyType), doorType.ToString());
        return keys.Contains(keyType);
    }
}
