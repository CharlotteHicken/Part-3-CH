using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    protected override void Attack()
    {
        transform.position = destination;
        base.Attack();
        Instantiate(daggerPrefab, leftSpawnPoint.position, leftSpawnPoint.rotation);
        Instantiate(daggerPrefab, rightSpawnPoint.position, rightSpawnPoint.rotation);
    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
