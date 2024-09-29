<head>
<style>
#titleMain {color:#808080; font-size:40px; font-weight:bold; font-family:"Cambria"}
#titleSub {color:#677179; font-size:24px; font-weight:bold; font-family: "Verdana"; margin-top:30px; margin-bottom:15px}
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

# <div id="titleMain">Commandes sur Linux</div>

## <div id="titleSub">1. Consulter l'ensemble des utilisateurs</div>

<span id="com">getent passwd </span>

<span id="not">Voici comment interpréter l'affichage :</span><br>

Username : Password : User ID : Group ID : Description : Home Directory : Shell

## <div id="titleSub">2. Consulter l'ensemble des groupes d'utilisateurs</div>

<span id="com">getent group </span>

<span id="not">Voici comment interpréter l'affichage :</span><br>

Group name : Password : Group ID : Liste des utilisateurs

## <div id="titleSub">3. Ajouter un nouvel utilisateur</div>

<span id="com">adduser </span>
<span id="val">username</span>

## <div id="titleSub">4. Ajouter un nouveau groupe d'utilisateurs</div>

<span id="com">groupadd </span>
<span id="val">nom_du_groupe</span>

## <div id="titleSub">5. Modifier le groupe d'appartenance auquel est rattaché l'utilisateur</div>

<span id="com">usermod </span>
<span id="par">-g </span>
<span id="val">groupe</span>
<span id="val">utilisateur</span>

## <div id="titleSub">6. Supprimer un utilisateur</div>

<span id="com">userdel </span>
<span id="val">username</span>

## <div id="titleSub">7. Supprimer un groupe d'utilisateurs</div>

<span id="com">groupdel </span>
<span id="val">groupe</span>

## <div id="titleSub">8. Rendre un script shell directement exécutable</div>

<span id="com">chmod </span>
<span id="par">-x </span>
<span id="val">nom_du_fichier.sh</span>