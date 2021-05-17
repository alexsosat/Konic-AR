using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class players_photos : MonoBehaviour
{
    public Sprite[] photos;

    public Image user;
    public Image ia;

    void Start()
    {
        user.sprite = photos[Random.Range(0,photos.Length-1)];
        ia.sprite = photos[Random.Range(0, photos.Length - 1)];
    }

    
}
