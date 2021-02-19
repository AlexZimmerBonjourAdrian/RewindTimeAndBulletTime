using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExplosionPhysicsForce : MonoBehaviour
{

    public float explosionForce = 4;
    [SerializeField]
    private float multipler;

 private IEnumerator Start()
   {
        yield return null;

        float r = 10 * multipler;
        var cols = Physics.OverlapSphere(transform.position, r);
        var rigidbodies = new List<Rigidbody>();

        foreach(var col in cols)
        {
            if(col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
            {
                rigidbodies.Add(col.attachedRigidbody);
            }
        }
        foreach (var rb in rigidbodies)
        {
            rb.AddExplosionForce(explosionForce * multipler, transform.position, r, 1 * multipler, ForceMode.Impulse);
        }
   }

}

