using Script.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Environment.InteractableObject
{

    abstract public class InteractableObject : MonoBehaviour
    {
        private Interact _playerInteract;

        protected void Start()
        {
            _playerInteract = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Interact>();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _playerInteract.PrepareInteraction(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _playerInteract.DisposeInteraction();
            }
        }

        abstract public void Interact();
    }

}