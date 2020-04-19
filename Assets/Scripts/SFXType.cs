using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXType : MonoBehaviour
{
    public enum SoundType
    {
        ATTACK, DIE, HIT, KNOCK, Q_START, Q_END
    }

    public SoundType type;
}
