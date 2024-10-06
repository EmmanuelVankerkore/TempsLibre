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

# <div id="titleMain">Manipulation sur les branches</div>

## <div id="titleSub">1. Création d'une nouvelle branche</div>

<span id="com">git checkout </span>
<span id="par">-b </span>
<span id="val">nouvelle_branche</span>

## <div id="titleSub">2. Se positionner sur une branche existante</div>

<span id="com">git checkout </span>
<span id="val">branche_existante</span>

## <div id="titleSub">3. Renommer la branche sur laquelle on est actuellement</div>

<span id="com">git branch </span>
<span id="par">-M </span>
<span id="val">"nouveau_nom"</span>

## <div id="titleSub">4. Revenir à l'état du dernier commit</div>

<span id="com">git stash </span>

<span id="not">Note : Il va supprimer les fichiers qui sont dans la zone de stage mais ne va pas supprimer les untracked</span>

## <div id="titleSub">5. Annuler le point 4</div>

<span id="com">git stash </span>
<span id="par">pop</span>

## <div id="titleSub">6. Fusionner une tierce branche sur la branche active</div>

<span id="com">git merge </span>
<span id="val">tierce_branche</span>

## <div id="titleSub">7. Revenir sur un commit</div>

# <div id="titleSub2">7.1 SOFT</div>

<span id="not">Description : conserve physiquement les modifications mais les passes dans l'index (la partie staged) </span>

<span id="com">git reset </span>
<span id="par">--soft </span>
<span id="val">commit</span>

# <div id="titleSub2">7.2 MIXED</div>

<span id="not">Description : conserve physiquement les modifications mais les passes en unstaged ou en untracked </span>

<span id="com">git reset </span>
<span id="par">--mixed </span>
<span id="val">commit</span>

# <div id="titleSub2">7.3 HARD</div>

<span id="not">Description : Supprime physiquement les modifications</span>

<span id="com">git reset </span>
<span id="par">--hard </span>
<span id="val">commit</span>

## <div id="titleSub">8. Se positionner une commit antérieur</div>

<span id="com">git checkout </span>
<span id="val">commit</span>

## <div id="titleSub">9. Actions réalisées</div>

<span id="com">git reflog </span>