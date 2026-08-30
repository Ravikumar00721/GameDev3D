using UnityEngine;

public class Bom : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float speed = 10f;

    Vector3 playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
        Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);
        destroyObject();
    }

    void destroyObject()
    {
        if(transform.position==playerPosition)
        {
            Destroy(gameObject);
        }
    }
}
