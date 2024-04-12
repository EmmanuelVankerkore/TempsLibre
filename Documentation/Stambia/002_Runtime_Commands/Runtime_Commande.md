<head>
<style>
#titleMain {color:#808080; font-size:40px; font-weight:bold; font-family:"Cambria"}
#titleSub {color:#677179; font-size:30px; font-weight:bold; font-family: "Verdana"; margin-top:30px; margin-bottom:25px}
#titleSub2 {color:#563C5C; font-size:20px; font-weight:bold; margin-bottom:20px}
#titleSubSub {}
#com {color:#FF00FF; font-size:18px "Carnivalee Freakshow"}
#par {color:#32CD32; font-size:18px "Carnivalee Freakshow"}
#val {color:#87CEFA; font-size:18px "Carnivalee Freakshow"}
#imp {color:#e21313; font:bold 20px "Carnivalee Freakshow"}
#def {color:#90EE90; font-size:18px "Carnivalee Freakshow"}
#not {color:#1E90FF; font-size:18px "Carnivalee Freakshow"}
#att {color:#ffa500; font-size:18px "Carnivalee Freakshow"}
.video-responsive {
 overflow:hidden;
 padding-bottom:56.25%; 
 position:relative;
 height:0;
}
.video-responsive iframe {
 left:0;
 top:0;
 height:100%;
 width:100%;
 position:absolute;
}
</style>
</head>

# <span id="titleMain">Runtime Commands</span>

## <div id="titleSub">0 Où entrer sa commande</div>

C'est idiot ! Mais assurez-vous que le runtime soit lancé.

> Première possibilité : via Designer

Cliquer sur "Runtime command"

![image info](./SourcesImages/DesignerOuvrirRuntimeCommand.png)

Une nouvelle fenêtre est apparue:

![image info](./SourcesImages/Designer_Fenetre_RuntimeCommande.png)

Il faut maintenant se connecter au runtime en utilisant la commande suivante :

<span id="com">connect to </span>
<span id="val">nom_serveur </span>
<span id="par">port </span>
<span id="val">valeur_port </span>
<span id="par">user </span>
<span id="val">valeur_user </span>
<span id="par">password </span>
<span id="val">valeur_password </span>

<span id="not">Les informations relatives à l'authentification se trouve dans le fichier "engineParameters.xml" propre au runtime </span>

Une fois que l'on est connecté, on a ceci:

![image info](./SourcesImages/DesignerRuntimeCommand_connected.png)

> Seconde possibilité : via Analytics

Assurez-vous que le serveur Tomcat soit lancé

Ouvrir Analytics avec l'URL suivante http://localhost:8080/semarchy-xdi-analytics/semarchy

Ouvrir le runtime de la manière suivante:

![image info](./SourcesImages/Analytcis_Ouvrir_Runtime.png)

Selectionner l'onglet command:

![image info](./SourcesImages/Analytics_selectionner_Onglet_comand.png)

## <div id="titleSub">1 Obtenir la version du runtime </div>

<span id="com">versions </span>

![image info](./SourcesImages/Commande_Versions.png)

## <div id="titleSub">2 Lister l'ensemble des deliveries </div>

<span id="com">get deliveries </span>

il est possible de préciser la liste des champs à afficher (%name, %builduser, %configuration, %id, %packageid, %processid, %username, %version, %builddate et %exportdate):

<span id="com">get deliveries </span>
<span id="par">format </span>
<span id="val">%name;%id;%builddate </span>

il est possible de préciser la liste des deliveries à afficher:

<span id="com">get deliveries </span>
<span id="par">id </span>
<span id="val">7185a43d-06a8-4660-86f7-602c495d7d9b </span>

## <div id="titleSub">3 Supprimer un delivery </div>

<span id="com">remove delivery </span>
<span id="val">nom_delivery </span>

## <div id="titleSub">4 Lancer l'exécution d'un delivery </div>

<span id="com">execute delivery </span>
<span id="val">nom_delivery </span>

Le terminal renvoie la SESSION_ID correspondant à l'exécution:

![image info](./SourcesImages/Execute_Delivery.png)

## <div id="titleSub">5. Plannifier l'exécution d'un delivery</div>

<span id="not">Il existe un site qui aide à la construction du CRON: </span> https://crontab.guru/ 

La syntaxe globale est :

<span id="com">schedule delivery </span>
<span id="val">nom_delivery </span>
<span id="par">jobName </span>
<span id="val">libelle_interne_delivery </span>
<span id="par">var </span>
<span id="val">path valeur_variable </span>
<span id="par">start </span>
<span id="val">date_de_commencement </span>
<span id="par">end </span>
<span id="val">date_de_fin </span>
<span id="par">cron </span>
<span id="val">valeur_du_cron </span>

## <div id="titleSub2">5.1 À des moments ponctuels</div>

Par exemple: toutes les 1 ière et à la 41 ième secondes.

La valeur CRON est la suivante: "1,41 * * * * ? *"

![image info](./SourcesImages/Scheduler_ponctuel_2_fois_par_minute.png)

## <div id="titleSub2">5.1 À intervalle de temps régulier</div>

Par exemple: toutes les 2 minutes et à la 30 ième seconde.

La valeur CRON est la suivante: "30 */2 * * * ? *"

![image info](./SourcesImages/Scheduler_intervalle_regulier.png)

## <div id="titleSub2">5.2 De manière continue</div>

Par exemple: à la 5 ième seconde entre la 50 ième et la 55 ième minute.

La valeur CRON est la suivante: "5 50-55 * * * ? *"