using UnityEngine;

public class Key : MetallicObject {

    new SpriteRenderer renderer;
    public Sprite normalSprite, insertedSprite;

    public bool inserted {
        set {
            if (!renderer) renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = value ? insertedSprite : normalSprite;
        }
    }

}
