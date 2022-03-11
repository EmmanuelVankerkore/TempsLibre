<head>
<style>
#bleu {}
#titleMain {color:#0000FF; font:28px ;font-weight:bold}
#titleSub {color:#00BFFF; font:24px}
#titleSubSub {font:10px}
#commande {color:#FF00FF; font:20px "Carnivalee Freakshow"}
#tag {color:#87CEFA; font:16px "Carnivalee Freakshow"}
#param {color:#32CD32; font:20px "Carnivalee Freakshow"}
#attention {color:#8B0000; font:20px "Carnivalee Freakshow"; font-weight:bold}
#tab1 {margin : 0px 20px 0px 0px}
#tab2 {margin : 0px 40px 0px 0px}
#tab3 {margin : 0px 60px 0px 0px}
</style>
</head>

# <span id="titleMain">Tuto fondamental sur les commandes shell de MongoDB</span>

<br>
note : L'exécutable permettant l'accès au shell doit ressembler à ceci --> 'C:\Program Files\MongoDB\Server\5.0\bin\mongo.exe'<br>
<br>


## <span id="titleSub">1. Afficher la base de données actuelle</span>
<br>

<span id="commande">db</span><br>
ou<br>
<span id="commande">db.getName()</span>

<br>

## <span id="titleSub">2. Lister les noms des bases de données</span>
<br>

<span id="commande">show dbs</span>

<br>

## <span id="titleSub">3. Lister les statistiques de la base de données</span>
<br>

<span id="commande">db.stats()</span>

<br>

## <span id="titleSub">4. Accéder à une base de données existante </span>
<br>

<span id="commande">use </span>
<span id="param">{Database}</span>

<span id="attention">note : Si la base de données n'existe pas elle est créé.</span>

<br>

## <span id="titleSub">5. Changer la visualisation des documents </span>
<br>

<span id="commande">db.createCollection( "</span>
<span id="param">{Collection}</span>
<span id="commande">" )</span>

<br>

## <span id="titleSub">6. Lister les collection </span>
<br>

<span id="commande">show collections</span>

<br>

## <span id="titleSub">7. Renommer le nom d'une collection </span>
<br>

<span id="commande">db.</span>
<span id="param">{Old Name}</span>
<span id="commande">.renameCollection( "</span>
<span id="param">{New Name}</span>
<span id="commande">" )</span>

<br>

## <span id="titleSub">8. Effacer une collection </span>
<br>

<span id="commande">db.</span>
<span id="param">{Collection}</span>
<span id="commande">.drop()</span>

<br>

## <span id="titleSub">9. Effacer la base de données active </span>
<br>

<span id="commande">db.dropDatabase()</span>

<br>

## <span id="titleSub">10. Insertion d'un document dans une collection de la base de données active </span>
<br>

<span id="commande">db.</span>
<span id="param">{Collection}</span>
<span id="commande">.insert(</span>
<span id="param">{JSON}</span>
<span id="commande">)</span>

<br>

## <span id="titleSub">11. Afficher l'intégralité d'une collection </span>
<br>

<span id="commande">db.</span>
<span id="param">{Collection}</span>
<span id="commande">.find()</span>

<br>

## <span id="titleSub">12. Afficher les documents d'une collection correspondant à une recherche simple</span>
<br>

<span id="commande">db.</span>
<span id="param">{Collection}</span>
<span id="commande">.find({</span>
<span id="param">{Champ} </span>
<span id="commande">: '</span>
<span id="param">{Element de recherche} </span>
<span id="commande">' })</span><br>

```
Exemple : db.Fact.find({Cadre: 'Sud Radio'})
```
<br>