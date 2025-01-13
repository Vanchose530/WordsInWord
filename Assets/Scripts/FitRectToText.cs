using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class FitRectToText : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private RectTransform influencedRect;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Image textOuterImage;

    //private void OnValidate()
    //{
    //    if (influencedRect == null)
    //        influencedRect = GetComponent<RectTransform>();
    //    if (textMeshPro == null)
    //        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    //}

    private void Update()
    {
        if (influencedRect != null)
        {
            if (textMeshPro.text.Length > 0)
            {
                textMeshPro.ForceMeshUpdate();
                Vector2 size = textMeshPro.GetRenderedValues();
                influencedRect.sizeDelta = size;

                if (textOuterImage != null)
                    textOuterImage.color = Color.white;
            }
            else
            {
                influencedRect.sizeDelta = new Vector2(0, 0);

                if (textOuterImage != null)
                    textOuterImage.color = Color.clear;
            }
        }
    }
}
