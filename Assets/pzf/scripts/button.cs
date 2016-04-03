using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

    static string lang_prefix = "en";

    string prev_lang_prefix = "en";
    AudioClip clip = null;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (GetComponent<CircleCollider2D>().OverlapPoint(wp))
            {
                var source = GetComponent<AudioSource>();
                var tag = gameObject.name.Split('_')[1];
                if (gameObject.name.StartsWith("lang"))
                {
                    lang_prefix = tag;
                }
                else
                {
                    if (prev_lang_prefix != lang_prefix)
                    {
                        prev_lang_prefix = lang_prefix;
                        if (!clip)
                        {
                            clip = Resources.Load("sounds/" + lang_prefix + "_" + tag) as AudioClip;
                        }
                        var tmp = source.clip;
                        source.clip = clip;
                        clip = tmp;
                    }
                }
                source.Play();
            }
        }
    }
}
