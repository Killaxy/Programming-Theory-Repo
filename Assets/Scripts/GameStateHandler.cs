using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    // ENCAPSULATION
    public static GameStateHandler instance { get; private set; }

    public string playerName;
    private bool[] xPositions = new bool[SpawnManager.getXBoundary()*2 + 1];
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool isPositionBlocked(int x)
    {
        return xPositions[x];
    }

    public void setPositionBlocked(int x)
    {
        xPositions[x] = true;
    }

    public void setPositionFree(int x)
    {
        xPositions[x] = false;
    }
}
