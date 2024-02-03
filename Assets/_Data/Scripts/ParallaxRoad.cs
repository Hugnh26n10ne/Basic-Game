using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxRoad : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    [SerializeField] private bool infiniteHozirontal;
    [SerializeField] private bool infiniteVertical;

    private Transform camTransform;
    private Vector3 lastCameraPosition;

    private float textureUnitSizeX;
    private float textureUnitSizeY;


    void Start()
    {
        camTransform = Camera.main.transform;
        lastCameraPosition = camTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;

        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;

    }

    void FixedUpdate()
    {

        Vector3 deltaMovement = camTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0);
        lastCameraPosition = camTransform.position;
        if (infiniteHozirontal)
        {
            if (Mathf.Abs(camTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetPositionX = (camTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(camTransform.position.x + offsetPositionX, transform.position.y);
            }
        }
        if (infiniteVertical)
        {
            if (Mathf.Abs(camTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetPositionY = (camTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, camTransform.position.y - offsetPositionY);
            }
        }


    }
}
