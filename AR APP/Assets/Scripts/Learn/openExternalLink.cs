using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openExternalLink : MonoBehaviour
{
    public void openLink(string url)
    {
        Application.OpenURL(url);
    }
}
