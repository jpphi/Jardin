using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "menuObj")]
public class ScObj : ScriptableObject
{
    [SerializeField][Tooltip("Acc�l�re le temps !")] public float AccTemps = 1f;

    // Gestion du temps

    public float TempsUniversel = 0f;
    [SerializeField][Tooltip("Jour initialis� au d�part simulation !")] public int jourAn;
    public int jour = 0;
    [SerializeField][Tooltip("Heure initialis� au d�part simulation !")] public float heure;

}
