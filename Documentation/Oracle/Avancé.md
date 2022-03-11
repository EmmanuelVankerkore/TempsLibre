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

# <span id="titleMain">Tuto avancé sur Oracle</span>

## <span id="titleSub">1. Definir un auto-incrément sur le champ d'une table</span>
<br>

<span id="commande">CREATE SEQUENCE </span><span id="param"> TNATUREPARENT_SIDNATPAR_SEQ </span><br>
  <span id="tab1"></span><span id="commande">START WITH </span><span id="param">1<br>
  <span id="tab1"></span><span id="commande">INCREMENT BY </span><span id="param">1<span id="commande">;</span>
<br><br>
 
<span id="commande">CREATE OR REPLACE TRIGGER </span><span id="param"> TRG_BI_TNATUREPARENT</span><br>
<span id="commande">BEFORE INSERT ON </span><span id="param"> DWHDIM.T_NATURE_PARENT</span>
<br><br>

<span id="commande">FOR EACH ROW <br>
  <span id="tab1"></span><span id="commande">WHEN (new.</span><span id="param">SID_NAT_PAR IS NULL</span><span id="commande">)</span><br>
    <span id="tab2"></span><span id="commande">BEGIN</span><br>
    <span id="tab3"></span><span id="commande">:new.</span><span id="param">SID_NAT_PAR </span><span id="commande">:=</span><span id="param"> TNATUREPARENT_SIDNATPAR_SEQ.NEXTVAL</span><span id="commande">;</span><br>
    <span id="tab2"></span><span id="commande">END;</span>
<br><br>

### <span id="titleSubSub">1.1 Ordonnancement </span>
<br>

1. Déclarer une table avec au moins une clé primaire
2. Déclarer une séquence
3. Déclarer un trigger
4. Déclarer l'incrémentation
<br><br>

### <span id="titleSubSub">1.2 Les conventions de nommage </span>
<br>

nom de la séquence : (nom de la table)_(nom du champ)_SEQ<br>
nom du trigger : TRG_(type d'événement)_(nom du champ)<br>
type d'événement : BI (Before Insert)

## <span id="titleSub">2. Utiliser plusieurs sous requêtes avec un with </span>
<br>

<span id="commande">with </span><span id="param">alias_sr_1 </span><span id="commande">as (</span><br>
    <span id="tab1"></span><span id="param">Sous_Requête_1</span><br>
<span id="commande">),</span><br>
<span id="param">alias_sr_2 </span><span id="commande">as (</span><br>
    <span id="tab1"></span><span id="param">Sous_Requête_2</span><br>
<span id="commande">)</span><br>
<span id="param">Requête_Finale</span><br>

## <span id="titleSub">3. Faire un select sans table existante </span>
<br>

<span id="commande">select</span>
<span id="param">expression</span><br>
<span id="commande">from dual</span>

## <span id="titleSub">4. Réaliser un calcul partitionné </span>
<br>

<span id="param">Expression </span>
<span id="commande">OVER ( PARTITION BY </span>
<span id="param"> ChampAgregable </span>
<span id="commande">)</span>

Exemple d'utilisation:

Select CodeArticle<br>
<span id="tab1"></span>,max(id_integration) OVER ( PARTITION BY CodeArticle )<br>
From MDW.ARTICLE

## <span id="titleSub">5. Réaliser une liste d'agregation </span>
<br>

<span id="commande">LISTAGG(</span>
<span id="param">champ1 || connecteur || champ2</span>
<span id="commande">,</span>
<span id="param">séparateur</span>
<span id="commande">) WITHIN GROUP (ORDER BY </span>
<span id="param">champtri</span>
<span id="commande">)</span>

Exemple d'utilisation:

Select LISTAGG(NomAttribut || ' --> ' || ValeurAttribut, ' ; ') WITHIN GROUP (ORDER BY NomAttribut)<br>
From MDW.ARTICLE<br>
Group By CodeArticle

## <span id="titleSub">6. Concatener les éléments pour chaque modalité </span>
<br>

```
LISTAGG(Case
			When TMP_MDW_DFD_ARTICLE_ATTRIBUT_PREPARATION.CODEATTRIBUT_MAPS is not null
				then TMP_MDW_DFD_ARTICLE_ATTRIBUT_PREPARATION.CODEATTRIBUT_MAPS || '=' || TMP_MDW_DFD_ARTICLE_ATTRIBUT_PREPARATION.PROPRIETE
		End , '/') WITHIN GROUP (ORDER BY TMP_MDW_DFD_ARTICLE_ATTRIBUT_PREPARATION.CODEATTRIBUT_MAPS) OVER (PARTITION BY art.CODE_ARTICLE) 
```

## <span id="titleSub">7. Calcul d'un rang à partir d'un ordre </span>
<br>