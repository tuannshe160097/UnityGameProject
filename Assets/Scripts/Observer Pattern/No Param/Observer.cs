using UnityEngine;
using UnityEngine.Events;

namespace Script.ObserverPattern
{

    public class Observer : MonoBehaviour
    {
        public Subject gameEvent;
        public UnityEvent eventDelegate;
        void OnEnable()
        {
            gameEvent.AddObserver(this);
        }
        void OnDisable()
        {
            gameEvent.RemoveObserver(this);
        }
        public void OnEventTriggered()
        {
            eventDelegate.Invoke();
        }
    }
}