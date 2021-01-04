using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A character
/// </summary>
public class ScreenWrapping : MonoBehaviour
{
    // saved for efficiency
    float shipColliderHalfLength;
    float shipColliderHalfHeight;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{
        // save for efficiency
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        shipColliderHalfLength = collider.size.x / 2;
        shipColliderHalfHeight = collider.size.x / 2;

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
        if (position.x - shipColliderHalfLength > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenLeft - shipColliderHalfLength;
        }
        if (position.x + shipColliderHalfLength < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenRight + shipColliderHalfLength;
        }
        if (position.y - shipColliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenBottom - shipColliderHalfHeight;
        }
        if (position.y + shipColliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenTop + shipColliderHalfHeight;
        }
        transform.position = position;
    }
}
