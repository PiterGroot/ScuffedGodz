using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class DecorationSpawner : MonoBehaviour
{
    private GameObject decorationParent;
    private Tilemap map;

    [SerializeField] private Vector2 worldMap;
    [SerializeField] private float density;
    [SerializeField] private float tileScale;
    [SerializeField] private DecorationPack decorationPack;
    [SerializeField] private UnityEvent onLevelGenerated = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        GameObject decorations = new GameObject("Decorations");
        map = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        decorationParent = decorations;
        DecorateLevel();
    }

    public void DecorateLevel()
    {
        //create background tiles
        for (int x = 0; x < worldMap.x; x++)
        {
            for (int y = 0; y < worldMap.y; y++)
            {
                Vector3Int position = map.WorldToCell(new Vector3(x, y, 0));
                map.SetTile(position, decorationPack.tiles);
            }
        }
        //populating world with decorations
        for (int i = 0; i < density; i++)
        {
            GameObject chosenDecoration = GetRandomDecorationObject();
            Vector2 randomPosition = new Vector2(Mathf.PerlinNoise(0, 1) * Random.Range(-worldMap.x, worldMap.x), Mathf.PerlinNoise(0, 1) * Random.Range(-worldMap.y, worldMap.y));
            GameObject decorationObject = Instantiate(chosenDecoration, randomPosition, Quaternion.identity);
            decorationObject.transform.SetParent(decorationParent.transform);
        }
       // map.transform.localScale = new Vector3(tileScale, tileScale, 0);
        decorationParent.transform.position = new Vector3(worldMap.x / 2, worldMap.y / 2, 0);
        //decorationParent.transform.localScale = map.transform.localScale;
        OnLevelGenerated();
    }

    private void OnLevelGenerated()
    {
        print("LEVEL DONE GENERATING");
        PlayerMovement[] players = FindObjectsOfType<PlayerMovement>();
        foreach (PlayerMovement player in players) player.SetStartPosition(new Vector3(worldMap.x / 2 + Random.Range(-2, 2), worldMap.y / 2 + Random.Range(-2, 2), 0));
        onLevelGenerated?.Invoke();
    }

    private GameObject GetRandomDecorationObject()
    {
        return decorationPack.decorations[Random.Range(0, decorationPack.decorations.Count)];
    }
}
