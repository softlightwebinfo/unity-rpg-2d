using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string uuid;
    public string newPlaceName = "New Scene Name Here!!!";
    public bool needsClick = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.Teleport(other.gameObject.tag);
    }

    private void Teleport(string name)
    {
        if (name != "Player") return;

        if (!needsClick || (needsClick && Input.GetMouseButtonDown(0)))
        {
            if (needsClick)
            {
                SFXManager.SharedInstance.PlaySFX(SFXType.SoundType.KNOCK);
            }

            FindObjectOfType<PlayerController>().nextUuid = this.uuid;
            SceneManager.LoadScene(this.newPlaceName);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        this.Teleport(other.gameObject.tag);
    }
}
