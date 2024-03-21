using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    Coroutine dashing;

    protected override void Attack()
    {
        if (dashing != null)
        {
            StopCoroutine(dashing);
        }
        dashing = StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = 7;
        while (speed > 3)
        {
            yield return null;
        }
        base.Attack();
        yield return new WaitForSeconds(0.1f);
        Instantiate(daggerPrefab, leftSpawnPoint.position, leftSpawnPoint.rotation);
        yield return new WaitForSeconds(0.15f);
        Instantiate(daggerPrefab, rightSpawnPoint.position, rightSpawnPoint.rotation);
    }
  

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
