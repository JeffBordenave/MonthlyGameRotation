using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject wallPrefab = default;
    public GameObject container = default;
    public GameObject ballPrefab = default;
    public GameObject camera = default;
    
    [Header("GameData")]
    public int round = 1;

    [Header("LevelData")]
    public int nWallIncrease = 3;
    public float radiusIncrease = 2;

    [Header("BallData")]
    public float ballOffset = 2;

    [Header("CameraData")]
    public float cameraOffset;

    private List<GameObject> wallList = new List<GameObject>();
    private Vector3 posToSpawBall = Vector3.zero;

    public static GameManager instance;

    private void Start()
    {
        SetupLevel();
        instance = this;
    }

    private void SetupLevel()
    {
        posToSpawBall = new Vector3(0, radiusIncrease * round + ballOffset);

        for (int i = 0; i < round-1; i++)
        {
            SpawnCircleOfWalls(nWallIncrease * (i + 1), radiusIncrease * (i + 1));
        }

        SpawnLastCircleOfWalls(nWallIncrease * round, radiusIncrease * round);

        SpawnBall(posToSpawBall);
        SetCamera();
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
        GameObject wall = Instantiate(wallPrefab, container.transform, true);
        wall.transform.position = position;
        wall.transform.LookAt(Vector3.zero);

        wallList.Add(wall);
    }

    private void SpawnBall(Vector3 position)
    {
        GameObject ball = Instantiate(ballPrefab);
        ball.transform.position = position;
    }

    private void SetCamera()
    {
        camera.transform.position = new Vector3(0, 0, -round * cameraOffset);
    }

    public void BallCollision(GameObject ballHit)
    {
        if (!wallList.Contains(ballHit)) return;

        ballHit.SetActive(false);
        wallList.Remove(ballHit);
    }
}
