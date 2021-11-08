using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    bool alive = true;
    public float Speed = 5;
    public float jumpForce = 5;
    public Rigidbody rb;
    public LayerMask groundLayers;
    public SphereCollider col;
    public float speedIncreasePerCoin = 0.1f;
    public Camera cam1;
    public Camera cam2;
    public GameObject GameOverUI;
    int LaneCounter = 0;
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward * Speed * Time.fixedDeltaTime;
/*        Vector3 horizontalMove = transform.right * horizontalInput * Speed * Time.fixedDeltaTime* horizontalMultiplier;
*/        rb.MovePosition(rb.position + forwardMove /*+ horizontalMove*/);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Did we cross the distance?
        if (swipeDelta.magnitude > 100)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeCamera();
        }
        if (Input.GetKeyDown(KeyCode.A) || swipeLeft)
        {
            GoLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) || swipeRight)
        {
            GoRight();
        }
        
    }
    /*private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }*/
    public void Die()
    { 
        alive = false;
        //restart
        gameover();
    }
    void gameover()
    {
        cam1.GetComponentInChildren<AudioSource>().Stop();
        sounds.audioSrc.Stop();
        sounds.PlaySound("chill");
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void changeCamera()
    {
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
    }
    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down , (height/2) + 0.1f , groundLayers);
        //rb.AddForce(Vector3.up * jumpForce);
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    public void GoLeft()
    {
        if (LaneCounter != -1)
        {
            transform.position = transform.position + new Vector3(-3f, 0f, 0f);
            LaneCounter--;
        }
    }
    public void GoRight()
    {
        if (LaneCounter != 1)
        {
            transform.position = transform.position + new Vector3(3f, 0f, 0f);
            LaneCounter++;

        }
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
