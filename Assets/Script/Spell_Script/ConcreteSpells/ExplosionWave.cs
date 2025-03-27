using System.Collections.Generic;
using Assets.Script.AssetsScripts.Enum;
using UnityEngine;

public class ExplosionWaveBehavior : AbstractCreatedSpell
{
    readonly float _maxScaleCoef = 5f;          // L'échelle maximale (considérée comme le rayon effectif)
    readonly float _duration = 1f;        // Temps d'expansion avant destruction
    readonly float _maxKnockbackForce = 30f; // Force maximale du knockback

    float _currentTime = 0f;
    float _initialScale;
    readonly List<Collider2D> _ennmiesTouched = new();

    void Start()
    {
        // On considère que l'échelle initiale (x) est celle avec laquelle l'onde démarre (ex. 1 ou une valeur faible)
        _initialScale = transform.localScale.x;
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        float expansionFactor = _currentTime / _duration;
        // Calculer la nouvelle échelle de façon linéaire entre l'échelle initiale et maxScale
        float newScale = Mathf.Lerp(_initialScale, GetMaxScale(), expansionFactor);
        transform.localScale = new Vector3(newScale, newScale, 1f);

        if (GetMaxScale() <= transform.localScale.x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Appliquer le knockback uniquement aux unités (selon leur tag par exemple)
        if ((other.CompareTag("Team1") || other.CompareTag("Team2")) && !_ennmiesTouched.Contains(other))
        {
            _ennmiesTouched.Add(other);
            ApplyKnockback(other);
        }
    }

    void ApplyKnockback(Collider2D enemy)
    {
        if (enemy != null)
        {
            // Calcul de la force décroissante
            float force = _maxKnockbackForce * ((GetMaxScale() - transform.localScale.x) / (GetMaxScale() - _initialScale));
            force = Mathf.Clamp(force, 0, _maxKnockbackForce);

            // Direction initiale (point d'impact à l'ennemi)
            Vector2 direction = (enemy.transform.position - transform.position).normalized;

            // Ajouter une inclinaison vers le haut
            direction += new Vector2(0, 0.4f);
            direction.Normalize();

            StartTrigger(TriggerType.OnEffect, new EffectContext(new Dictionary<EffectType, AbstractEffectParam> {
            { EffectType.Push, new MovementEffectParam(force, direction, transform, new List<Transform>{enemy.transform}) }
        }));
        }
    }

    float GetMaxScale()
    {
        return _maxScaleCoef * _initialScale;
    }
}
