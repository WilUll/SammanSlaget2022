using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public ObjectType binType;
    public int ObjectsInBin;
    public int CorrectObjectsInBin;

    private Animator animator;
    private int binSize = 5;

    public GameObject wrongParticleSystem;
    public GameObject correctParticleSystem;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MovingObject>())
        {
            ObjectsInBin++;

            MovingObject movingObject = collision.gameObject.GetComponent<MovingObject>();
            if (movingObject.TypeOfObject == binType)
            {
                correctParticleSystem.GetComponent<ParticleSystem>().Play();
                GameManager.AddScore(10);
            }

            if (movingObject.TypeOfObject!= binType)
            {
                wrongParticleSystem.GetComponent<ParticleSystem>().Play();
                GameManager.AddScore(-5);
            }

            if (ObjectsInBin >= binSize)
            {
                BinIsFull();
            }
            
            Destroy(collision.gameObject);
            Camera.main.GetComponent<CameraShake>().AddShake(0.1f, 0.1f);
            UIHandler.myUpdateUI();
        }
    }

    private void BinIsFull()
    {
        animator.SetTrigger("Exit");
        ObjectsInBin = 0;
        CorrectObjectsInBin = 0;
    }
}
