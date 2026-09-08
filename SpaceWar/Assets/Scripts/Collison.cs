
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collison : MonoBehaviour
{

    float loadtime = 2f;

    [SerializeField] ParticleSystem SuccessParticle;
    [SerializeField] ParticleSystem CrashParticle;

    AudioSource audioSorce;

    bool isControllable = true;

    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip Error;
    void OnCollisionEnter(Collision other)
    {
        if (!isControllable) return;



        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You are safe");
                break;
            case "Fuel":
                Debug.Log("Hello bro");
                break;
            case "Finish":
                StartNextSequence();
                break;
            default:
                StartCrashSequence();
                break;


        }

    }

    void Start()
    {
        audioSorce = GetComponents<AudioSource>()[1];


    }

    void StartCrashSequence()
    {
        isControllable = false;
        SuccessParticle.Play();
        audioSorce.PlayOneShot(Error);
        Invoke("ReloadLevel", loadtime);
        GetComponent<Movement>().enabled = false;
    }
    void StartNextSequence()
    {
        isControllable = false;
        CrashParticle.Play();
        audioSorce.PlayOneShot(Success);
        Invoke("LoadNextLevel", loadtime);
        GetComponent<Movement>().enabled = false;
    }

    void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentIndex + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }

        SceneManager.LoadScene(nextScene);
    }

    void ReloadLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
