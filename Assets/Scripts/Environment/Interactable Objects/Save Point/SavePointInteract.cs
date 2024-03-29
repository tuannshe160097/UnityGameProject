using Script.ObserverPattern;
using Script.SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Environment.InteractableObject
{

    public class SavePointInteract : InteractableObject
    {
        public override void Interact()
        {
            GetComponent<ObserverOneParam>().enabled = true;
            GameObject.FindObjectOfType<PlayerSave>().Save();
            GetComponent<ObserverOneParam>().enabled = false;
        }
    }

}