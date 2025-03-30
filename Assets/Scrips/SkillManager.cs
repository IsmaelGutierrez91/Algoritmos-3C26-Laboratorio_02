using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using static UnityEditor.Experimental.GraphView.GraphView;
using JetBrains.Annotations;

public class SkillManager : MonoBehaviour
{
    //Busca los prerequisitos de cada habilidad
    [Button]
    public void SearchPrerequisites(Skills skill)
    {
        //Caso Base
        if(skill.PreRequisites.Count == 0)
        {
            print("Skill name: " + skill.SkillName);
            return;
        }
        print("Skill name: " + skill.SkillName + "/ Requires:");
        for (int i = 0; i < skill.PreRequisites.Count; i++)
        {
            SearchPrerequisites(skill.PreRequisites[i]);
        }
    }
    //Desbloquea habilidades especificas por un nivel o todas las habilidades
    [Button]
    public void UnlockAllSkills(SkillResources skillResources, PlayerSkills _Player, int skillsLvl, bool allSkills)
    {
        if (allSkills == true)
        {
            foreach (var skill in skillResources.AllSkillsList)
            {
                _Player.PlayerUnlockedSkills.Add(skill);
            }
            Debug.Log("Player learn all skills in the list");
        }
        else
        {
            int learnedSkills = 0;
            foreach (var skill in skillResources.AllSkillsList)
            {
                if (skill.SkillLevelRequiered == skillsLvl)
                {
                    _Player.PlayerUnlockedSkills.Add(skill);
                    learnedSkills++;
                }
            }
            Debug.Log("The player learn " + learnedSkills + " skills");
        }
    }
    //Imprime todos los nombres
    [Button]
    public void GetAllSkillsNames(SkillResources skillResources, int skillsLvl, bool allSkills)
    {
        if (allSkills == true)
        {
            foreach (var skill in skillResources.AllSkillsList)
            {
                Debug.Log("Skill: " + skill.name);
            }
        }
        else
        {
            foreach (var skill in skillResources.AllSkillsList)
            {
                if (skillsLvl == skill.SkillLevelRequiered)
                {
                    Debug.Log("Skill: " + skill.name);
                }
            }
        }
    }

}
