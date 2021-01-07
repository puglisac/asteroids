using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A character
/// </summary>
public class ScreenWrapping : MonoBehaviour
{
    // saved for efficiency
    float colliderHalfLength;
    float colliderHalfHeight;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{
        // save for efficiency
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        colliderHalfLength = collider.size.x / 2;
        colliderHalfHeight = collider.size.x / 2;

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void OnBecameInvisible()
	{

        Wrap();
	}

    /// <summary>
    /// Clamps the character in the screen
    /// </summary>
    void Wrap()
    {
        // clamp position as necessary
        Vector3 position = transform.position;
        if (position.x - colliderHalfLength > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenLeft - colliderHalfLength;
        }
        if (position.x + colliderHalfLength < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenRight + colliderHalfLength;
        }
        if (position.y - colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenBottom - colliderHalfHeight;
        }
        if (position.y + colliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenTop + colliderHalfHeight;
        }
        transform.position = position;
    }
}
