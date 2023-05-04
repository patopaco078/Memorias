using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NieblaController : MonoBehaviour
{
    [SerializeField] Material Niebla2Shader;
    bool AlphaNieblaActivate = false;
    float AlphaNiebla = 0;
    Color startColor = Color.grey;
    Color endColor = Color.black;
    float transitionTime = 2.0f;

    private void Start()
    {
        //Niebla2Shader = GetComponent<Material>();
        Niebla2Shader.SetFloat("_alpha", AlphaNiebla);
    }

    private void Update()
    {
        if (AlphaNieblaActivate && AlphaNiebla < 1)
        {
            AlphaNiebla += Time.deltaTime;
            Niebla2Shader.SetFloat("_alpha", AlphaNiebla);
        }
        if (!AlphaNieblaActivate && AlphaNiebla > 0)
        {
            AlphaNiebla -= Time.deltaTime;
            Niebla2Shader.SetFloat("_alpha", AlphaNiebla);
        }
    }

    public void ActivateNiebla()
    {
        AlphaNieblaActivate = true;
    }
    public void DesactivateNiebla()
    {
        AlphaNieblaActivate = false;
    }

    public void BlackMode()
    {
        float t = Mathf.Clamp01(Time.time / transitionTime);
        Color lerpedColor = Color.Lerp(startColor, endColor, t);

        Niebla2Shader.SetColor("_ShadowColor", lerpedColor);
    }

}
