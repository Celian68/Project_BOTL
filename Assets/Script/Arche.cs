using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arche : MonoBehaviour
{

    public Animator animArche;

    private int level = 1;

    public void levelUp() {
        level++;
        animArche.SetInteger("Level", level);
    }
}
