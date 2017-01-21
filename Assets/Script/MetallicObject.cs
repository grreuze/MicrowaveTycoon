
public class MetallicObject : DraggableObject {

    Plat parent;

    void Start() {
        parent = GetComponentInParent<Plat>();
        parent.hasMetallicObject = true;
    }

    public override void MoveToMousePosition() {
        base.MoveToMousePosition();
        transform.parent = null;
        parent.hasMetallicObject = false;
    }

}
