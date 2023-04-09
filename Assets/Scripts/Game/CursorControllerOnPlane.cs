using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControllerOnPlane : MonoBehaviour
{
    [SerializeField] Texture2D shootCursor;
    [SerializeField] Texture2D normalCursor;

    Texture2D shootCurserCopy;
    Texture2D normalCursorCopy;
    private void Start() {
        shootCurserCopy = shootCursor;
        normalCursorCopy = normalCursor;

        Cursor.SetCursor(normalCursorCopy,new Vector2(normalCursorCopy.width/2, normalCursorCopy.height / 2), CursorMode.ForceSoftware);
    }

    private void OnMouseEnter() {
        Cursor.SetCursor(shootCurserCopy, new Vector2(shootCurserCopy.width /2, shootCurserCopy.height/2), CursorMode.ForceSoftware);
    }
    private void OnMouseExit() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (var hit in hits)
        {
            //Debug.Log(hit.collider.name);
            if(hit.collider == GetComponent<Collider>())
            {
                return;
            }
        }
        
        Cursor.SetCursor(normalCursorCopy, Vector2.zero, CursorMode.ForceSoftware);
    }
}
