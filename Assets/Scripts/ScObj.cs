using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "menuObj")]
public class ScObj : ScriptableObject
{
    [SerializeField][Tooltip("Acc�l�re le temps !")] public float AccTemps = 1f;

    public float TempsUniversel = 0f;

    public float jour;

}
