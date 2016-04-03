using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

    static string lang_prefix = "en";

    string prev_lang_prefix = "en";
    string postfix;
    bool skip = false;
    AudioClip clip = null;
    AudioSource source = null;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        postfix = gameObject.name.Split('_')[1];
        skip = gameObject.name.StartsWith("lang");
    }
	
	void OnGUI () {
        if (Input.touchCount > 0)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (GetComponent<CircleCollider2D>().OverlapPoint(wp))
            {
                if (skip)
                {
                    lang_prefix = postfix;
                }
                else
                {
                    if (prev_lang_prefix != lang_prefix)
                    {
                        prev_lang_prefix = lang_prefix;
                        if (!clip)
                        {
                            clip = Resources.Load("sounds/" + lang_prefix + "_" + postfix) as AudioClip;
                        }
                        var tmp = source.clip;
                        source.clip = clip;
                        clip = tmp;
                    }
                }
                if (!source.isPlaying) {
                    source.timeSamples = 3000;
                    source.Play();
                }
            }
        }
    }
}
