using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using JetBrains.Annotations;

public class PlayerSkills : MonoBehaviour
{
    [Header("Skill learn skills system")]
    public float learnSkillPoints = 100f;
    [SerializeField]List<Skills> playerUnlockedSkills;
    public List<Skills> PlayerUnlockedSkills => playerUnlockedSkills;

    [Header("Player Lvl System")]
    public int playerLevel = 1;
    [SerializeField] float currentXP;
    [SerializeField] float requiredXP;

    //Detecta si el jugador posee cierta habilidad
    public bool PlayerHasSkill(Skills skill)
    {
        return playerUnlockedSkills.Contains(skill);
    }
    //Detecta si el jugador cumple las condiciones para obtener alguna habilidad
    private bool CanLearnSkill(Skills skill)
    {
        foreach (var prereq in skill.PreRequisites)
        {
            if (!PlayerHasSkill(prereq))
            {
                return false;
            }
        }
        return playerLevel >= skill.SkillLevelRequiered;
    }
    //Sirve para que el jugador aprenda una nueva habilidad
    [Button]
    public void LearnSkill(Skills skill)
    {
        if (playerUnlockedSkills.Contains(skill))
        {
            Debug.Log("The player kwon this skill"); //El jugador ya conoce esa habilidad
        }
        else
        {
            if (CanLearnSkill(skill))
            {
                if (learnSkillPoints < skill.Cost)
                {
                    Debug.Log("Not enough skill points"); //no hay suficientes puntos de habilidad
                }
                else
                {
                    playerUnlockedSkills.Add(skill);
                    learnSkillPoints = learnSkillPoints - skill.Cost;
                    Debug.Log("New learn skill: '" + skill.name + "'"); //Se ha aprendido una nueva habilidad
                }
            }
            else
            {
                Debug.Log("not all requirements are met"); //no se cumplen todos los requisitos
            }
        }

    }
    //Sube de nivel al jugador
    [Button]
    public void PlayerLvlUp(float xpToAdd)
    {
        currentXP += xpToAdd;
        while (currentXP >= requiredXP)
        {
            learnSkillPoints = learnSkillPoints + 10;
            playerLevel++;
            currentXP -= requiredXP;
        }
        Debug.Log("The player level is: " + playerLevel);
    }
}
