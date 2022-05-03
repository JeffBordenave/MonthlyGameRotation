using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject wallPrefab = default;
    
    public int round = 1;

    public int nWallStart = 5;
    public int nWallIncrease = 3;
    public float baseRadius = 5;
    public float radiusIncrease = 2;

    private List<GameObject> wallList = new List<GameObject>();

    private void Start()
    {
        SetupLevel();
    }

    private void SetupLevel()
    {
        for (int i = 0; i < round-1; i++)
        {
            SpawnCircleOfWalls(nWallIncrease * (i + 1), radiusIncrease * (i + 1));
        }

        SpawnLastCircleOfWalls(nWallIncrease * round, radiusIncrease * round);
    }

    private void SpawnCircleOfWalls(int nOfWall, float radius)
    {
        for (int i = 0; i < nOfWall; i++)
        {
            float angle = i * Mathf.PI * 2f / nOfWall;
            angle += Mathf.Deg2Rad * 0.001f;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);

            SpawnWall(newPos);
        }
    }

    private void SpawnLastCircleOfWalls(int nOfWall, float radius)
    {
        for (int i = 1; i < nOfWall; i++)
        {
            float angle = i * Mathf.PI * 2f / nOfWall;
            angle += Mathf.Deg2Rad * 90.001f;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);

            SpawnWall(newPos);
        }
    }

    private void SpawnWall(Vector3 position)
    {
        GameObject wall = Instantiate(wallPrefab);
        wall.transform.position = position;
        wall.transform.LookAt(Vector3.zero);

        wallList.Add(wall);
    }
}
