using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject fullWagon;
    public float speed = 1f;
    float wheeltime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        Instantiate(fullWagon);
        //GameObject wheel = new GameObject(fullWagon.GetComponentInChildren<Transform>());    
        yield return null;
        
        
    }

}
