using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisparoThrow : MonoBehaviour
{
    PlayerInput input;

    [Header("GRANADA/BALA")]
    [SerializeField] private GameObject grenadePrefab;

    [Header("Granada/Bala Settings")]
    [SerializeField] private Transform throwPosition;
    [SerializeField] private Vector3 throwDirection = new Vector3(0, 1, 0);

    [Header("Granada/Bala Fuerza")]
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private float maxForce = 20f;

    private bool isCharging = false;
    private float chargeTime = 0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (input.actions["Aim"].IsPressed())
        {
            StartThrowing();
            print("ESTOY SIENDO CARGADO");  
        }
        if(isCharging)
        {
            ChargeThrow();
        }
        if (input.actions["Aim"].WasReleasedThisFrame())
        {
            ReleaseThrow();
            print("SALGO DISPARADO");   
        }
    }

    void StartThrowing()
    {
        isCharging = true;
        chargeTime = 0f;

        //Trajectory line
    }

    void ChargeThrow()
    {
        chargeTime += Time.deltaTime;

        //trajectory line velocity
    }

    void ReleaseThrow()
    {
        ThrowGrenade(Mathf.Min(chargeTime * throwForce, maxForce));
        isCharging = false;

        //hide line
    }

    void ThrowGrenade(float force)
    {
        Vector3 spawnPosition = throwPosition.position + mainCamera.transform.forward;

        GameObject grenade = Instantiate(grenadePrefab, spawnPosition, mainCamera.transform.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        Vector3 finalThrowDirection = (mainCamera.transform.forward + throwDirection).normalized;
        rb.AddForce(finalThrowDirection * force, ForceMode.VelocityChange);


    }

    //ShowTrajectory
}
