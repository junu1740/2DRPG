using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
  public UnityEngine.UI.Image FadeImage;
    public Text FadeText;

    private float FadeAlpha = 1f;

    private AudioSource bgm;

    private void Start()
    {
        bgm = GetComponent<AudioSource>();
        FadeImage.gameObject.SetActive(true);         
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        while (FadeAlpha >= 0)
        {
            FadeAlpha -= 0.03F;
            FadeImage.color =new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, FadeAlpha);
            FadeText.color = new Color(FadeText.color.r, FadeText.color.g, FadeText.color.b, FadeAlpha);

            yield return new WaitForSeconds(0.02f);
        }
        bgm.Play();
    }
}
