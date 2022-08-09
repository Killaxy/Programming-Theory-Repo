using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHealth = 1;
    [SerializeField] float moveCooldown = 3;
    [SerializeField] float shootCooldown = 1;
    private float timePassedSinceLastMove = 0;
    private float timePassedSinceLastShoot = 0;
    int health;
    void Start()
    {
        this.health = maxHealth;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if(timePassedSinceLastMove < 0)
        {
            this.Move();
            timePassedSinceLastMove = this.moveCooldown;
        }
        timePassedSinceLastMove -= Time.deltaTime;

        if (timePassedSinceLastShoot < 0)
        {
            this.Move();
            timePassedSinceLastShoot = this.shootCooldown;
        }
        timePassedSinceLastShoot -= Time.deltaTime;
    }

    // ABSTRACTION
    protected void Shoot()
    {
        //Spawn Projectile 
    }

    protected virtual void Move()
    {
        
        int currentXPos = (int) transform.position.x;
        bool leftFreeSpace = (currentXPos == -SpawnManager.getXBoundary() ? false:!GameStateHandler.instance.isPositionBlocked(currentXPos+SpawnManager.getXBoundary() - 1));
        bool rightFreeSpace = currentXPos == SpawnManager.getXBoundary() ? false:!GameStateHandler.instance.isPositionBlocked(currentXPos+SpawnManager.getXBoundary() + 1);
        int moveX = Random.Range(leftFreeSpace?-1:0, rightFreeSpace?2:1);
        
        MoveTo(currentXPos+ SpawnManager.getXBoundary(), moveX);
    }

    protected void MoveTo(int currentX, int x)
    {
        if (x != 0)
        {
            GameStateHandler.instance.setPositionFree(currentX);
            transform.Translate(new Vector3(x, 0, 0));
            GameStateHandler.instance.setPositionBlocked(currentX+x);
        }
    }
}
