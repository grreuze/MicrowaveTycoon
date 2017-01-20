using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DraggableObject : MonoBehaviour {
    
    /// <summary>
    /// Returns whether or not the object is currently held by the player.
    /// </summary>
            
    public bool isHeld;
    
	void Update () {
		if (isHeld) MoveToMousePosition();
	}

    void MoveToMousePosition() {
        transform.position = Input.mousePosition;
    }

    void OnMouseOver() {
        isHeld = Input.GetMouseButton(0);
    }

    void OnMouseExit() {
        isHeld = !Input.GetMouseButton(0);
    }

}
