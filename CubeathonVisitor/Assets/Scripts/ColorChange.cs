using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ColorChange")]
public class ColorChange : PowerupEffect
{
    public int change;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().color = change;
        target.GetComponent<PlayerMovement>().needColorChange = true;
    }
}
