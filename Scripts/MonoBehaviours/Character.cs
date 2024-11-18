using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Clase genérica para todo tipo de personaje en el Juego.*/
public abstract class Character : MonoBehaviour
{
    public HitPoints hitPoints; //Puntos actuales de jugador
    public float maxHitPoints; //Máximos puntos a obtener
}
