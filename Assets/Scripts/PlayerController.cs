using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static bool playerCreated;
    public float speed = 5.0f;
    public bool isTalking = false;

    private const string AXIS_H = "Horizontal";
    private const string AXIS_V = "Vertical";
    private const string AXIS_LAST_V = "LastVertical";
    private const string AXIS_LAST_H = "LastHorizontal";
    private const string ATTACK = "Attacking";
    private bool walking = false;
    private bool attacking = false;
    public bool canMove = true;
    public float attackTime;
    private float attackTimeCounter;

    public Vector2 lastMovement = Vector2.zero;

    public string nextUuid;

    private Rigidbody2D _rigibody;
    private Animator _animator;

    private void Start()
    {
        this._animator = GetComponent<Animator>();
        this._rigibody = GetComponent<Rigidbody2D>();
        playerCreated = true;
        isTalking = false;
    }

    private void Update()
    {
        if (isTalking)
        {
            _rigibody.velocity = Vector2.zero;
            return;
        }

        this.walking = false;
        if (!canMove) return;

        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                attacking = false;
                _animator.SetBool(ATTACK, false);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            this.attacking = true;
            attackTimeCounter = attackTime;
            _rigibody.velocity = Vector2.zero;
            _animator.SetBool(ATTACK, true);
        }

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            //Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H) * this.speed * Time.deltaTime, 0, 0);
            //this.transform.Translate(translation);
            _rigibody.velocity = new Vector2(Input.GetAxisRaw(AXIS_H), 0).normalized * this.speed;
            this.walking = true;
            this.lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0);
        }

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            //Vector3 translation = new Vector3(0, Input.GetAxisRaw(AXIS_V) * this.speed * Time.deltaTime, 0);
            //this.transform.Translate(translation);
            _rigibody.velocity = new Vector2(0, Input.GetAxisRaw(AXIS_V)).normalized * this.speed;
            this.lastMovement = new Vector2(0, Input.GetAxisRaw(AXIS_V));
            this.walking = true;
        }
    }

    private void LateUpdate()
    {
        if (!this.walking)
        {
            _rigibody.velocity = Vector2.zero;
        }
        this._animator.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        this._animator.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));

        this._animator.SetBool("Walking", this.walking);
        this._animator.SetFloat(AXIS_LAST_H, this.lastMovement.x);
        this._animator.SetFloat(AXIS_LAST_V, lastMovement.y);
    }
}
