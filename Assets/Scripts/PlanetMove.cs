using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour
{
    public float RotationSpeed = 1f;

    void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
    }
}