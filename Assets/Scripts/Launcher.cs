using System;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    private Projectile projectilePrefab;
    [SerializeField]
    private Transform launchDirection;
    [SerializeField]
    private float initialVelocity = 1.0f;
    [SerializeField]
    private float initialImpulse = 1.0f;
    [SerializeField]
    private float lifetime = 1.0f;
    
    private Projectile currentProjectile;
    private float timeElapsed;
    
    public bool IsCurrentProjectile => currentProjectile != null;
    
    public void Launch(float magnitude)
    {
        if (currentProjectile) {
            Destroy(currentProjectile.gameObject);
        }

        var launchForward = launchDirection.forward * initialImpulse;
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.Rigidbody.linearVelocity = launchDirection.forward * initialVelocity;
        projectile.Rigidbody.AddForce(launchForward * magnitude, ForceMode.Impulse);

        currentProjectile = projectile;
    }

    private void Update()
    {
        if (currentProjectile) {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= lifetime) {
                Destroy(currentProjectile.gameObject);
                currentProjectile = null;
                timeElapsed = 0.0f;
            }
        }
    }
}