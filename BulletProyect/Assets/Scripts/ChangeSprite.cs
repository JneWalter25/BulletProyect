using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite[] sprites; // Array de sprites
    public float timeBetweenSprites = 0.5f; // Tiempo de espera entre cada cambio de sprite

    private int currentSpriteIndex = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("ChSprite", timeBetweenSprites, timeBetweenSprites);
    }

    void ChSprite()
    {
        currentSpriteIndex++;
        if (currentSpriteIndex >= sprites.Length)
        {
            currentSpriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }
}
