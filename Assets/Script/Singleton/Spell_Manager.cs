using Assets.Script.AssetsScripts.Enum;
using UnityEngine;

public class Spell_Manager : MonoBehaviour
{

    public GameObject zoneIndicator;
    public Camera mainCamera;
    private SpellData currentSpell;
    private int spellIndex;
    public static Spell_Manager _instance;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    void Update()
    {
        if (currentSpell != null)
        {
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            zoneIndicator.transform.position = new Vector3(Mathf.Clamp(worldPos.x, -5.5f, 35.5f), 0, 0);

            if (Input.GetMouseButtonDown(0))
            {
                CastCurrentSpell();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                CancelSpell();
            }
        }
    }

    public void ActivateSpell(int SpellIndex)
    {
        spellIndex = SpellIndex;
        currentSpell = LevelManager._instance.GetPlayerProgressionData(Team.Team1).GetSpellData(spellIndex);
        if (currentSpell.GetSpellStats(Level.Level1).isGlobal)
        {
            CastCurrentSpell();
        }
        else
        {
            zoneIndicator.SetActive(true);
        }
    }

    private void CastCurrentSpell()
    {
        if (currentSpell != null)
        {
            Vector3 spawnPos = zoneIndicator.transform.position + Vector3.up * 10f;
            Instantiate(currentSpell.SpellPrefab, spawnPos, Quaternion.identity);
            Army_Button._instance.StartSpellCooldown(spellIndex);
        }
        CancelSpell();
    }

    private void CancelSpell()
    {
        zoneIndicator.SetActive(false);
        currentSpell = null;
        spellIndex = -1;
    }
}
