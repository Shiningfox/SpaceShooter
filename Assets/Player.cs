using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class Player : MonoBehaviour
{
    public float tilt;
    public float speed;
    public Boundary boundary;
    Rigidbody rigi;
    AudioSource audio;
    // Update is called once per frame

    private void Start()
    {
        {
            rigi = GetComponent<Rigidbody>();
            audio = GetComponent<AudioSource>();
        }

    }

    void Update()
    {
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
         
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rigi.velocity = movement * speed;

            rigi.position = new Vector3(
            Mathf.Clamp(rigi.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigi.position.z, boundary.zMin, boundary.zMax)
        );

            rigi.rotation = Quaternion.Euler(
                0.0f,
                0.0f,
                rigi.velocity.x * -tilt
            );

        }
    }
}