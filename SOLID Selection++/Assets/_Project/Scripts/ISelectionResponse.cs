using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface ISelectionResponse
{
    void OnSelect(Transform selection);
    void OnDeselect(Transform selection);
}
