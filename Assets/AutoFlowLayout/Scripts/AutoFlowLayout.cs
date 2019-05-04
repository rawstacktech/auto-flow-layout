using UnityEngine;
using UnityEngine.UI;

public class AutoFlowLayout : MonoBehaviour, ILayoutGroup
{
    [Header("Auto Flow Layout")]
    [SerializeField] private float _padding;
    [SerializeField] private float _itemSpacing;

    /// <summary>
    /// Second phase of the layout pass. Set the horizontal positions and 
    /// widths of child layout items.
    /// </summary>
    public void SetLayoutHorizontal()
    {
        // Child elements have no heights set at this point, so this is a no-op
        // in the vertical direction, but saves writing almost identical code.
        SetHorizontalAndVerticalLayout();
    }

    /// <summary>
    /// Fourth and final phase of the layout pass. Set the final positions and 
    /// sizes of child layout items.
    /// </summary>
    public void SetLayoutVertical()
    {
        SetHorizontalAndVerticalLayout();
    }

    private void SetHorizontalAndVerticalLayout()
    {
        // Take control over anchors

        float x = _padding;
        float y = -_padding;
        float currentRowHeight = 0;

        foreach (RectTransform childRectTransform in RectTransform)
        {
            ILayoutElement childElement = childRectTransform.GetComponent<ILayoutElement>();

            if (childElement == null)
            {
                // Don't try to layout something who prefferred size cannot be queried
                continue;
            }

            // Force control over anchors and pivot of the children
            childRectTransform.anchorMin = new Vector2(0, 1);
            childRectTransform.anchorMax = new Vector2(0, 1);
            childRectTransform.pivot = new Vector2(0, 1);

            if (x + childElement.preferredWidth + _padding > RectTransform.rect.width)
            {
                // This item will not fit on the current line, so continue
                // layout on the second line
                x = _padding;
                y -= currentRowHeight + _itemSpacing;
                currentRowHeight = 0;
            }

            childRectTransform.sizeDelta = new Vector2(
                childElement.preferredWidth, childElement.preferredHeight);
            //childRectTransform.localPosition = new Vector3(x, y);
            childRectTransform.anchoredPosition = new Vector3(x, y);

            x += childElement.preferredWidth + _itemSpacing;
            if (childElement.preferredHeight > currentRowHeight)
            {
                currentRowHeight = childElement.preferredHeight;
            }
        }
    }

    private RectTransform RectTransform
    {
        get
        {
            return GetComponent<RectTransform>();
        }
    }
}
