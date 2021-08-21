using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private EmojiData sEmojiData;

    private float _timer;
    void Update()
    {
        // this timer is only for testing purposes
        if (_timer > 1)
        {
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =
                sEmojiData.badEmojis[Random.Range(0, sEmojiData.badEmojis.Length)];
            
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
}
