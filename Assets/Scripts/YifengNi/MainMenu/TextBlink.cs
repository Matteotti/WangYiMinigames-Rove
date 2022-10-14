using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBlink : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    public Image img;

    public void Start()
    {
        StartCoroutine(FadeImage(true));
    }
    

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        while (true)
        {
            if (fadeAway)
            {
                // loop over 1 second backwards
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    img.color = new Color(1, 1, 1, i);

                    yield return null;
                }
                fadeAway = false;
            }
            // fade from transparent to opaque
            else
            {
                // loop over 1 second
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    img.color = new Color(1, 1, 1, i);
                    yield return null;
                }
                fadeAway = true;
            }
        }
    }

}
