using UnityEngine;
using UnityEngine.Rendering.PostProcessing;




// FOR FUTURE USE OF BEER GOGGLES!

// This will adjust the Post-process Volume "Weight" to add a blur effect

// Call IncreaseBlurCount() from anywhere to achieve this
// or call DecreaseBlurCount()



public class BlurEffect : MonoBehaviour
{
    public PostProcessVolume blurVolume;
    public int blurCount = 0;


    void Update()
    {

        if (blurCount == 0)
        {
            blurVolume.weight = 0;
        }
        if (blurCount == 1)
        {
            blurVolume.weight = .4f;
        }
        if (blurCount == 2)
        {
            blurVolume.weight = .6f;
        }
        if (blurCount == 3)
        {
            blurVolume.weight = .75f;
        }
        if (blurCount == 4)
        {
            blurVolume.weight = .8f;
        }
    }
    public void IncreaseBlurCount()
    {
        if (blurCount < 4)
        {
            blurCount++;
        }
    }
    public void DecreaseBlurCount()
    {
        if (blurCount > 0)
        {
            if (blurCount == 1)
            {
                blurCount = 0;
            }
            else
            {
                blurCount -= 2;
            }
        }
    }
}
