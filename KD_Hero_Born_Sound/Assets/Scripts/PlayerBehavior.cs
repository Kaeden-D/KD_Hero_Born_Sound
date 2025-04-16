using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerBehavior : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    public bool Avoid = false;
    public bool AvoidRestart = false;

    private bool jumpActive = false;
    private bool bulletActive = false;

    public delegate void JumpingEvent();
    public event JumpingEvent playerJump;

    private GameBehavior gameBehavior;
    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;

    // Start is called before the first frame update
    void Start()
    {

        gameBehavior = FindObjectOfType<GameBehavior>();

        if (gameBehavior == null)
        {
            Debug.LogError("GameBehavior not found in the scene!");
        }

        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        /*
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {

            jumpActive = true;

        }

        if (Input.GetMouseButtonDown(0))
        {

            bulletActive = true;

        }

        if (Input.GetKey("k"))
        {

            HealthChange(-1);

        }

    }

    // FixedUpdate is called at a fixed frame rate
    void FixedUpdate()
    {

        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (jumpActive)
        {

            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            jumpActive = false;
            playerJump();

        }

        if (bulletActive)
        {

            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            bulletActive = false;

        }

    }

    private bool IsGrounded()
    {

        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Enemy")
        {

            HealthChange(-1);

        }

    }

    public void SizeChange(float value)
    {

        this.gameObject.transform.localScale = new Vector3(value, value, value);
        gameBehavior.Size = value;

    }

    public void DamageChange(int value)
    {

        gameBehavior.Damage += value;

    }

    public void HealthChange(int value)
    {

        gameBehavior.HP += value;

    }

    public void AvoidStart(float value)
    {

        Avoid = true;
        gameBehavior.Avoid = true;
        Invoke("AvoidEnd", value);

    }

    public void AvoidEnd()
    {

        if(AvoidRestart)
        {

            Invoke("AvoidEnd", 5);
            AvoidRestart = false;

        }
        else
        {

            Avoid = false;
            gameBehavior.Avoid = false;

        }

    }

}
