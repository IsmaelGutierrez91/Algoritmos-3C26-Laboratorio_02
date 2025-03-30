using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using JetBrains.Annotations;

[CreateAssetMenu(menuName = "ScriptableObjects/skillsResources", order = 2)]
public class SkillResources : ScriptableObject
{
    [Header("Skill list")]
    [SerializeField]List<Skills> allSkillsList = new List<Skills>();
    public List<Skills> AllSkillsList => allSkillsList;
    //Ordena la lista por el nivel de habilidad de menor a mayor
    [Button]
    public void OrderListDownToTop()
    {
        for (int i = 0; i < allSkillsList.Count; i++)
        {
            for (int j = i + 1; j < allSkillsList.Count; j++)
            {
                if (allSkillsList[j].SkillLevelRequiered < allSkillsList[i].SkillLevelRequiered)
                {
                    Skills temporalSkill = allSkillsList[j];
                    allSkillsList[j] = allSkillsList[i];
                    allSkillsList[i] = temporalSkill;
                }
            }
        }
        Debug.Log("The list was ordered");
    }
    //Ordena la lista por el nivel de habilidad de mayor a menor
    [Button]
    public void OrderListTopToDown()
    {
        for (int i = 0; i < allSkillsList.Count; i++)
        {
            for (int j = i + 1; j < allSkillsList.Count; j++)
            {
                if (allSkillsList[j].SkillLevelRequiered > allSkillsList[i].SkillLevelRequiered)
                {
                    Skills temporalSkill = allSkillsList[j];
                    allSkillsList[j] = allSkillsList[i];
                    allSkillsList[i] = temporalSkill;
                }
            }
        }
        Debug.Log("The list was ordered");
    }
}
