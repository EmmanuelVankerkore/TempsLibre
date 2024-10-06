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

# <div id="titleMain">Manipuler les modifications ajoutées</div>

## <div id="titleSub">1. Réaliser un commit à partir des modifications ajoutées dans la partie Staged</div>

<span id="com">git commit </span>
<span id="par">-m </span>
<span id="val">message</span>

## <div id="titleSub">2. Annuler l'ajout de toutes les modifications</div>

<span id="com">git reset</span>

<span id="not">
staged --> untracked<br/>
staged --> unstaged
</span>

## <div id="titleSub">3. Supprime physiquement les modifications réalisées depuis le dernier commit</div>

<span id="com">git restore</span>
<span id="val">fichier</span>

<span id="not">Note : Uniquement pour les fichiers déjà connu dans Git (Unstaged)</span>

## <div id="titleSub">4. Supprime de la zone staged les modifications d'un fichier untracked</div>

<span id="com">git rm </span>
<span id="par">--cached </span>
<span id="val">fichier</span>

<span id="not">Note : Uniquement pour les fichiers qui ne sont pas déjà connu dans Git (Untracked)</span>

## <div id="titleSub">5. Supprime de la zone staged les modifications d'un fichier unstaged</div>

<span id="com">git reset HEAD </span>
<span id="val">fichier</span>