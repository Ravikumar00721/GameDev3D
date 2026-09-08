using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] float power = 20f;
    [SerializeField] float rotationStrength = 100f;

    [SerializeField] InputAction rotation;

    [SerializeField] ParticleSystem mainEngine;
    [SerializeField] ParticleSystem leftEngine;
    [SerializeField] ParticleSystem rightEngine;

    Rigidbody rb;

    [SerializeField] AudioClip thurstSound;
    AudioSource audioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponents<AudioSource>()[0];
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void OnDisable()
    {
        thrust.Disable();
        rotation.Disable();
    }

    void Update()
    {



    }

    void FixedUpdate()
    {
        powerThrust();
        rotateRocket();
        handleEngineSound();
    }

    private void powerThrust()
    {
        if (thrust.IsPressed())
        {


            rb.AddRelativeForce(Vector3.up * power, ForceMode.Force);
            mainEngine.Play();

            // if (!audioSource.isPlaying)
            // {
            //     Debug.Log("CALLING PLAY");
            //     audioSource.PlayOneShot(thurstSound);
            // }
        }
        else
        {
            // audioSource.Stop();
            mainEngine.Stop();
        }
    }

    private void handleEngineSound()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (thrust.IsPressed() || rotationInput != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thurstSound);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void rotateRocket()
    {

        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            rightEngine.Play();
            leftEngine.Stop();
            // audioSource.PlayOneShot(thurstSound);
            transform.Rotate(Vector3.forward * rotationStrength * Time.fixedDeltaTime);

        }
        else if (rotationInput > 0)
        {

            leftEngine.Play();
            rightEngine.Stop();
            // audioSource.PlayOneShot(thurstSound);
            transform.Rotate(-Vector3.forward * rotationStrength * Time.fixedDeltaTime);

        }
        else
        {
            leftEngine.Stop();
            rightEngine.Stop();
            // audioSource.Stop();
        }



    }

}
