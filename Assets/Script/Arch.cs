using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that take care of the little Arch in front of the Castle of each player
public class Arch : MonoBehaviour
{

    public Animator animArch; // Animator of the Arch

    private int level = 1; // Level of the Castle associated with the Arch

    // When the Caslte Level Up, the Arch does it too and change his visual
    public void levelUp() {
        level++;
        animArch.SetInteger("Level", level);
    }
}
