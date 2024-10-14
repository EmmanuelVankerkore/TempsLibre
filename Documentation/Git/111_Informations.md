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

# <div id="titleMain">Afficher les informations utiles</div>

## <div id="titleSub">1. Statut</div>

<span id="com">git status</span>

## <div id="titleSub">2. Branches</div>

<span id="com">git branch</span>

## <div id="titleSub">3. Télécommandes</div>

# <div id="titleSub2">3.1 Lister</div>

<span id="com">git remote </span>

# <div id="titleSub2">3.2 Informations</div>

<span id="com">git remote</span>
<span id="par">show</span>
<span id="val">"nom_d_une_télécommande"</span>

## <div id="titleSub">4. Différence</div>

# <div id="titleSub2">4.1 Entre le dernier commit et maitenant (not staged)</div>

<span id="com">git diff</span>

# <div id="titleSub2">4.2 Entre deux commits</div>

<span id="com">git diff </span>
<span id="val">commit commit</span>

## <div id="titleSub">5. Log (les commits)</div>

# <div id="titleSub2">5.1 Sur une ligne</div>

<span id="com">git log</span>
<span id="par">--oneline</span>

# <div id="titleSub2">5.2 Les derniers</div>

<span id="com">git log</span>
<span id="par">-n</span>
<span id="val">nombre</span>

# <div id="titleSub2">5.3 Visualiser les indexes sur les fichiers</div>

<span id="com">git log</span>
<span id="par">--raw</span>

## <div id="titleSub">6. Historique des positions de HEAD</div>

# <div id="titleSub2">6.1 Version git</div>

<span id="com">git reflog</span>

# <div id="titleSub2">6.2 Avec une interface graphique plus jolie</div>

<span id="com">gitk --all --reflog</span>

<span id="not">- all : permet de visualiser toutes les branches</span>
<span id="not">- reflog : permet de visualiser les commits orphelins</span>

## <div id="titleSub">7. interface graphique pour réaliser un commit</div>

<span id="com">git-gui</span>