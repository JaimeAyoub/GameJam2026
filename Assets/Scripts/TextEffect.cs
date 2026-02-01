using UnityEngine;
using TMPro;
public class TextEffect : MonoBehaviour
{

    public TextMeshProUGUI text;
    public char[] allText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(text.text.Length);
        for(int i = 0; i <= text.text.Length;i++)
        {

           // allText[i] = text.text[i - 1];
        }
        text.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
