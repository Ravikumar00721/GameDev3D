using UnityEngine;

public class Dodgy : MonoBehaviour
{


    float moveSpeed = 10f;
    // bool hitted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        printDebugs();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();


    }

    void printDebugs()
    {
        Debug.Log("Game is Running");
    }

    void movePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue, yValue, zValue);
    }
}
