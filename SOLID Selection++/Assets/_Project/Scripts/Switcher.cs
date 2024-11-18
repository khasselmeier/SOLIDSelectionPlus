using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public List<GameObject> ChangeableObjects;
    private List<IChangeable> _changeableObjects = new List<IChangeable>();

    private void Start()
    {
        for (var i = 0; i < ChangeableObjects.Count; i++)
        {
            var changeableObject = ChangeableObjects[i].GetComponent<IChangeable>();
            _changeableObjects.Add(changeableObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            for (var i = 0; i < ChangeableObjects.Count; i++)
            {
                _changeableObjects[i].Next();
            }
        }
    }
}

public interface IChangeable
{
    void Next();
}
