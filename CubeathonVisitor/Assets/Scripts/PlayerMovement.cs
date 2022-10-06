using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce;
    public int color = 0;
    public int prevcolor = 0;
    public bool needColorChange = false;
    public bool isGreen = false;

    [HideInInspector]
    public bool gameStart = false;

    private void OnEnable()
    {
        Score.milestone += ChangeColor;
    }

    private void OnDisable()
    {
        Score.milestone -= ChangeColor;
    }

    public void ChangeColor(float nothing)
    {
        if(nothing == 100f)
        {
            //rb.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        }
    }

    void FixedUpdate()
    {
        if (gameStart == true)
        {
            Move();
        }
    }

    public void Move()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame(null);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameStart == true)
            TryJump();

        if(needColorChange != false)
        {
            ChangeColor();
        }
    }

    void ChangeColor ()
    {
        needColorChange = false;

        if(color == 0)
        {
            rb.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            isGreen = false;
        } else if (color == 1 && prevcolor == 2 || color == 2 && prevcolor == 1)
        {
            rb.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            isGreen = true;
        } else if (color == 1)
        {
            rb.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
            isGreen = false;
        } else if (color == 2)
        {
            rb.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
            isGreen = false;
        }
        if(isGreen == false)
        {
            prevcolor = color;
        } else
        {
            prevcolor = 0;
        }
    }

    void TryJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, 0.7f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
