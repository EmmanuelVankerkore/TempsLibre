<head>
<style>
#titleMain {color:#808080; font-size:40px; font-weight:bold; font-family:"Cambria"}
#titleSub {color:#677179; font-size:24px; font-weight:bold; font-family: "Verdana"; margin-top:30px; margin-bottom:15px}
#titleSub2 {color:#563C5C; font-size:20px; font-weight:bold; margin-bottom:20px}
#not {color:#1E90FF; font-size:18px "Carnivalee Freakshow"}
#com {color:#FF00FF; font-size:18px "Carnivalee Freakshow"}
#par {color:#32CD32; font-size:18px "Carnivalee Freakshow"}
#val {color:#87CEFA; font-size:18px "Carnivalee Freakshow"}
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

# <div id="titleMain">Commandes sur Linux</div>

## <div id="titleSub">1. Créer un fichier vide</div>

<span id="com">touch </span>
<span id="val"> chemin_complet_du_nouveau_fichier </span>

## <div id="titleSub">2. Créer un nouveau dossier</div>

<span id="com">mkdir </span>
<span id="par">-p</span>
<span id="val">nouveau_dossier </span>

<span id="not"> p pour préciser la création des dossiers intermédiaires s'ils n'existent pas. </span>

## <div id="titleSub">3. Lister l'ensemble des fichiers du répertoire actuel</div>

<span id="com">ls </span>
<span id="par">-R -l -a</span>

<span id="not"> R pour préciser les fichiers de tous les sous-répertoires. </span><br>
<span id="not"> l pour préciser plus de détail sur les fichiers (taille, date de dernière modification, créateur, ...).</span><br>
<span id="not"> a pour préciser les fichiers cachés.</span>


## <div id="titleSub">4. Rechercher l'emplacement d'un fichier</div>

<span id="com">locate </span>
<span id="par">-i </span>
<span id="val">fichier_recherché </span>

<span id="not"> i pour préciser l'insensibilité à la casse.</span>

## <div id="titleSub">5. Insérer du texte dans un fichier</div>

<span id="com">echo </span>
<span id="val">texte_à_insérer </span>
<span id="com">>> </span>
<span id="val">nom_du_fichier</span>

<span id="not">Un retour à la ligne est réalisé pour chaque commande echo.</span>

## <div id="titleSub">6. Afficher les premières lignes d'un fichier</div>

<span id="com">head </span>
<span id="par">-n </span>
<span id="val"> nombre_de_lignes fichier</span>

<span id="not">n pour préciser le nombre de ligne dans l'affichage.</span><br>

## <div id="titleSub">7. Afficher les dernières lignes d'un fichier</div>

<span id="com">tail </span>
<span id="par">-n </span>
<span id="val"> nombre_de_lignes fichier</span>

<span id="not">n pour préciser le nombre de ligne dans l'affichage.</span>

## <div id="titleSub">8. Naviguer d'un dossier à l'autre</div>

<span id="com">cd </span>
<span id="not">se positionner sur le dossier principal</span>

<span id="com">cd ..</span>
<span id="not">se positionner sur le dossier père</span>

<span id="com">cd </span>
<span id="val">dossier_enfant</span>
<span id="not">se positionner sur le dossier enfant</span>

## <div id="titleSub">9. Afficher le chemin absolu du dossier actif</div>

<span id="com">pwd </span>

## <div id="titleSub">10. Copier un fichier dans un dossier</div>

<span id="com">cp </span>
<span id="val">fichier_du_dossier_actif dossier_cible</span>

## <div id="titleSub">11. Supprimer un dossier</div>

<span id="com">rmdir </span>
<span id="val">dossier</span>

<span id="not">Un dossier ne peut être supprimer que s'il est vide.</span>

## <div id="titleSub">12. Supprimer un dossier et son contenu</div>

<span id="com">rm </span>
<span id="val">dossier</span>

## <div id="titleSub">13. Réaliser une recherche de texte</div>

<span id="com">grep </span>
<span id="val">élément_recherché fichier_sur_lequel_on_recherche</span>

## <div id="titleSub">14. Stocker le résultat d'une commande dans un fichier</div>

<span id="val">commande </span>
<span id="com">> </span>
<span id="val">chemin_du_fichier</span>

## <div id="titleSub">15. Mettre en pause l'exécution du script shell</div>

<span id="com">sleep </span>
<span id="val">nombre_de_secondes</span>

## <div id="titleSub">16. Rendre un script shell directement exécutable</div>

<span id="com">chmod </span>
<span id="par">-x </span>
<span id="val">nom_du_fichier.sh</span>

## <div id="titleSub">17. Lancer l'ouverture d'un navigateur internet</div>

<span id="com">navigateur </span>
<span id="val">adresse_http</span>

## <div id="titleSub">18. Effacer toute la console</div>

<span id="com">clear </span>

## <div id="titleSub">19. Réaliser un téléchargement</div>

<span id="com">wget </span>
<span id="val">URL_telechargement </span>

## <div id="titleSub">20. Décompresser une archive</div>

<span id="com">tar xzf </span>
<span id="val">archive </span>

## <div id="titleSub">21. Tester l'ouverture d'un port depuis un serveur</div>

<span id="com">telnet </span>
<span id="val">serveur port</span>

Dans notre cas : serveur --> localhost

## <div id="titleSub">22. Interrompre une commande en cours</div>

Utiliser le raccourci clavier : Ctrl + C

## <div id="titleSub">23. Copier et coller du texte</div>

Utiliser les raccourcis clavier suivants :
- Copier --> Ctrl + Shift + C
- Coller --> Ctrl + Shift + V