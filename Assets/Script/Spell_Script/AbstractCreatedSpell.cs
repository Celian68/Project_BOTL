using System.Collections.Generic;
using BOTL.Data;
using UnityEngine;

public abstract class AbstractCreatedSpell : AbstractSpell
{
    public void Initialize(SpellData data) {
        this.data = data;
    }
}