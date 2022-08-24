using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public ObjectType TypeOfObject;
    public GameObject ParticleBreakGO;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BreakObject"))
        {
            GameObject particleSystemGameObject = Instantiate(ParticleBreakGO, transform.position, Quaternion.identity);
            particleSystemGameObject.GetComponent<ParticleSystemRenderer>().material =
                GetComponent<MeshRenderer>().material;
            particleSystemGameObject.GetComponent<ParticleSystem>().Play();
            Camera.main.GetComponent<CameraShake>().AddShake();
            Destroy(gameObject);
            Destroy(particleSystemGameObject, 5);
        }
    }
}
