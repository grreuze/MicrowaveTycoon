
public class OutOfOrderPostIt : DraggableObject {

    MicroWave parent;
    Avatar avatar;
    
    public override void MoveToMousePosition() {
        base.MoveToMousePosition();

        parent = GetComponentInParent<MicroWave>();
        if (parent) parent.outOfOrder = false;

        avatar = GetComponentInParent<Avatar>();
        if (avatar) avatar.arm.block = false;

        transform.parent = null;
    }

}
