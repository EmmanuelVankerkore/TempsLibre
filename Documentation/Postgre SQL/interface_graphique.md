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

# <span id="titleMain">Postgre SQL - interface graphique</span>

## <div id="titleSub">0. Comment retrouver l'executable</div>

Il ne faut pas rechercher l'exression "postgre" mais plutôt l'expression "pgAdmin"

## <div id="titleSub">1. Présentation globale de l'interface graphique</div>

## <div id="titleSub2">1.1 Object Explorer</div> 

On retrouve les éléments principaux éléments constitutif des bases de données SQL:

* Base de données
* Schéma
* Table
* Colonne
* index

![image info](./SourcesImages/PGSQL_objectExplorer.png)

## <div id="titleSub2">1.2 Partie principale</div>

On retrouvera la partie edition des requêtes SQL (en haut) et la partie résultat/message (en bas).

![image info](./SourcesImages/PGSQL_partiePrincipale.png)

## <div id="titleSub">2. Ouvrir l'outil de requêtage SQL</div>

![image info](./SourcesImages/PGSQL_queryTools.png)

## <div id="titleSub">3. Ouvrir un shell propre à Postgre SQL</div>

![image info](./SourcesImages/PGSQL_shell.png)

## <div id="titleSub">4. Récupération des requêtes SQL (CRUD)</div>

Faire un clique droit sur une table

![image info](./SourcesImages/PGSQL_scriptsGeneration.png)