using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelector
{
    void Check(Ray ray);
    Transform GetSelection();
}