
public class OutOfOrderPostIt : DraggableObject {

    MicroWave parent;

    void Start() {
        parent = GetComponentInParent<MicroWave>();
        parent.outOfOrder = true;
    }

    public override void MoveToMousePosition() {
        base.MoveToMousePosition();
        transform.parent = null;
        parent.outOfOrder = false;
    }

}
