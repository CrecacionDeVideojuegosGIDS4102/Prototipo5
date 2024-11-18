using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Clase Player que hereda de Characters*/
public class Player : Character
{
    public HealthBar healthBarPrefab; //Referencia HealthBar Prefab
    private HealthBar healthBar; //Copia de referencia de HealthBar Prefab

    void Start()
    {
        // Instancia la barra de salud
        healthBar = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);

        // Asigna la referencia del jugador
        healthBar.Initialize(this); // Inicializa la barra de salud con el jugador
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
            if (hitObject != null)
            {
                Debug.Log("Nombre: " + hitObject.objectName);
                bool shouldDisappear = false;
                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN: //Moneda
                        shouldDisappear = true;
                        break;
                    case Item.ItemType.HEALTH://Barra de Salud
                        Debug.Log("Cantidad a Incrementar: " + hitObject.quantity);
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                }
                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false); //Desaparecer
                }
            }
        }
    }
    private bool AdjustHitPoints(int amount)
    {
        if (hitPoints.value < maxHitPoints) // no se puede exceder el máximo de puntos
        {
            hitPoints.value = hitPoints.value + amount;
            print("Ajustando Puntos: " + amount + ". Nuevo Valor: " + hitPoints.value);
            return true; //Fue modificado
        }
        return false; //No se modifica entonces el Heart no desaparece
    }
}