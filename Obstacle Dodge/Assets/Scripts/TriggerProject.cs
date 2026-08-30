using UnityEngine;

public class TriggerProject : MonoBehaviour
{
    [SerializeField] GameObject projjectile;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            projjectile.SetActive(true);
        }
    }
}
