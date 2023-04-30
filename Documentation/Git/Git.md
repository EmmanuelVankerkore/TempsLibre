<head>
<style>
#titleMain {color:#808080; font-size:40px; font-weight:bold; font-family:"Cambria"}
#titleSub {color:#677179; font-size:24px; font-weight:bold; font-family: "Verdana"; margin-top:30px; margin-bottom:25px}
#titleSub2 {color:#563C5C; font-size:20px; font-weight:bold; margin-bottom:20px}
#com {color:#FF00FF; font-size:18px "Carnivalee Freakshow"}
#par {color:#32CD32; font-size:18px "Carnivalee Freakshow"}
#val {color:#87CEFA; font-size:18px "Carnivalee Freakshow"}
#not {color:#1E90FF; font-size:18px "Carnivalee Freakshow"}
</style>
</head>

<!-- ```css
<head>
<style>
#bleu {
color:#87CEFA }
</style>
</head>
``` -->

# <div id="titleMain">Prise en main de Git</div>

## <div id="titleSub">0. Préparer son git avant la première utilisation</div>

### <div id="titleSub2">Contexte:</div>

Après avoir installé Git en local

### <div id="titleSub2">Commande:</div>

<span id="com">git config</span> 
<span id="par"> --global user.name </span>
<span id="val">"nom_d_utilisateur"</span>
<br>
<span id="com">git config</span> 
<span id="par"> --global user.email </span>
<span id="val">"adresse_email"</span>

### <div id="titleSub2">Résultat:</div>

Vous pouvez dès à présent commencer à utiliser toutes les fonctionnalité de Git.

## <div id="titleSub">1. Initialiser un projet git</div>

<span id="com">git init</span> 

## <div id="titleSub">2. Définir les données à ajouter</div>

<span id="com">git add </span>
<span id="val">*</span>


## <div id="titleSub">3. Réaliser les commit des données</div>

<span id="com">git commit </span>
<span id="par">-m </span>
<span id="val">"nom_du_commit"</span>

## <div id="titleSub">4. Afficher le statut actuel</div>

<span id="com">git status</span>

## <div id="titleSub">5. Afficher le nom de la branche actuelle</div>

<span id="com">git branch</span>

## <div id="titleSub">6. Création d'une nouvelle branche</div>

<span id="com">git checkout </span>
<span id="par">-b </span>
<span id="val">"nom_de_la_nouvelle_branche"</span>

## <div id="titleSub">7. Se positionner sur une branche existante</div>

<span id="com">git checkout </span>
<span id="val">"nom_de_la_branche_existante"</span>

## <div id="titleSub">8. Revenir à l'état du dernier commit</div>

### <div id="titleSub2">Contexte:</div>

Le dernier commit réalisé se nomme "commit1", des modifications ont été réalisées et sauvegardées sans être commité et l'on souhaite revenir à l'état du dernier commit "commit1.

### <div id="titleSub2">Commande:</div>

<span id="com">git stash </span>

### <div id="titleSub2">Résultat:</div>

Toutes les modifications enregistrées après le commit "commit1" ont été annulé (n'existent plus).

## <div id="titleSub">9. Annuler le point 8</div>

<span id="com">git stash </span>
<span id="par">pop</span>

## <div id="titleSub">10. Renommer la branche sur laquelle on est actuellement</div>

<span id="com">git branch </span>
<span id="par">-M </span>
<span id="val">"nom_de_la_nouvelle_branche"</span>

## <div id="titleSub">11. Définir un accès vers un espace GitHub</div>

<span id="com">git remote </span>
<span id="par">add </span>
<span id="val">"nom_de_la_telecommande" "url_GitHub"</span>

## <div id="titleSub">12. Pousser ses modification sur GitHub</div>

<span id="com">git push </span>
<span id="par">-u </span>
<span id="val">"nom_de_la_telecommande" "nom_de_la_branche_GitHub"</span>

<span id="par">-u </span>
<span id="not">permet d'initialiser un stream qui servira de référence pour chaque commandes pull et push.</span>

## <div id="titleSub">13. Récupèrer l'intégration d'un répository GitHub</div>

<span id="com">git clone </span>
<span id="val">"url_GitHub"</span>

## <div id="titleSub">14. Récupérer les données d'une branche spécifique sur un répository GitHub</div>

<span id="com">git pull </span>
<span id="val">"nom_de_la_telecommande" "nom_de_la_branche_GitHub"</span>

## <div id="titleSub">15. Fusionner avec une tierce branche en local</div>

<span id="com">git merge </span>
<span id="val">"nom_de_la_branche"</span>

## <div id="titleSub">16. Lister l'ensemble des télécommandes</div>

<span id="com">git remote </span>

## <div id="titleSub">17. Supprimer une télécommande</div>

<span id="com">git remote rm </span>
<span id="val">"nom_de_la_télécommande"</span>

## <div id="titleSub">18. Redéfinir une télécommande</div>

<span id="com">git remote</span>
<span id="par">set-url</span>
<span id="val">"nom_d_une_télécommande" "URL_github"</span>

## <div id="titleSub">19. Afficher les informations d'une télécommande</div>

<span id="com">git remote</span>
<span id="par">show</span>
<span id="val">"nom_d_une_télécommande"</span>

## <div id="titleSub">20. Supprimer du repository local un fichier qui n'est physiquement plus présent</div>

<span id="com">git rm</span>
<span id="par">-r</span>
<span id="val">"nom_du_fichier"</span>

<span id="par">-r </span>
<span id="not">permet de préciser la récursivité sur l'ensemble d'un dossier par exemple.</span>

## <div id="titleSub">21. Afficher la différence entre le repository local et le stockage</div>

<span id="com">git diff</span>

## <div id="titleSub">999. En cas de problème</div>

## <div id="titleSub2">Lorsque l'on essaie de push, on a le message d'erreur suivant</div>

```
remote: Support for password authentication was removed on August 13, 2021.
```

1. Dans Github, se rendre dans "Settings"
2. Sur le côté gauche, cliquer sur "Developer settings"
3. Sur le côté gauche, cliquer sur "Personal access tokens"
4. Sur le côté gauche, cliquer sur "Tokens (classic)"
5. Cliquer sur Generate new token
6. Définir la temporalité du nouveau token
7. Définir le périmétre du nouveau token
8. Une fois le token généré, le stocker précieusement
9. git remote set-url origin https://((token))@github.com/((identifiant))/((repository)).git
10. git push -u origin main