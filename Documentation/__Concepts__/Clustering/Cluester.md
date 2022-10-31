<head>
<style>
#titleMain {color:#808080; font-size:40px; font-weight:bold; font-family:"Cambria"}
#titleSub {color:#677179; font-size:24px; font-weight:bold; font-family: "Verdana"; margin-top:30px; margin-bottom:25px}
#titleSub2 {color:#563C5C; font-size:20px; font-weight:bold; margin-bottom:20px}
#titleSubSub {}
#com {color:#FF00FF; font-size:18px "Carnivalee Freakshow"}
#par {color:#32CD32; font-size:18px "Carnivalee Freakshow"}
#val {color:#87CEFA; font-size:18px "Carnivalee Freakshow"}
#imp {color:#e21313; font:bold 20px "Carnivalee Freakshow"}
#def {color:#90EE90; font-size:18px "Carnivalee Freakshow"}
#not {color:#1E90FF; font-size:18px "Carnivalee Freakshow"}
#att {color:#ffa500; font-size:18px "Carnivalee Freakshow"}
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


# <div id="titleMain">Comprendre le clustering</div>

## <div id="titleSub">0. C'est quoi</div>

Un cluster est un regroupement de plusieurs serveurs.

## <div id="titleSub">1. Les types de clustering</div>

## <div id="titleSub2">Actif/Passif</div>

Les deux serveurs sont similaires et démarés, mais le serveur actif gère les requêtes et le serveur passif est veille.<br>
Si le serveur actif devient HS alors le serveur actif devient passif et inversement.

<span id="not">Ce type de serveur ne sert qu'à répondre à un besoin de disponibilité.</span><br>

## <div id="titleSub2">Actif/Actif</div>

Tous les serveurs sont actifs donc la charge est répartie entre tous les serveur.<br>
Si un serveur tombe en panne alors les autres serveurs doivent réaliser la montée en charge.

<span id="att">Avec ce type de serveur, il faut gérer des problèmes de concurence pour les bases de données et des sessions d'utilisateur pour les serveurs d'applications.</span><br>

## <div id="titleSub">2. Comment répartir la charge entre les différents serveurs</div>

On a deux possibilité.

## <div id="titleSub2">De manière Statique</div>

On définit en amont, l'ensemble de nos critères.<br>
Par exemple: Serveur A traitera les demandes des utilisateurs anglais et le Serveur B traitera les demandes des utilisateurs français.

<span id="not">Non conseillé dans le cadre de bases de données pour des raisons de problème de synchronisation.</span><br>

## <div id="titleSub2">De manière Dynamique</div>

Cela se fait avec un <span id="imp">Load Balancer</span> qui est un équipement spécialisé dans la répartition de charge entre les différents serveurs en plus de vérifier que les serveurs sont bien disponible afin de ne pas envoyer de requête à un serveur qui serait KO.<br>

## <div id="titleSub">3. Les algorithmes utilisés dans les Load Balancer</div>

## <div id="titleSub2">Round Robin</div>

Envoi d'un requête à l'un puis à l'autre etc.

## <div id="titleSub2">Round Robin Pondéré</div>

On affecte à chaque serveur un poids et on tient compte de ce poids lors de l'envoie des requêtes aux différents serveurs.<br>
Si le serveur A à un poids de 1, le serveur B à un poid de 4 et le serveur C un poids de 2 alors sur 7 requêtes 1 sera envoyé au serveur 1, 4 au B et 2 au C.

<span id="not">Cet algorithmes est adapté dans la mesure où tous les serveurs n'ont pas la même puissance de traitement ou si certains serveurs supportent plus de fonctionnalité.</span><br>

## <div id="titleSub2">Least Connection</div>

Le Load Balancer assigne les requêtes au serveur qui en a le moins.

## <div id="titleSub">4. Tolérance aux pannes</div>

## <div id="titleSub2">Fail Over</div>

C'est le fait de tranférer d'un serveur A à un serveur B les processus en cours si celui ci venait à tomber.

## <div id="titleSub2">Fail Back</div>

C'est la capacité de réintégrer un serveur dans le cluster suite à une panne de celui-ci.

<span id="not">Sans cette possibilité, il faudrait étaindre le cluster pour réintégrer le serveur.</span><br>