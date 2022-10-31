<head>
<style>
#titleMain {color:#808080; font-size:40px; font-weight:bold; font-family:"Cambria"}
#titleSub {color:#677179; font-size:24px; font-weight:bold; font-family: "Verdana"; margin-top:30px; margin-bottom:25px}
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

# <div id="titleMain">Les bases de la création du Dockerfile</div>

## <div id="titleSub">0. Rappel</div>

Un Dockerfile est un fichier docker qui va nous permettre de créer une image personnalisé.<br>
Cette image personnalisé nous permettre de lancer un conteneur avec Docker.<br>
Un fichier Dockerfile doit toujours avoir pour nom <span id="not"> Dockerfile</span> (et pas d'extension).

## <div id="titleSub">1. From</div>

Une image personnalisée doit toujours utilisé une image basique (exemple: Debian)<br>
C'est la première instruction qui compose votre Dockerfile<br>

<span id="com">From </span>
<span id="val">Debian</span>:
<span id="val">version </span>

## <div id="titleSub">2. Run</div>

Permet de lancer une ou plusieurs commandes durant la phase de construction de l'image

