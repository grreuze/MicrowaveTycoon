﻿using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DraggableObject : MonoBehaviour {
    
    /// <summary>
    /// Returns whether or not the object is currently held by the player.
    /// </summary>
    public bool isHeld;

	void Update () {
		if (isHeld) MoveToMousePosition();
        if (!Input.GetMouseButton(0)) {
            isHeld = false;
            Mouse.holding = null;
        }
    }

    public virtual void MoveToMousePosition() {
        float screenDepth = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenDepth));
    }
    
    void OnMouseOver() {
        if (!Mouse.holding) {
            isHeld = Input.GetMouseButton(0);
            if (isHeld) Mouse.holding = gameObject;
        }
    }
}
