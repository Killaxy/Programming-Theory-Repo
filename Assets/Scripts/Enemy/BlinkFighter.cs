using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BlinkFighter : EnemyBase
{
    private int maxBlinkRange = 3;
    //POLYMORPHISM
    protected override void Move()
    {
        int currentX = (int) transform.position.x;
        List<int> possibleBlinks = new List<int>();

        for(int i = -maxBlinkRange;i <= maxBlinkRange; i++)
        {
            if (currentX + i < -SpawnManager.getXBoundary()) continue;
            if (currentX + i > SpawnManager.getXBoundary()) continue;
            if (GameStateHandler.instance.isPositionBlocked(currentX + SpawnManager.getXBoundary() + i))continue;
            possibleBlinks.Add(i);
        }

        if (possibleBlinks.Count > 0)
        {
            int index = Random.Range(0, possibleBlinks.Count);

            int MoveToX = possibleBlinks[index];

            base.MoveTo(currentX + SpawnManager.getXBoundary(), MoveToX);
        }
    }

}
