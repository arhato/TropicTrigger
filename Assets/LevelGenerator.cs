using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    [Header("Tilemap References")]
    public Tilemap platformTilemap;
    public TileBase platformTile;
    
    [Header("Prefabs")]
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    
    [Header("Level Settings")]
    public int levelWidth = 100;
    public int levelHeight = 20;
    public int startPlatformWidth = 8;
    
    [Header("Platform Generation")]
    public int minPlatformLength = 3;
    public int maxPlatformLength = 8;
    public float minGapBetweenPlatforms = 1.5f;
    public float maxGapBetweenPlatforms = 3.5f;
    public int minPlatformY = 1;
    public int maxPlatformY = 10;
    public int maxHeightDifference = 3;
    
    [Header("Additional Platform Settings")]
    public int additionalPlatformsCount = 15;
    public float enemySpawnChance = 0.3f;
    
    private System.Random random;
    
    private void Start()
    {
        int seed = System.DateTime.Now.Millisecond;
        random = new System.Random(seed);
        Debug.Log("Using seed: " + seed);
        
        GenerateLevel();
    }
    
    public void GenerateLevel()
    {
        // Clear any existing tiles
        platformTilemap.ClearAllTiles();
        
        // Remove any previously generated enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.parent == transform)
                Destroy(enemy);
        }
        
        // Generate starting platform
        GenerateStartPlatform();
        
        // Generate main path
        GenerateMainPath();
        
        // Add additional platforms for exploration
        GenerateAdditionalPlatforms();
        
        // Place player at start if prefab is assigned
        if (playerPrefab != null)
        {
            Instantiate(playerPrefab, new Vector3(2, 3, 0), Quaternion.identity);
        }
    }
    
    private void GenerateStartPlatform()
    {
        // Create a flat platform at the start for the player
        for (int x = 0; x < startPlatformWidth; x++)
        {
            platformTilemap.SetTile(new Vector3Int(x, 0, 0), platformTile);
        }
    }
    
    private void GenerateMainPath()
    {
        int currentX = startPlatformWidth;
        int currentY = 0;
        
        // Continue generating platforms until we reach the level width
        while (currentX < levelWidth)
        {
            // Determine platform length
            int platformLength = random.Next(minPlatformLength, maxPlatformLength + 1);
            
            // Don't let platform exceed level width
            if (currentX + platformLength > levelWidth)
                platformLength = levelWidth - currentX;
            
            // Place the platform
            PlacePlatform(currentX, currentY, platformLength);
            
            // Maybe place an enemy on this platform
            if (random.NextDouble() < enemySpawnChance && platformLength >= 4)
            {
                // Don't place enemies at the edges of platforms
                int enemyX = currentX + random.Next(1, platformLength - 1);
                PlaceEnemy(enemyX, currentY + 1);
            }
            
            // Determine next platform position
            float gap = (float)(minGapBetweenPlatforms + random.NextDouble() * (maxGapBetweenPlatforms - minGapBetweenPlatforms));
            int nextX = currentX + platformLength + Mathf.RoundToInt(gap);
            
            // Determine next platform height (with constraints to keep it playable)
            int heightChange = random.Next(-2, 3);
            int nextY = Mathf.Clamp(currentY + heightChange, minPlatformY, maxPlatformY);
            
            // Make sure jumps are possible (not too high)
            if (nextY - currentY > maxHeightDifference)
                nextY = currentY + maxHeightDifference;
            
            // Update current position
            currentX = nextX;
            currentY = nextY;
        }
    }
    
    private void GenerateAdditionalPlatforms()
    {
        // Add some extra platforms that aren't part of the main path
        for (int i = 0; i < additionalPlatformsCount; i++)
        {
            int platformLength = random.Next(minPlatformLength, maxPlatformLength + 1);
            int platformX = random.Next(startPlatformWidth + 5, levelWidth - platformLength - 1);
            int platformY = random.Next(minPlatformY, maxPlatformY);
            
            // Make sure we're not overlapping with existing platforms
            bool canPlace = true;
            for (int x = 0; x < platformLength; x++)
            {
                if (IsTileOccupied(platformX + x, platformY) || 
                    IsTileOccupied(platformX + x, platformY + 1) || 
                    IsTileOccupied(platformX + x, platformY - 1))
                {
                    canPlace = false;
                    break;
                }
            }
            
            if (canPlace)
            {
                PlacePlatform(platformX, platformY, platformLength);
                
                // Maybe place enemy
                if (random.NextDouble() < enemySpawnChance && platformLength >= 3)
                {
                    int enemyX = platformX + random.Next(1, platformLength - 1);
                    PlaceEnemy(enemyX, platformY + 1);
                }
            }
        }
    }
    
    private void PlacePlatform(int startX, int startY, int length)
    {
        for (int x = 0; x < length; x++)
        {
            platformTilemap.SetTile(new Vector3Int(startX + x, startY, 0), platformTile);
        }
    }
    
    private void PlaceEnemy(int x, int y)
    {
        if (enemyPrefab != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(x + 0.5f, y, 0), Quaternion.identity);
            enemy.transform.parent = transform; // Parent to level generator for easy cleanup
        }
    }
    
    private bool IsTileOccupied(int x, int y)
    {
        return platformTilemap.HasTile(new Vector3Int(x, y, 0));
    }
    
    // Helper method to visualize level bounds in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(levelWidth / 2f, levelHeight / 2f, 0), new Vector3(levelWidth, levelHeight, 0));
    }
}