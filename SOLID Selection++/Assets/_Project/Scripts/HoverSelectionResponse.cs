using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class HoverSelectionResponse : MonoBehaviour, ISelectionResponse
{
    private Vector3 originalPosition;
    public GameObject particles;

    public void OnSelect(Transform selection)
    {
        if (originalPosition == Vector3.zero)
        {
            originalPosition = selection.position;
            particles.transform.position = originalPosition;
        }

        selection.position = new Vector3(selection.position.x, originalPosition.y, selection.position.z);
        particles.SetActive(true);
    }

    public void OnDeselect(Transform selection)
    {
        selection.position = originalPosition;
        originalPosition = Vector3.zero;
        particles.transform.position = Vector3.zero;
        particles.SetActive(false);
    }
}
