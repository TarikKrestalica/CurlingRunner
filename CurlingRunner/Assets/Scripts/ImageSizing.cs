using UnityEngine;

public class ImageSizing : MonoBehaviour
{
    private RectTransform imageTransform;
    private RectTransform parentTransform;

    private void Start()
    {
        imageTransform = this.transform.GetComponent<RectTransform>();
        parentTransform = this.transform.parent.transform.GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        imageTransform.sizeDelta = parentTransform.sizeDelta;
    }
}
