using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using static SpringTeen.GameUtils;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public SkillResources skillRecources;
    public SkillManager skillManager;
    public PlayerSkills playerSkills;
    public void FindPrerequisites(Skills skill)
    {
        skillManager.SearchPrerequisites(skill);
    }
    public void LearSkills(int skillsLvl, bool allSkills)
    {
        skillManager.UnlockAllSkills(skillRecources, playerSkills, skillsLvl, allSkills);
    }
    public void ObtainSkillsNames(int skillsLvl, bool allSkills)
    {
        skillManager.GetAllSkillsNames(skillRecources, skillsLvl, allSkills);
    }
}
