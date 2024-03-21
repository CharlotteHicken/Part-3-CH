using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject spawnpoint;
    public GameObject wagonPrefab;
    public GameObject[] buildingPieces; 
    public float scale = 2f;
    public float duration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        GameObject wagon = Instantiate(wagonPrefab, spawnpoint.transform);
        yield return null;
        foreach (GameObject buildingPiece in buildingPieces)
        {
            GameObject piece = wagon.transform.Find(buildingPiece.name).gameObject;
            yield return StartCoroutine(ScalePiece(piece.transform));
        }
    }

    IEnumerator ScalePiece(Transform pieceScale)
    {
        float time = 0f;
        
        while (time < duration)
        {
            float t = time / duration;
            pieceScale.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            time += Time.deltaTime;
            yield return null;
        }
    }

}
