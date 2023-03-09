using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "menuObj")]
public class ScObj : ScriptableObject
{
    [SerializeField] public float latitude = 45f;

    // Gestion du temps
    [SerializeField][Tooltip("Acc�l�re le temps !")] public float AccTemps = 500f;
    [SerializeField][Tooltip("Pas temporel: recalcul tout les param�tres.")] public float pasTemporel = 0.1f;


    public float TempsUniversel = 0f;
    [SerializeField][Tooltip("Jour initialis� au d�part simulation !")] public int jourAn= 1;
    public int jour = 1;
    [SerializeField][Tooltip("Heure initialis� au d�part simulation !")] public float heure= 0f;

    // Gestion de la croissance des plantes


    // public bool TicTac=false;

    public UnityEvent tictac;

}
