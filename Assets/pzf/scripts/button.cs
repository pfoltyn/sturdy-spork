using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

    static string lang_prefix = "en";
    static string prev_lang_prefix = "en";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0) {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (GetComponent<Collider2D>().OverlapPoint(wp)) {
                var source = GetComponent<AudioSource>();
                source.clip.name = source.clip.name.Replace(prev_lang_prefix, lang_prefix);
                source.Play();
                if (gameObject.name.StartsWith("lang")) {
                    prev_lang_prefix = lang_prefix;
                    lang_prefix = gameObject.name.Split('_')[1];
                }
            }
        }
    }
}
