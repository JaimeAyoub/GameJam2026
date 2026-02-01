using Unity.Cinemachine;
using UnityEngine;

public class CameraRaycast : UnityUtils.Singleton<CameraRaycast>
{
    public CinemachineVirtualCameraBase virtualCamera;
    LayerMask layerMask;

    //public bool canOpen = false;

#pragma warning disable CS0114 
    void Awake()
#pragma warning restore CS0114 
    {
        layerMask = LayerMask.GetMask("Door", "Player", "Note", "Items");
    }

    void Update()
    {
        //TODO: INPUT NUEVO
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }


    private void TryInteract()
    {
        RaycastHit hit;
        Debug.DrawRay(virtualCamera.transform.position, virtualCamera.transform.forward * 2.5f, Color.red, 0.1f);
        if (Physics.Raycast(virtualCamera.transform.position, virtualCamera.transform.forward, out hit, 2.5f, layerMask))
        {
            DoorScript door = hit.collider.GetComponent<DoorScript>();
            if (door != null && door.doorType != DoorType.noKey)
            {
                if (KeyManager.Instance.HasKey(door.doorType))
                {
                    door.ToggleDoor();
                    return;
                }
                else
                {
                    Debug.Log("Necesitas una llave para abrir esta puerta.");
                    return;
                }
               
            }else if (door != null && door.doorType == DoorType.noKey)
            {
                door.ToggleDoor();
                return;
            }

            // Detectar notas
            Note note = hit.collider.GetComponent<Note>();
            if (note != null)
            {
                note.ShowNote();
                return;
            }

            Key key = hit.collider.GetComponent<Key>();
            if (key != null)
            {
                KeyManager.Instance.AddKey(key.GetKeyType());
                Destroy(key.gameObject);
                return;
            }
        }
    }
}

