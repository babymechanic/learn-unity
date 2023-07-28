using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1.0f;
    [SerializeField] private float boostSpeed = 20.0f;
    [SerializeField] private float normalSpeed = 20.0f;
    private Rigidbody2D rb2d;
    private SurfaceEffector2D surfaceEffector2D;
    private bool isControlsDisabled;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlsDisabled) return;
        RotatePlayer();
        RespondToBoost();
    }

    public void DisableControls()
    {
        this.isControlsDisabled = true;
    }
    
    private void RespondToBoost()
    {
        surfaceEffector2D.speed = Input.GetKey(KeyCode.UpArrow) ? boostSpeed : normalSpeed;
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
