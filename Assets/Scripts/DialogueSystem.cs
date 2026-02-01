using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;


[System.Serializable]
public struct Dialogue 
{
    
    public string name;
    [TextArea(3,10)]
    public string dialogueText;
    public GameObject person;
}

public class DialogueSystem : MonoBehaviour
{
    public CinemachineCamera cinemachine;
    public List<Dialogue> dialogueList = new();
    public int indexDialogues = -1;


    void Start()
    {
       cinemachine = FindObjectOfType<CinemachineCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            indexDialogues++;
            DisplayDialogue(indexDialogues);
        
        }
    }

    void DisplayDialogue(int index)
    {
        if(dialogueList.Count != 0)
        {
            if(index < dialogueList.Count)
            {
                if(cinemachine != null)
                {
                    cinemachine.Target.TrackingTarget = dialogueList[index].person.transform;

                }
                Debug.Log(dialogueList[index].name + ": " + dialogueList[index].dialogueText);
            }
        }
    }
}
