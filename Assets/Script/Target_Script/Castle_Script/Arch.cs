using UnityEngine;

// Class that take care of the little Arch in front of the Castle of each player
public class Arch : MonoBehaviour
{

    public Animator animArch; // Animator of the Arch

    // When the Caslte Level Up, the Arch does it too and change his visual
    public void LevelUp(int level) {
        animArch.SetInteger("Level", level);
    }
}
