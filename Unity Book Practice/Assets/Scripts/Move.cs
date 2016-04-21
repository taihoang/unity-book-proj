using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    public float movementSpeed = 1;

    void Update()
    {

        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

    }
}
