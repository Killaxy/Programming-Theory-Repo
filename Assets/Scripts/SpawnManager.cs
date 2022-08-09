using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private List<GameObject> enemyTypes = new List<GameObject>();
    [SerializeField]private static int xBoundery = 16;
    private int wave = 1;
    void Start()
    {
        SpawnEnemys(3);
    }

    void SpawnEnemys(int count)
    {
        if (count > 10) count = 10; //Max 10 Enemys in Scene

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, enemyTypes.Count);
            int xpos = 0;

            do {
                xpos = Random.Range(0, xBoundery * 2);
            } while (GameStateHandler.instance.isPositionBlocked(xpos));
            GameStateHandler.instance.setPositionBlocked(xpos);
            
            Instantiate(enemyTypes[index],new Vector3(xpos - xBoundery, 10,0), enemyTypes[index].transform.rotation);

        }

        wave = count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int getXBoundary()
    {
        return xBoundery;
    }
}
