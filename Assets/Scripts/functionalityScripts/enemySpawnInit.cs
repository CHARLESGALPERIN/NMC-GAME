using UnityEngine;

public class enemySpawnInit : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesToSpawnIn;

    [SerializeField] private Collider2D _currentRoomSpawnableArea;

    public float spawnDelay;
    private float spawnTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer>spawnDelay)
        {
            spawnTimer = 0;
            enemySpawnManager.instance.spawnEnemies(_currentRoomSpawnableArea, _enemiesToSpawnIn);
        }
        
    }
}
