using UnityEngine;

public class enemySpawnManager : MonoBehaviour
{
    public static enemySpawnManager instance;

    [SerializeField] private LayerMask _layersEnemyCannotSpawnOn;

    private void Awake()
    {
        if (instance == null)
        { 
        instance = this;
        }
    }
    public void spawnEnemies(Collider2D spawnableAreaCollider, GameObject[] enemies)
    {
        foreach(GameObject enemy in enemies)
        {
            Vector2 spawnPosition = getRanomdSpawnposition(spawnableAreaCollider);
            GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
    private Vector2 getRanomdSpawnposition(Collider2D spawnableAreaCollider)
    {
        Vector2 spawnPosition = Vector2.zero;
        bool isSpawnPosValid = false;

        int attemptCount = 0;
        int maxAttempts = 200;


        while(!isSpawnPosValid && attemptCount<maxAttempts)
        {
            spawnPosition = getRandomPointInCollider(spawnableAreaCollider);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 0.15f);

            bool isInvalidCollision = false;
            foreach(Collider2D collider in colliders)
            {
                if(((1<<collider.gameObject.layer)&_layersEnemyCannotSpawnOn)!=0)
                {
                    isInvalidCollision = true;
                    break;
                }
            }
         

            if(!isInvalidCollision)
            {
                isSpawnPosValid = true;
            }

            attemptCount++;
        }

        if(!isSpawnPosValid)
        {
            Debug.LogWarning("No valid spawn pos");
        }

        return spawnPosition;
    }
    private Vector2 getRandomPointInCollider(Collider2D collider, float offset =1f)
    {
        Bounds collBounds = collider.bounds;

        Vector2 minBounds = new Vector2(collBounds.min.x + offset, collBounds.min.y + offset);
        Vector2 maxBounds = new Vector2(collBounds.max.x - offset, collBounds.max.y - offset);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);

        return new Vector2(randomX, randomY);

    }
}
