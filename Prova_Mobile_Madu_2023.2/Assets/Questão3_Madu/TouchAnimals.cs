using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchAnimals : MonoBehaviour
{
     public Text textoAnimals;
    private Animal lastTouchedAnimal; // Rastreia o último animal tocado

    private void Start()
    {
        textoAnimals.text = "Listen the Animals";
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D hitCollider = Physics2D.OverlapPoint(touchPosition);

                if (hitCollider != null)
                {
                    Animal newTouchedAnimal = hitCollider.GetComponent<Animal>();

                    if (newTouchedAnimal != null)
                    {
                        // Se um animal foi tocado anteriormente, pare seu som
                        if (lastTouchedAnimal != null)
                        {
                            lastTouchedAnimal.StopAnimalSound();
                        }

                        // Reproduza o som associado ao novo animal
                        newTouchedAnimal.PlayAnimalSound();

                        // Atualize o texto na tela com o nome do novo animal
                        textoAnimals.text = newTouchedAnimal.GetAnimalName();

                        // Atualize o animal tocado mais recentemente
                        lastTouchedAnimal = newTouchedAnimal;
                    }
                }
                else
                {
                    textoAnimals.text = " ";
                }
            }
        }
    }
}
