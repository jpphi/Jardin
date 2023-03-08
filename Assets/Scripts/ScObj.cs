using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "menuObj")]
public class ScObj : ScriptableObject
{
    [SerializeField][Tooltip("Accélère le temps !")] public float AccTemps = 1f;

    // Gestion du temps

    public float TempsUniversel = 0f;
    [SerializeField][Tooltip("Jour initialisé au départ simulation !")] public int jourAn;
    public int jour = 0;
    [SerializeField][Tooltip("Heure initialisé au départ simulation !")] public float heure;

}
