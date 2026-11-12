
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public int count = 0;
    public CollectibleSpawner spawner;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);

            count++;

            Debug.Log("Balls collected: " + count);

            StartCoroutine(spawner.RespawnCollectible());
        }
    }
}
