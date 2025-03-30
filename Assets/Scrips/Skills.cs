using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "ScriptableObjects/Skills", order = 1)]
public class Skills : ScriptableObject
{
    [SerializeField] private string skillName;
    [SerializeField] private string description;
    [SerializeField] private int skillLevel;
    [SerializeField] private float cost;

    [SerializeField] private List<Skills> preRequisites = new List<Skills>();
    public string SkillName => skillName;
    public string Description => description;
    public int SkillLevelRequiered => skillLevel; //Nivel del jugador necesario
    public float Cost => cost; //Puntos de habilidad necesarios
    public List<Skills> PreRequisites => preRequisites; //Habilidades Necesarias
}
