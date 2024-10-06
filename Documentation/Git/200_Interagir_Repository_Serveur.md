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

# <div id="titleMain">Interagir avec le repository sur un serveur cloud (GitHub, GitLab, ...)</div>

## <div id="titleSub">1. Définir un accès vers un espace GitHub</div>

<span id="com">git remote </span>
<span id="par">add </span>
<span id="val">"télécommande" "url"</span>

## <div id="titleSub">2. Pousser ses modification sur GitHub</div>

<span id="com">git push </span>
<span id="par">-u </span>
<span id="val">"nom_de_la_telecommande" "nom_de_la_branche_GitHub"</span>

<span id="par">-u </span>
<span id="not">permet d'initialiser un stream qui servira de référence pour chaque commandes pull et push.</span>

## <div id="titleSub">3. Récupérer les données d'une branche spécifique sur un répository GitHub</div>

<span id="com">git pull </span>
<span id="val">"télécommande" "branche"</span>