using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidBody;
    
    public Rigidbody Rigidbody => rigidBody;

    private void OnValidate()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
}
