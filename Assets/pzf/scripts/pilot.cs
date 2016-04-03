using UnityEngine;
using System.Collections;

public class pilot : MonoBehaviour {
    void Start () {
        SpriteRenderer sr = (SpriteRenderer)GetComponent("Renderer");

        // Get stuff
        double width = sr.sprite.bounds.size.x;
        double worldScreenHeight = Camera.main.orthographicSize * 2.0;
        double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Resize
        transform.localScale = new Vector2(1, 1) * (float)(worldScreenWidth / width);
    }
}
