using UnityEngine;

public class TargetManagerEscena2 : InteractableObject
{
    [SerializeField] private float timeToMove;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private CariciasManagerEscena2 cariciasManager;
    private float time = 0;

    void Update()
    {
        if (!cariciasManager.MIMOS)
        {
            time += Time.deltaTime;
            if (time >= timeToMove)
            {
                time = 0;
                move();
            }
        }

    }
    private Vector2 RandomPosition()
    {
        int randNum = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randNum].position;
    }
    private void move()
    {
        transform.position = RandomPosition();
    }

    public override void OnInteract()
    {
        
        cariciasManager.startMimos();
        this.GetComponent<Collider2D>().enabled = false;
    }
}
