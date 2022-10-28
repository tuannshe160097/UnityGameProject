using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.ObserverPattern
{

    [CreateAssetMenu(menuName = "Game Event (One Param)")]
    public class SubjectOneParam : ScriptableObject
    {
        private List<ObserverOneParam> observers = new List<ObserverOneParam>();
        public void Trigger(object param)
        {
            for (int i = observers.Count - 1; i >= 0; i--)
            {
                observers[i].OnEventTriggered(param);
            }
        }
        public void AddObserver(ObserverOneParam listener)
        {
            observers.Add(listener);
        }
        public void RemoveObserver(ObserverOneParam listener)
        {
            observers.Remove(listener);
        }
    }

}