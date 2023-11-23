using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pecas2_Quebracabeca : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 startPosition;
    public Collider2D alvo;
    public bool toaqui = false;

    private void Update()
    {
        if (Input.touchCount > 0) // Verificar se há pelo menos um toque na tela
        {
            Touch touch = Input.GetTouch(0); // Obter o primeiro toque na tela

            if (touch.phase == TouchPhase.Began) // Verificar se o toque começou
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                if (GetComponent<Collider2D>().OverlapPoint(touchPosition)) // Verificar se o toque começou na peça
                {
                    isDragging = true;
                    startPosition = transform.position;
                }
            }

            if (touch.phase == TouchPhase.Ended && isDragging) // Verificar se o toque terminou
            {
                isDragging = false;

                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D[] hitColliders = Physics2D.OverlapPointAll(touchPosition); // Verificar todos os colliders tocados

                foreach (Collider2D collider in hitColliders)
                {
                    if (collider == alvo) // Verificar se o collider tocado é o alvo
                    {
                        toaqui = true;
                        transform.position = alvo.gameObject.transform.position; // Se estiver, fixar a posição
                        this.transform.localScale = alvo.transform.localScale;
                        GameController_QuebraCabeca.contFigures--;
                        this.enabled = false;
                        return; // Sair do loop e encerrar a função
                    }
                }

                toaqui = false;
                transform.position = startPosition; // Se não estiver, voltar para a posição inicial
            }

            if (touch.phase == TouchPhase.Moved && isDragging) // Verificar se o toque está em movimento
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = transform.position.z; // Manter a mesma profundidade da peça
                transform.position = touchPosition; // Atualizar a posição da peça com a posição do toque
            }
        }
    }
}
