using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocused = false;
    bool hasInteracted = false;
    Transform player;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact()
    {
        // This methode is meant to be overriden
        Debug.Log("INTERACTING WITH " + transform.name);

    }

    private void Update()
    {
        if (isFocused && !hasInteracted)
        {
            Interact();
            Debug.Log("INTERACT");
            hasInteracted = true;
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OndeFocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }

}
