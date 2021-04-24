using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private float mX;
    private float mY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue mVal)
    {
        Vector2 mVec = mVal.Get<Vector2>();

        mX = mVec.x;
        mY = mVec.y;
    }

    void FixedUpdate()
    {
        Vector3 mv = new Vector3(mX, 0.0f, mY);

        rb.AddForce(mv * speed);
    }
}
