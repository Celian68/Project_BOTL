using UnityEngine;
using BOTL.Enum;
using System.Collections;

// Class that take care of the little Arch in front of the Castle of each player
public class Arch : MonoBehaviour
{

    public Animator animArch; // Animator of the Arch
    Coroutine healingCoroutine;

    // When the Caslte Level Up, the Arch does it too and change his visual
    public void LevelUp(int level) {
        animArch.SetInteger("Level", level);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AbstractUnit unit = collision.GetComponent<AbstractUnit>();
        if (unit != null && unit.GetUnitClass() == UnitClass.Hero && unit.GetTeam() == transform.parent.GetComponent<Castle>().GetTeam())
        {
            healingCoroutine = StartCoroutine(HealingOverTime(10, 1, collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AbstractUnit unit = collision.GetComponent<AbstractUnit>();
        if (unit != null && unit.GetUnitClass() == UnitClass.Hero && unit.GetTeam() == transform.parent.GetComponent<Castle>().GetTeam())
        {
            StopCoroutine(healingCoroutine); // Arrête la coroutine de soin
        }
    }

    private IEnumerator HealingOverTime(int amout, float time, Collider2D collision)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            collision.GetComponent<AbstractUnit>().Heal(amout);
            yield return new WaitForSeconds(time);
        }
    }
}
