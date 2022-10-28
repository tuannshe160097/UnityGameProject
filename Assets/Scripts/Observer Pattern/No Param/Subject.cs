using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.ObserverPattern
{

    [CreateAssetMenu(menuName = "Game Event")]
    public class Subject : ScriptableObject
    {
        private List<Observer> observers = new List<Observer>();
        public void Trigger()
        {
            for (int i = observers.Count - 1; i >= 0; i--)
            {
                observers[i].OnEventTriggered();
            }
        }
        public void AddObserver(Observer listener)
        {
            observers.Add(listener);
        }
        public void RemoveObserver(Observer listener)
        {
            observers.Remove(listener);
        }
    }

}