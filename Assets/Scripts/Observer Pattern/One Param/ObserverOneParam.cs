using UnityEngine;
using UnityEngine.Events;

namespace Script.ObserverPattern
{

    public class ObserverOneParam : MonoBehaviour
    {
        public SubjectOneParam gameEvent;
        public UnityEvent<object> eventDelegate;
        void OnEnable()
        {
            gameEvent.AddObserver(this);
        }
        void OnDisable()
        {
            gameEvent.RemoveObserver(this);
        }
        public void OnEventTriggered(object param)
        {
            eventDelegate.Invoke(param);
        }
    }
}