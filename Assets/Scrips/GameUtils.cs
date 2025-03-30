using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using Unity.VisualScripting;

namespace SpringTeen
{
    public class GameUtils
    {
        public static void ApplyToAll<T>(List<T> list, Action<T> action)
        {
            if (list == null) return;
            foreach (var item in list)
            {
                action(item);
            }
        }
        public List<TResult> TransformAll<T, TResult>(List<T> list, Func<T, TResult> funcion)
        {
            List<TResult> result = new();
            foreach (var item in list)
            {
                result.Add(funcion(item));
            }
            return result;
        }
        public void TransformAllOut<T, TResult>(List<T> list, Func<T, TResult> funcion, out List<TResult> convertList)
        {
            convertList = new();
            foreach(var item in list)
            {
                convertList.Add(funcion(item));
            }
        }
        /*public void ApplyDamage<T>(T enemy, int damage) where T : class Enemies
        {
            enemy.ExcecuteEntity();
        }*/
    }
}

