using UnityEngine;

public class Scorer : MonoBehaviour
{
    int score = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit" && other.gameObject.tag=="Ground")
        {
            score += 1;
            Debug.Log("Score : " + score);
        }
    }
}
