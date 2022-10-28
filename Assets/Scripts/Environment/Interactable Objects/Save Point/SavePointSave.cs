namespace Script.Environment.InteractableObject
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class SavePointSave : MonoBehaviour
    {
        public void Save(object param)
        {
            Dictionary<string, object> saveData = (Dictionary<string, object>)param;

            saveData.Add("Scene", SceneManager.GetActiveScene().name);
            saveData.Add("Position", new Vector3Json(transform.position));
        }
    }

}