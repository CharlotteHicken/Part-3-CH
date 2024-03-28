using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingMaker : MonoBehaviour
{
    public GameObject thingPrefab;
    List<Thing> thingList = new List<Thing>();
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject go = Instantiate(thingPrefab);
            thingList.Add(go.GetComponent<Thing>());
        }

        foreach (Thing thing in thingList)
        {
            Debug.Log(thing.ToString() + " " + Thing.staticNumber);
        }
    }
}
