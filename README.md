# Rich Presence Discord Unity3D

Grâce aux fichiers de ce projet Github vous allez pouvoir facilement mettre en place et configurer Rich Presence (Discord) dans un projet Unity 3D.

Voilà la vidéo tutoriel / mise en place : 
[![Alt text](https://www.tutounity.fr/upload/Unity3D58262465.jpg)](https://www.youtube.com/watch?v=l0RDqnHCO7o)

Une fois Rich Presence installé et configuré, lorsqu'un utilisateur lancera votre jeu / programme, les informations sur ce dernier apparaitront sur Discord de cette façon :

![alt text](https://www.tutounity.fr/upload/richpresence.jpg)

Avec ce projet exemple, vous êtes libre de choisir :
- le nom du jeu / programme affiché
- les détails affichés (exemple : "Dans le niveau 1")
- le statut affiché (exemple : "En ligne")
- les images affichées (grande et petite)
- l'utilisation ou non d'un chronomètre (calcul du temps de jeu)
- ... et encore bien d'autres choses !

## Exemples

Le script suivant permet de mettre à jour le champ "detail" (expliqué dans la vidéo)
```csharp
using UnityEngine;
using DiscordPresence;

public class Exemple : MonoBehaviour
{
    // Cette fonction permet de mettre à jour le champ detail
    public void Click()
    {
        PresenceManager.UpdatePresence(detail: "Rich presence mis à jour");
        Debug.Log("Champ << détails >> mis à jour");
    }
}
```

Le script suivant permet de démarrer un timer au moment où la fonction "ClickForTime()" est lue (non expliqué dans la vidéo tutoriel)
*On importe System pour avoir accès aux fonctions Time, on calcul ensuite la date et l'heure actuelle au format Unix (= le nombre de secondes qui se sont écoulées depuis le 01/01/1970) et on envoit ça au paramètre "start" de la fonction UpdatePresence()*
```csharp
using UnityEngine;
using DiscordPresence;
using System;

public class Exemple : MonoBehaviour
{
  // Cette fonction permet de lancer un timer au moment où elle est lue.
  // Donc si cette fonction a été lue il y a deux minutes il y aura marqué que le joueur joue depuis 2 minutes.
  public void ClickForTime()
  {
      DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      int cur_time = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
      PresenceManager.UpdatePresence(detail: "Rich presence mis à jour", start: cur_time);
  }
}
```

## Infos

► Si vous faites appel à ce répertoire GitHub pensez à me créditer dans votre jeu/programme. Ce n'est pas obligatoire mais c'est fortement apprécié.

► Petite précision : Si le message "Discord Ready" n’apparaît pas dans la console cela peut être dû à plusieurs choses :
- L'Application ID renseignée n'est pas valide (Fix : Remplacez le contenu du champ **Application ID** du script **Presence Manager** par l'ID de l'application précédemment créée via la [Dashboard developer de Discord](https://discordapp.com/developers/applications).
- Le pare-feu Windows a bloqué Discord (Fix : Ajoutez Discord dans les exceptions du pare-feu)
- Votre version de Unity n'est pas prise en compte par Rich Presence (Fix : Mettez à jour les DLL depuis le package RPC de Discord dispo [ICI](https://github.com/discordapp/discord-rpc))

Si vous appréciez mon travail et que vous souhaitez me supporter, vous pouvez effectuer une donation récurente ou unique sur ma page Tipeee : https://fr.tipeee.com/tuto-unity-fr
