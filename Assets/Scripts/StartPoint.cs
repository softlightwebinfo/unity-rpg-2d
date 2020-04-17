using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string uuid;

    private PlayerController _player;
    private CameraFollow _camera;
    public Vector2 facingDirection = Vector2.zero;

    private void Start()
    {
        this._player = FindObjectOfType<PlayerController>();
        this._camera = FindObjectOfType<CameraFollow>();

        if (!this._player.nextUuid.Equals(this.uuid))
        {
            return;
        }

        this._player.transform.position = this.transform.position;
        this._camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this._camera.transform.position.z);
        this._player.lastMovement = facingDirection;
    }
}
