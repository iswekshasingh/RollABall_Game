using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private Vector3[] positions =
    {
        new Vector3(-9, 0.5f, -9),
        new Vector3( 9, 0.5f, -9),
        new Vector3(-9, 0.5f,  9),
        new Vector3( 9, 0.5f,  9),

        new Vector3(0, 0.5f, -11),
        new Vector3(0, 0.5f,  11),
        new Vector3(-11, 0.5f, 0),
        new Vector3(11, 0.5f, 0)
    };

    void Start()
    {
        foreach (Vector3 position in positions)
        {
            Instantiate(obstaclePrefab, position, Quaternion.identity);
        }
    }
}