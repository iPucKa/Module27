using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCondition : DestroyCondition
{
    private bool _isDead;

    public bool FitCondition => _isDead;
}
