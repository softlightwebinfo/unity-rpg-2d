using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private const string AXIS_H = "Horizontal";
    private const string AXIS_V = "Vertical";
    private const string AXIS_LAST_V = "LastVertical";
    private const string AXIS_LAST_H = "LastHorizontal";
    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;
    private Rigidbody2D _rigibody;
    private Animator _animator;

    private void Start()
    {
        this._animator = GetComponent<Animator>();
        this._rigibody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.walking = false;

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            //Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H) * this.speed * Time.deltaTime, 0, 0);
            //this.transform.Translate(translation);
            _rigibody.velocity = new Vector2(Input.GetAxisRaw(AXIS_H) * this.speed, 0);
            this.walking = true;
            this.lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0);
        }

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            //Vector3 translation = new Vector3(0, Input.GetAxisRaw(AXIS_V) * this.speed * Time.deltaTime, 0);
            //this.transform.Translate(translation);
            _rigibody.velocity = new Vector2(0, Input.GetAxisRaw(AXIS_V) * this.speed);
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
