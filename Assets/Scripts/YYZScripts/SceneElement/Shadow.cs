using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public SpriteRenderer character, shadow;
    void Update()
    {
        if(shadow.sprite != character.sprite)
            shadow.sprite = character.sprite;
    }
}
