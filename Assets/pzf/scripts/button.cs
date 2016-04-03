using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

    static string lang_prefix = "en";

    string prev_lang_prefix = "en";
    string postfix;

    bool skip = false;
    bool pressed = false;
    bool is_on = false;

    AudioClip clip = null;
    AudioSource source = null;
    Sprite sprite = null;
    SpriteRenderer rend = null;

    // Use this for initialization
    void Start ()
    {
        postfix = gameObject.name.Split('_')[1];
        skip = gameObject.name.StartsWith("lang");

        rend = GetComponent<SpriteRenderer>();
        sprite = Resources.Load<Sprite>("images/on_" + postfix);

        source = GetComponent<AudioSource>();
    }

    void SwapSprites (bool value)
    {
        if (is_on != value)
        {
            is_on = value;

            var tmp_sprite = rend.sprite;
            rend.sprite = sprite;
            sprite = tmp_sprite;
        }
    }

    void SwapClips ()
    {
        if (prev_lang_prefix != lang_prefix)
        {
            prev_lang_prefix = lang_prefix;

            if (!clip)
                clip = Resources.Load("sounds/" + lang_prefix + "_" + postfix) as AudioClip;

            var tmp_clip = source.clip;
            source.clip = clip;
            clip = tmp_clip;
        }
    }

	void OnGUI ()
    {
        if (Input.touchCount > 0)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            pressed = GetComponent<CircleCollider2D>().OverlapPoint(wp);
            SwapSprites(pressed);
            if (pressed)
            {
                if (skip)
                    lang_prefix = postfix;
                else
                    SwapClips();

                if (!source.isPlaying) {
                    source.timeSamples = 1000;
                    source.Play();
                }
            }
        }
    }
}
