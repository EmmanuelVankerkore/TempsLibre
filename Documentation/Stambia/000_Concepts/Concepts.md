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

# <span id="titleMain">Les concepts importants dans Semarchy xDI</span>

## <div id="titleSub">1. Web Service</div>

## <div id="titleSub2">1.1 SOAP</div>

SOAP est un <span id="imp">protocole</span> de communication basé sur XML pour permettre aux applications de s'échanger des informations via HTTP.<br>
Il permet ainsi l'accès aux services web et l'<span id="imp">interopérabilité</span> des applications à travers le web.

## <div id="titleSub2">1.2 REST</div> 

REST est un ensemble de <span id="imp">principes architecturaux</span> adapté aux besoins des services web et applications mobiles légers. <br>
L'envoi d'une requête de données à une API REST se fait généralement par le protocole <span id="imp">HTTP</span>.

## <div id="titleSub2">1.3 Web Service</div>

Service mis à disposition des clients par un serveur via Internet (ou un autre réseau).

## <div id="titleSub2">1.4 WSDL</div>

<span id="def">Web Service Description Language</span>

Métalangage permettant de décrire en détail les services Web

## <div id="titleSub">2. Templates</div>

Les templates sont des <span id="imp">modèles de processus graphiques</span> qui aideront Stambia à générer des processus de flux de données adaptés et performants pour n'importe quelle technologie.

## <div id="titleSub">3. Contraintes d'intégrité</div>

## <div id="titleSub2">3.1 Définition</div> 

Une contrainte d'intégrité est une <span id="imp">règle</span> qui définit la <span id="imp">cohérence</span> d'une donnée ou d'un ensemble de données de la BD
<span id="not">Les contraintes sont définies au moment de la création des tables.</span>

Il existe deux types de contraintes :

+ sur une colonne unique,
+ ou sur une table lorsque la contrainte porte sur une ou plusieurs colonnes.

## <div id="titleSub2">3.2 Type</div>

* Primary Key
* Unique
* References
* Check

## <div id="titleSub">4. Recycler les rejets</div>

<span id="def">Les rejets détectés lors de la précédente exécution du mapping sont ajoutés à la table d'intégration</span>