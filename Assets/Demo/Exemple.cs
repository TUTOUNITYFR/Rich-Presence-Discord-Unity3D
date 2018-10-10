using UnityEngine;
using DiscordPresence;

public class Exemple : MonoBehaviour
{
    public void Click()
    {
        PresenceManager.UpdatePresence(detail: "Rich presence mis à jour");
        Debug.Log("Champ << détails >> mis à jour");
    }
}