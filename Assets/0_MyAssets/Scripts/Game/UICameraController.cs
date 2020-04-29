using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem confettiL;
    [SerializeField] ParticleSystem confettiR;

    void Start()
    {

    }

    void Update()
    {
        transform.position = Camera.main.transform.position;
    }

    public void PlayConfetti()
    {
        confettiL.Play();
        confettiR.Play();
    }
}