using System.Collections.Generic;
using NUnit.Framework;
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

    [Header("Trajectory Settings")]
    [SerializeField] private LineRenderer trajectoryLine;

    [Header("BULLSEYE")]
    [SerializeField] private GameObject hitMarker;

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
        if (input.actions["Aim"].WasPressedThisFrame())
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

        trajectoryLine.enabled = true;
    }

    void ChargeThrow()
    {
        chargeTime += Time.deltaTime;

        Vector3 grenadeVelocity = (mainCamera.transform.forward + throwDirection).normalized * Mathf.Min(chargeTime * throwForce, maxForce);   
        ShowTrajectory(throwPosition.position + throwPosition.forward, grenadeVelocity);
    }

    void ReleaseThrow()
    {
        ThrowGrenade(Mathf.Min(chargeTime * throwForce, maxForce));
        isCharging = false;

        trajectoryLine.enabled = false;
    }

    void ThrowGrenade(float force)
    {
        Vector3 spawnPosition = throwPosition.position + mainCamera.transform.forward;

        GameObject grenade = Instantiate(grenadePrefab, spawnPosition, mainCamera.transform.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        Vector3 finalThrowDirection = (mainCamera.transform.forward + throwDirection).normalized;
        rb.AddForce(finalThrowDirection * force, ForceMode.VelocityChange);


    }

    void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] trajectoryPoints = new Vector3[100];

        trajectoryPoints[0] = origin;

        int puntosUsados = 1;

        for(int i = 1; i < trajectoryPoints.Length; i++)
        {
            float time = i * 0.1f;
            Vector3 nuevoPunto = origin + speed * time + 0.5f * Physics.gravity * time * time;
            

            Vector3 puntoAnterior = trajectoryPoints[i - 1];


            Vector3 tramo = nuevoPunto - puntoAnterior;
            float distance = tramo.magnitude;

            bool hasHit = Physics.Raycast(puntoAnterior, tramo.normalized, out RaycastHit hit, distance);
            
            if(hasHit)
            {
                trajectoryPoints[i] = hit.point;
                //MoveHitMarker(hit);
                puntosUsados++;
                break;
            }
            else
            {
                trajectoryPoints[i] = nuevoPunto;
                puntosUsados++;
            }
        }

        trajectoryLine.positionCount = puntosUsados;

        trajectoryLine.SetPositions(trajectoryPoints);
    }

    /*private void MoveHitMarker(RaycastHit hit)
    {
        hitMarker.gameObject.setActive(true);

        float offset = 0.025f;
        hitMarker.position = hit.point + hit.normal * offset;
        hitMarker.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
    }*/
}
