using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveSelector : MonoBehaviour, ISelector
{
    [SerializeField] private List<Selectable> selectables; // List of selectable objects
    [SerializeField] private AudioClip[] hoverSounds; // Array of hover sounds
    [SerializeField] private AudioSource audioSource; // Audio source to play the sounds
    [SerializeField] private float threshold = 0.97f;

    private Transform _selection;
    private Transform _previousSelection;

    public void Check(Ray ray)
    {
        _selection = null;

        var closest = 0f;
        int selectedIndex = -1;

        for (int i = 0; i < selectables.Count; i++)
        {
            var vector1 = ray.direction;
            var vector2 = selectables[i].transform.position - ray.origin;

            var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

            if (lookPercentage > threshold && lookPercentage > closest)
            {
                closest = lookPercentage;
                _selection = selectables[i].transform;
                selectedIndex = i;
            }
        }

        // Play the hover sound if the selection changes
        if (_selection != _previousSelection && selectedIndex != -1)
        {
            PlayHoverSound(selectedIndex);
        }

        _previousSelection = _selection;
    }

    public Transform GetSelection()
    {
        return _selection;
    }

    private void PlayHoverSound(int index)
    {
        if (audioSource != null && hoverSounds != null && index >= 0 && index < hoverSounds.Length)
        {
            audioSource.PlayOneShot(hoverSounds[index]);
        }
    }
}