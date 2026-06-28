using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float x;
    [SerializeField] float y;




    [SerializeField] private LayerMask layersEnemyCannotSpawnOn;



    public void SpawnEnemies(Collider2D spawnableAreaCollider, GameObject[] enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition(spawnableAreaCollider);
            GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    public void SpawnWalls(Collider2D spawnableAreaCollider, GameObject[] walls)
    {
        foreach (GameObject wall in walls)
        {
            Vector2 spawnPosition = new Vector2(x,y);
            GameObject spawnedEnemy = Instantiate(wall, spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetRandomSpawnPosition(Collider2D spawnableAreaCollider)
    {
        Vector2 spawnPosition = Vector2.zero;
        bool isSpawnPosValid = false;

        int attemptCount = 0;
        int maxAttempts = 200;


        while(!isSpawnPosValid && attemptCount < maxAttempts)
        {
            spawnPosition = GetRandomPointInCollider(spawnableAreaCollider);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 2f);

            bool isInvalidCollision = false;
            foreach (Collider2D collider in colliders)
            {
                if (((1 << collider.gameObject.layer) & layersEnemyCannotSpawnOn) !=0)
                {
                    isInvalidCollision = true;
                    break;
                }
            }


            if (!isInvalidCollision)
            {
                isInvalidCollision = true;
                break;
            }

            attemptCount++;
        }

        if (isSpawnPosValid)
        {
            Debug.LogWarning("Cound not find a valid spawn position");
        }

        return spawnPosition;
    }

    private Vector2 GetRandomPointInCollider(Collider2D collider, float offset = 1f)
    {
        Bounds collBounds = collider.bounds;

        Vector2 minBounds = new Vector2(collBounds.min.x + offset, collBounds.min.y + offset);
        Vector2 maxBounds = new Vector2(collBounds.max.x - offset, collBounds.max.y - offset);

        float randomx = UnityEngine.Random.Range(minBounds.x, maxBounds.x);
        float randomy = UnityEngine.Random.Range(minBounds.y, maxBounds.y);

        return new Vector2(randomx, randomy);
    }
}
