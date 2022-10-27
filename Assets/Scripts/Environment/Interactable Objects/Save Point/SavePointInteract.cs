using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePointInteract : InteractableObject
{
    public override void Interact()
    {
        GetComponent<ObserverOneParam>().enabled = true;
        SaveManager.Save();
        GetComponent<ObserverOneParam>().enabled = false;
    }
}
