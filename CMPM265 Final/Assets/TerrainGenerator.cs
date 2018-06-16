using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code provided by tutorial video by Brackeys
//https://www.youtube.com/watch?time_continue=505&v=vFvwyu_ZKfU

//Part 2: Terrain Generator
public class TerrainGenerator : MonoBehaviour {
    [Range(0f, 100f)]
    public float timestamp;
    [Range(0f, 1000f)]
    public float PerlinScale;
    [Range(0f, 5f)]
    public float bumpiness;

    public static int depth = 256;
    public static int width = 256;
    public static int height = 20;
    public float scaleX, scaleY, scaleZ;
    public TerrainData T;

    private void Start()
    {
        Terrain terr = GetComponent<Terrain>();
        int i = Random.Range(0, GameObject.Find("Main Camera").GetComponent<CreateHouses>().Terrains.Count);
        terr.terrainData = GameObject.Find("Main Camera").GetComponent<CreateHouses>().Terrains[i];
        scaleX = GameObject.Find("Main Camera").GetComponent<CreateHouses>().SizeRange.y;
        scaleX *= -1f;
        scaleY = scaleX;
        scaleZ = scaleX;
    }

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData data)
    {
        data.heightmapResolution = width + 1;
        data.size = new Vector3(scaleX * width / 12.5f, height, scaleZ * depth / 9.2f);
        data.SetHeights(0, 0, GenerateHeight());
        return data;
    }

    float [,] GenerateHeight()
    {
        float[,] heights = new float[width, depth];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                heights[i, j] = CalculateHeight(i, j);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoor = (float) x / width * PerlinScale;
        float yCoor = (float) y / depth * PerlinScale;

        return Mathf.PerlinNoise(xCoor + timestamp, yCoor) * bumpiness;
    }
}
