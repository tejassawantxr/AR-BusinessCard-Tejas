using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLOpener : MonoBehaviour
{
    // Start is called before the first frame update
   public void OpenUrl(string url) => Application.OpenURL(url);
}
