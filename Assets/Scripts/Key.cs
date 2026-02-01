using UnityEngine;


    public enum KeyType
    {
        baño,
        sotano,
        cuarto,
    }
public class Key : MonoBehaviour
{
    public KeyType keyType;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public KeyType GetKeyType()
   {
       return keyType;
    }
}
