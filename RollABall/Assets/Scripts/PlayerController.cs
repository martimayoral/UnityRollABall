using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject[] lvlWalls;

    private int lvl;
    private int[] maxBalls = { 10, 15, 20, 25 };
    private Rigidbody rb;
    private int count;
    private float mX;
    private float mY;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        lvl = 1;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue mVal)
    {
        Vector2 mVec = mVal.Get<Vector2>();

        mX = mVec.x;
        mY = mVec.y;
    }

    void SetCountText()
    {
        if (count >= maxBalls[lvl - 1])
        {
            if (lvl == 4)
            {
                winTextObject.SetActive(true);
            }
            else
            {
                lvlWalls[lvl - 1].SetActive(false);
                count = 0;
                lvl++;
            }
            
        }
        countText.text = "Level " + lvl + " - " + count.ToString() + "/" + maxBalls[lvl - 1];
    }

    void FixedUpdate()
    {
        Vector3 mv = new Vector3(mX, 0.0f, mY);

        rb.AddForce(mv * (speed + lvl));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}
