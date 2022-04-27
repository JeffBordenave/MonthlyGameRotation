using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject wallPrefab = default;

    private void Start()
    {
        SpawnCircleOfWalls(10, 10);
    }

    private void SpawnCircleOfWalls(int nOfWall, float radius)
    {
        for (int i = 0; i < nOfWall; i++)
        {
            Vector3 posVector = new Vector3(i * 10, 0, 0);
            SpawnWall(posVector, Quaternion.identity);
        }
    }

    private void SpawnWall(Vector3 position, Quaternion rotation)
    {
        GameObject wall = Instantiate(wallPrefab);
        wall.transform.position = position;
        wall.transform.rotation = rotation;
    }
}
