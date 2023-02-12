using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public bool IsAvailable { get; set; } = true;
    protected bool IsActive { get; set; }
    public virtual void Activate()
    {
        IsActive = true;
    }
    public virtual void Deactivate()
    {
        IsActive = false;
    }
    public bool GetIsActive() => IsActive;
}
