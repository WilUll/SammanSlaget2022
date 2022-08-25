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
            GameObject particleSystemGameObject = Instantiate(ParticleBreakGO, transform.position, Quaternion.Euler(-90,0,0));
            particleSystemGameObject.GetComponent<ParticleSystemRenderer>().material =
                GetComponent<MeshRenderer>().material;
            particleSystemGameObject.GetComponent<ParticleSystem>().Play();
            Camera.main.GetComponent<CameraShake>().AddShake(0.1f, 0.5f);
            GameManager.AddScore(-5);
            UIHandler.myUpdateUI();
            Destroy(gameObject);
            Destroy(particleSystemGameObject, 5);
        }
    }
}
