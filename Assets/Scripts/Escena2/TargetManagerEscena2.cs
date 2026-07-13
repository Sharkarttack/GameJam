using UnityEngine;

public class TargetManagerEscena2 : InteractableObject
{
    [SerializeField] private float timeToMove;
    [SerializeField] private Transform[] spawnPoints;
    private float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeToMove)
        {
            time = 0;
            move();
        }
    }
    private Vector2 RandomPosition()
    {
        int randNum = Random.Range(0,spawnPoints.Length);
        return spawnPoints[randNum].position;
    }
    private void move()
    {
        transform.position = RandomPosition();
    }

    public override void OnInteract()
    {
        print("interacted");
    }
}
