using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage), typeof(LayoutElement))]
public class Item : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] private int _widthIncrements;
    [SerializeField] private int _heightIncrements;
    [SerializeField] private Color[] _colors;

    private RawImage _rawImage;
    private LayoutElement _layoutElement;

    public void Initialise()
    {
        _rawImage = GetComponent<RawImage>();
        _layoutElement = GetComponent<LayoutElement>();

        _rawImage.color = _colors[Random.Range(0, _colors.Length - 1)];

        int randomMultiplier = Random.Range(2, 10);
        _layoutElement.preferredWidth = randomMultiplier * _widthIncrements;
        _layoutElement.preferredHeight = randomMultiplier * _heightIncrements;
    }

    private void Start()
    {
        Initialise();
    }
}
