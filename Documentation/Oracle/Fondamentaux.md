<head>
<style>
#bleu {}
#titleMain {color:#808080; font:28px ;font-weight:bold}
#titleSub {font:24px}
#titleSubSub {font:10px}
#commande {color:#FF00FF; font:20px "Carnivalee Freakshow"}
#tag {color:#87CEFA; font:16px "Carnivalee Freakshow"}
#param {color:#32CD32; font:20px "Carnivalee Freakshow"}
#tab1 {margin : 0px 20px 0px 0px}
#tab2 {margin : 0px 40px 0px 0px}
#tab3 {margin : 0px 60px 0px 0px}
</style>
</head>

# <span id="titleMain">Tuto fondamental sur Oracle</span>

## <span id="titleSub"> 0. Les types dans oracle </span>
<br>

- Varchar2
- Number

## <span id="titleSub">1. Réaliser une MAJ sur plusieurs colonnes </span>
<br>

<span id="commande">Update </span>
<span id="param"> {schéma}.{table} </span><br>
<span id="commande">Set </span>
<span id="param"> {colonne1} = {value1} </span><br>
<span id="tab1"></span>
    <span id="param"> {colonne2} = {value2} </span><br>
<span id="tab1"></span>
    <span id="param"> {colonn3} = {value3} </span><br>
<span id="commande">Where </span>
<span id="param"> {condition} </span><br>

## <span id="titleSub">2. Insérer des lignes </span>
<br>

### <span id="titleSubSub"> 2.1 Avec des données brutes </span>
<br>

<span id="commande">Insert Into </span>
<span id="param"> {schéma}.{table} </span>
<span id="commande"> ( </span>
<span id="param"> {colonne1},{colonne2},{colonne3} </span>
<span id="commande"> ) </span><br>
<span id="commande"> Values </span>
<span id="commande"> ( </span>
<span id="param"> {value1a},{colonne2a},{colonne3a}</span>
<span id="commande"> ) ,</span><br>
<span id="tab1"></span>
    <span id="commande"> ( </span>
    <span id="param"> {value1b},{colonne2b},{colonne3b}</span>
    <span id="commande"> ) ,</span><br>
<span id="tab1"></span>
    <span id="commande"> ( </span>
    <span id="param"> {value1c},{colonne2c},{colonne3c}</span>
    <span id="commande"> ) </span><br>

### <span id="titleSubSub"> 2.2 Avec des données existantes </span>
<br>

<span id="commande">Insert Into </span>
<span id="param"> {schéma1}.{table1} </span>
<span id="commande"> ( </span>
<span id="param"> {colonne1},{colonne2},{colonne3} </span>
<span id="commande"> ) </span><br>
<span id="commande"> Select </span>
<span id="param"> {colonneA},{colonneB},{colonneC} </span><br>
<span id="commande"> From </span>
<span id="param"> {schéma2}.{table2} </span><br>


## <span id="titleSub"> 3. Modifier une table </span>
<br>

### <span id="titleSubSub"> 3.1 Ajouter des champs </span>
<br>

<span id="commande">Alter table </span>
<span id="param"> {schéma1}.{table1} </span><br>
<span id="commande">Add (</span><br>
<span id="tab1"></span>
    <span id="param"> {colonne1} {type1} ,</span><br>
<span id="tab1"></span>
    <span id="param"> {colonne2} {type2} ,</span><br>
<span id="tab1"></span>
    <span id="param"> {colonne3} {type3} </span><br>
<span id="commande">)</span><br>

### <span id="titleSubSub"> 3.2 Modifier des champs </span>
<br>

<span id="commande">Alter table </span>
<span id="param"> {schéma1}.{table1} </span><br>
<span id="commande">Modify (</span><br>
<span id="tab1"></span>
    <span id="param"> {colonne1} {type1} ,</span><br>
<span id="tab1"></span>
    <span id="param"> {colonne2} {type2} ,</span><br>
<span id="tab1"></span>
    <span id="param"> {colonne3} {type3} </span><br>
<span id="commande">)</span><br>

### <span id="titleSubSub"> 3.3 Suppression des champs </span>
<br>

<span id="commande">Alter table </span>
<span id="param"> {schéma1}.{table1} </span><br>
<span id="commande">Drop (</span>
<span id="param"> {colonne1} , {colonne2} , {colonne3}</span>
<span id="commande">)</span><br>

### <span id="titleSubSub"> 3.4 Renommer un champ </span>
<br>

<span id="commande">Alter table </span>
<span id="param"> {schéma1}.{table1} </span><br>
<span id="commande">Rename Column </span>
<span id="param"> {old_colonne} </span>
<span id="commande">to </span>
<span id="param">{new_colonne} </span><br>

## <span id="titleSub"> 4. Créer une table </span>
<br>

<span id="commande">Create table </span>
<span id="param"> {schéma}.{table} </span><br>
<span id="commande">(</span><br>
<span id="tab1"></span>
    <span id="param"> {colonne1} {type1} ,</span><br>
<span id="tab1"></span>
    <span id="param"> {colonne2} {type2} ,</span><br>
<span id="tab1"></span>
    <span id="param"> {colonne3} {type3} </span><br>
<span id="commande">)</span><br>

## <span id="titleSub"> 5. Supprimer des lignes </span>
<br>

<span id="commande"> Delete From </span>
<span id="param"> {schéma}.{table} </span><br>
<span id="commande"> Where </span>
<span id="param"> {condition} </span><br>

## <span id="titleSub"> 6. Supprimer une table </span>
<br>

<span id="commande"> Drop Table </span>
<span id="param"> {schéma}.{table} </span><br>