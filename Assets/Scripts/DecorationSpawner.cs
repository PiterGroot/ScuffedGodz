using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationSpawner : MonoBehaviour
{
    private GameObject decorationParent;
    [SerializeField] private Vector2 worldMap;
    [SerializeField] private float density;
    [SerializeField] private DecorationPack decorationPack;
    // Start is called before the first frame update
    void Start()
    {
        GameObject decorations = new GameObject("Decorations");
        decorationParent = decorations;
        DecorateLevel();
    }

    public void DecorateLevel()
    {
        for (int i = 0; i < density; i++)
        {
            GameObject chosenDecoration = GetRandomDecorationObject();
            Vector2 randomPosition = new Vector2(Mathf.Clamp(Mathf.PerlinNoise(0, 1) * Random.Range(-worldMap.x, worldMap.x), -100, 100), Mathf.Clamp(Mathf.PerlinNoise(0, 1) * Random.Range(-worldMap.y, worldMap.y), -100, 100));
            GameObject decorationObject = Instantiate(chosenDecoration, randomPosition, Quaternion.identity);
            decorationObject.transform.SetParent(decorationParent.transform);
        }
    }

    private GameObject GetRandomDecorationObject()
    {
        return decorationPack.decorations[Random.Range(0, decorationPack.decorations.Count)];
    }
}
