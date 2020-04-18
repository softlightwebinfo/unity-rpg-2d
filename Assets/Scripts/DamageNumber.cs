using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public float damageSpeed;
    public float damagePoints;
    public Text damageText;

    public Vector2 direction = new Vector2(0, 1);
    public float timeToChangeDirection = 1.0f;
    public float timeToChangeDirectionCounter = 1.0f;
    public bool isMoveDirection = false;

    void Update()
    {
        timeToChangeDirectionCounter -= Time.deltaTime;
        if (isMoveDirection && (timeToChangeDirectionCounter < timeToChangeDirection / 2))
        {
            direction *= -1;
            timeToChangeDirectionCounter += timeToChangeDirection;
        }
        this.damageText.text = damagePoints.ToString("f2");
        this.transform.position = new Vector3(
            this.transform.position.x + direction.x * damageSpeed * Time.deltaTime,
            this.transform.position.y + direction.y * damageSpeed * Time.deltaTime,
            this.transform.position.z);
        this.transform.localScale = this.transform.localScale * (1 - Time.deltaTime / 10);
    }
}
