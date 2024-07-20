using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLbuttons : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenWebsiteURL ()
    {
        Application.OpenURL("https://www.ANTIelixir.com");
    }

    public void OpenAmazonURL()
    {
        Application.OpenURL("https://www.amazon.com/dp/B09KSC3VST");
    }
}
