<head>
<style>
#boiteimagetexte {display:flex; align-items: flex-start}
</style>
</head>

# Tuto sur les fondamentaux Stambia

- [Tuto sur les fondamentaux Stambia](#tuto-sur-les-fondamentaux-stambia)
  - [1. Création de métadatas](#1-création-de-métadatas)
  - [1.1 CSV](#11-csv)
  - [1.2 XML](#12-xml)
  - [1.3 Web Service](#13-web-service)
  - [2. Selectionner l'affichage des champs d'une table](#2-selectionner-laffichage-des-champs-dune-table)
  - [3. Réaliser un mapping simple](#3-réaliser-un-mapping-simple)
  - [3.1 Définir le type de mapping en sortie](#31-définir-le-type-de-mapping-en-sortie)
  - [3.2 Lancer l'exécution d'un mapping](#32-lancer-lexécution-dun-mapping)
  - [3.3 Modifier la règle métier du mapping](#33-modifier-la-règle-métier-du-mapping)
  - [3.4 Modifier la jointure entre deux tables](#34-modifier-la-jointure-entre-deux-tables)
  - [3.5 Dédoublonnage des valeurs lors d'un mapping](#35-dédoublonnage-des-valeurs-lors-dun-mapping)
  - [4. Réaliser un filtre sur le champ d'une table](#4-réaliser-un-filtre-sur-le-champ-dune-table)
  - [4.1 Modifier la règle d'un filtre](#41-modifier-la-règle-dun-filtre)
  - [5. Créer un stage](#5-créer-un-stage)
  - [5.1 Ajouter un champ dans le stage](#51-ajouter-un-champ-dans-le-stage)
  - [5.2 Définir l'expression d'un champ d'un stage](#52-définir-lexpression-dun-champ-dun-stage)
  - [6. Se familiariser avec l'interface](#6-se-familiariser-avec-linterface)
  - [6.1 Identifier l'item dans "Project Explorer" à partir du Designer](#61-identifier-litem-dans-project-explorer-à-partir-du-designer)
  - [6.2 Réarranger les entités d'un mapping ou d'un process](#62-réarranger-les-entités-dun-mapping-ou-dun-process)
  - [7. À savoir / Très important](#7-à-savoir--très-important)
  - [8. Les items/logos à connaître par coeur](#8-les-itemslogos-à-connaître-par-coeur)
  - [9. Avant l'exécution du process](#9-avant-lexécution-du-process)
  - [10. En cas d'echec durant l'exécution d'un process](#10-en-cas-dechec-durant-lexécution-dun-process)
  - [11. Composants de la palette](#11-composants-de-la-palette)
  - [11.1 Les liens](#111-les-liens)
  - [11.2 Les process neutres](#112-les-process-neutres)
  - [11.3 Les requêtes SQL](#113-les-requêtes-sql)
  - [12. Après l'exécution du process](#12-après-lexécution-du-process)
  - [12.1 Mettre à jour son workspace](#121-mettre-à-jour-son-workspace)
  - [12.2 Pousser son travail vers le SVN](#122-pousser-son-travail-vers-le-svn)
  - [12.3 Revenir à la dernière version du SVN](#123-revenir-à-la-dernière-version-du-svn)
  - [13. Gestion des conflits](#13-gestion-des-conflits)
  - [14. Atteindre un mapping depuis un process](#14-atteindre-un-mapping-depuis-un-process)
  - [15. Identifier le qui utilise quoi](#15-identifier-le-qui-utilise-quoi)
  - [16. SQL to parameter](#16-sql-to-parameter)
  - [16.1 Définition en début de process](#161-définition-en-début-de-process)
  - [16.2 Utilisation dans un mapping](#162-utilisation-dans-un-mapping)
  - [17 Afficher la date et l'heure actuelle](#17-afficher-la-date-et-lheure-actuelle)
  - [18 Ajouter un repository dans son workspace depuis le SVN](#18-ajouter-un-repository-dans-son-workspace-depuis-le-svn)
  - [19 Récupèrer la version du runtime](#19-récupèrer-la-version-du-runtime)
  - [19.1 Depuis Analytics](#191-depuis-analytics)
  - [20. Redéfinir les liens entre les différentes entitées du workspace](#20-redéfinir-les-liens-entre-les-différentes-entitées-du-workspace)
  - [21. Web Service, utilisation de la méthode (verb) GET](#21-web-service-utilisation-de-la-méthode-verb-get)
  - [21.1 Exemple 1 : 1 query parameter](#211-exemple-1--1-query-parameter)
  - [22. Mise en recette depuis designer sur le serveur de dev](#22-mise-en-recette-depuis-designer-sur-le-serveur-de-dev)
  - [23. Mise en recette depuis Analytics](#23-mise-en-recette-depuis-analytics)
  - [24. Utilisation du XML en In et en Out dans un mapping](#24-utilisation-du-xml-en-in-et-en-out-dans-un-mapping)
  - [25. Réaliser une condition en fonction de la valeur d'une variable (System) de Stambia](#25-réaliser-une-condition-en-fonction-de-la-valeur-dune-variable-system-de-stambia)
  - [26. Rendre obligatoire l'exécution d'un sous process avant de passer à la suite](#26-rendre-obligatoire-lexécution-dun-sous-process-avant-de-passer-à-la-suite)
  - [27. Faire appel à une variable](#27-faire-appel-à-une-variable)
  - [28. Attendre l'apparition d'un fichier](#28-attendre-lapparition-dun-fichier)
  - [29. Déplacer un ou des fichiers vers un autre dossier](#29-déplacer-un-ou-des-fichiers-vers-un-autre-dossier)
  - [30. Réduire totalement l'arborescence de l'onglet Project Explorer](#30-réduire-totalement-larborescence-de-longlet-project-explorer)
  - [31. Supprimer les champs qui n'existent plus en base lors d'un reverse](#31-supprimer-les-champs-qui-nexistent-plus-en-base-lors-dun-reverse)
  - [32. Réaliser une comparaison entre un élément de votre workspace et le même élement du SVN](#32-réaliser-une-comparaison-entre-un-élément-de-votre-workspace-et-le-même-élement-du-svn)
  - [33. Ajouter un champ qui indique la valeur du rang pour un élément par rapport à son noeud père dans un fichier XML](#33-ajouter-un-champ-qui-indique-la-valeur-du-rang-pour-un-élément-par-rapport-à-son-noeud-père-dans-un-fichier-xml)
  - [34. Utiliser la valeur d'une variable native d'un composant après son exécution](#34-utiliser-la-valeur-dune-variable-native-dun-composant-après-son-exécution)
  - [35. Lancer l'exécution d'une ligne de commande](#35-lancer-lexécution-dune-ligne-de-commande)
  - [35. Utiliser les paramètres d'une metadata](#35-utiliser-les-paramètres-dune-metadata)
  - [36. Copier et coller un composant](#36-copier-et-coller-un-composant)
  - [37. Réaliser un union dans un mapping](#37-réaliser-un-union-dans-un-mapping)
  - [38. Analyse des symboles lors d'une recherche d'impact](#38-analyse-des-symboles-lors-dune-recherche-dimpact)
  - [39. Attention à la méthode d'intégration durant un stage](#39-attention-à-la-méthode-dintégration-durant-un-stage)
  - [40. Obligation dans le SQL to parameter](#40-obligation-dans-le-sql-to-parameter)
  - [41. Consulter rapidement la nature d'un champ depuis un mapping](#41-consulter-rapidement-la-nature-dun-champ-depuis-un-mapping)
  - [42. Prioriser l'ordre d'exécution des jointures dans un mapping](#42-prioriser-lordre-dexécution-des-jointures-dans-un-mapping)
  - [43. Rechercher rapidement un process déjà exécuté](#43-rechercher-rapidement-un-process-déjà-exécuté)
  - [44. Modifier la structure d'un JSON](#44-modifier-la-structure-dun-json)
  - [45. JSON : La différence entre Array [] et Object {}](#45-json--la-différence-entre-array--et-object-)
  - [46. Accepter l'erreur sur le composant qui récupère des fichiers à l'aide d'un SFTP](#46-accepter-lerreur-sur-le-composant-qui-récupère-des-fichiers-à-laide-dun-sftp)
  - [47. Réaliser un Direct Bind](#47-réaliser-un-direct-bind)
  - [48. Zipper un fichier](#48-zipper-un-fichier)

## 1. Création de métadatas
<br>

## 1.1 CSV
<br>

étape 1: Créer une nouvelle métadata

![image info](./SourcesImages/inclureCSV_01.jpg)

étape 2: Choisir le type "File Server"

![image info](./SourcesImages/inclureCSV_02.jpg)

étape 3: Se laisser guider par l'assistant et enregistrer

## 1.2 XML
<br>

## 1.3 Web Service
<br>

étape 1: Créer une metadata avec le type suivant:

![image info](./SourcesImages/WebService_typeMetadata.jpg)


## 2. Selectionner l'affichage des champs d'une table
<br>

Sélectionner la table et cliquer ici (voir ci-dessous)

![image info](./SourcesImages/SelectionChampsAffichage_01.jpg)

## 3. Réaliser un mapping simple
<br>

À gauche le mapping (in) et à droite la table à mapper (out)

étape 1: Faites un glisser déposer du champ in vers le champ out<br>
étape 2: Sélectionner "Map"

## 3.1 Définir le type de mapping en sortie
<br>

étape 1: sélectionner le champ du in<br>
étape 2: sélectionner le champ du out<br>
étape 3: cliquer sur A pour "Aggreger", I pour "Insérer" et U pour "Mettre à jour" (voir ci-dessous)

![image info](./SourcesImages/DéfinirTypeMapping_01.jpg)

## 3.2 Lancer l'exécution d'un mapping
<br>

Depuis l'éditeur de Designer

étape 1: clique droit n'importe où et sélectionner "Execute" (voir ci-dessous)

![image info](./SourcesImages/LancerExecutionMapping_01.jpg)

## 3.3 Modifier la règle métier du mapping
<br>

Depuis l'éditeur de Designer

étape 1: sélectionner le champ du in<br>
étape 2: sélectionner le champ du out<br>
étape 3: cliquer sur l'item et choisir entre "Source", "Staging Area" ou "Target"

![image info](./SourcesImages/ModifierDefinitionMetierMapping_01.jpg)

## 3.4 Modifier la jointure entre deux tables
<br>

Depuis l'éditeur de Designer

étape 1: sélectionner la jointure<br>
étape 2: se rendre dans l'onglet "Propriété" (voir ci-dessous)

![image info](./SourcesImages/ModifierTypeJointure_01.jpg)

## 3.5 Dédoublonnage des valeurs lors d'un mapping
<br>

Depuis l'éditeur de Designer

étape 1: sélectionner l'item d'intégration (voir ci-dessous)

![image info](./SourcesImages/DédoubonnageDesValeurs_01.jpg)

étape 2: Se rendre dans les propriétés et cocher la case représentée ci-dessous

![image info](./SourcesImages/DédoubonnageDesValeurs_02.jpg)

## 4. Réaliser un filtre sur le champ d'une table
<br>

Depuis l'éditeur de Designer

étape 1: sélectionner le champ d'une table<br>
étape 2: faites un drag and drop vers un espace vide (voir ci-dessous)

![image info](./SourcesImages/FiltreSurLeChampDeTable_01.jpg)

## 4.1 Modifier la règle d'un filtre
<br>

étape 1: sélectionner le filtre<br>
étape 2: réaliser la modification prévue à cet effet (voir ci-dessous)

![image info](./SourcesImages/ModifierLaRegleDuFiltre.jpg)

## 5. Créer un stage
<br>

Depuis l'éditeur "Project Explorer"

étape 1: sélectionner un schéma<br>
étape 2: drag and drop dans la partie Designer (dans un espace vide)

alternative

étape 1: sélectionner un schéma<br>
étape 2: drag and drop sur le lien entre le in et le out

## 5.1 Ajouter un champ dans le stage
<br>

étape 1: sélectionner le stage<br>
étape 2: cliquer sur l'item (voir ci-dessous)

![image info](./SourcesImages/AjouterChampStage_01.jpg)

## 5.2 Définir l'expression d'un champ d'un stage
<br>

Depuis l'éditeur de Designer

étape 1: sélectionner le champ<br>
étape 2: se rendre dans l'onglet "Expresion" et rédiger l'expression

![image info](./SourcesImages/ModifierExpressionChampStage_01.jpg)

## 6. Se familiariser avec l'interface
<br>

## 6.1 Identifier l'item dans "Project Explorer" à partir du Designer
<br>

De façon automatique

étape 1: Activer la fonctionnalité en cliquant sur le bouton ci-dessous

![image info](./SourcesImages/IdentifierAutoSurProjectExplorer_01.jpg)

De façon manuelle

étape 1: Sélectionner une entité (schéma, base de donnée, table, fichier, ...) depuis le Designer<br>
étape 2: Activer la fonctionnalité en cliquant sur le bouton ci-dessous

![image info](./SourcesImages/IdentifierAutoSurProjectExplorer_02.jpg)

## 6.2 Réarranger les entités d'un mapping ou d'un process
<br>

Depuis la tool bar principale (celle du haut)

étape 1: Activer la fonctionnalité en cliquant sur le bouton ci-dessous

![image info](./SourcesImages/RéorganiserItemMappingProcess_01.jpg)

## 7. À savoir / Très important
<br>

<p style="color:#1E90FF";>Lorsque l'on réalise des modifications sur une base de données, elles ne sont visible que depuis la session. Pour les rendre visible à tous
il faut réaliser un "commit;" dans une fenêtre d'exécution SQL<p>
<p style="color:#FF0000";>Attention l'instruction SQL "Truncate" ne nécessite pas
l'exécution de la commande truncate, donc son exécution a un impact direct pour tous
les utilisateurs de la données modifiées (trucatée)</p>
<p style="color:#00FF00";>Heureusement, il existe la requête SQL "roll back;" qui permet d'annuler l'ensemble des manipulation réalisées avant le dernier commit.</p>

## 8. Les items/logos à connaître par coeur
<br>

Dans 001_Metadata/000_Server, on peut retrouver l'arborescence suivante:<br><br>

<div id="boiteimagetexte" STYLE="padding:0 0 0 0px;">

  ![image info](./SourcesImages/Logo_Folder_01.jpg) 

  <span STYLE="padding:0 0 0 4px;"> --> Dossier</span>

</div>
<div id="boiteimagetexte" STYLE="padding:0 0 0 0px;">

  ![image info](./SourcesImages/LogoMetadataDataMart_01.jpg) 

  <span STYLE="padding:0 0 0 4px;"> --> Dossier</span>

</div>



> <span STYLE="padding:0 0 0 20px;"> ![image info](./SourcesImages/Logo_Folder_01.jpg) --> Dossier</span><br>
<span STYLE="padding:0 0 0 40px;"> ![image info](./SourcesImages/LogoMetadataDataMart_01.jpg) --> MetaData</span><br>
<span STYLE="padding:0 0 0 60px;"> ![image info](./SourcesImages/LogoAssistantConnexionDataMart_01.jpg) --> Assistant</span><br>
<span STYLE="padding:0 0 0 80px;"> ![image info](./SourcesImages/LogoConnecteur_01.jpg) --> Configurateur  </span><br>
<span STYLE="padding:0 0 0 80px;"> ![image info](./SourcesImages/LogoSchema_01.jpg) --> Schema</span><br>

Dans 001_Metadata/001_Modele, on peut retrouver l'arborescence suivante:<br><br>

> <span STYLE="padding:0 0 0 20px;"> ![image info](./SourcesImages/Logo_Folder_01.jpg) --> Dossier </span><br>
<span STYLE="padding:0 0 0 40px;"> ![image info](./SourcesImages/LogoMetadataDataMart_01.jpg) --> MetaData </span><br>
<span STYLE="padding:0 0 0 60px;"> ![image info](./SourcesImages/LogoRaccourciSchema_01.jpg) --> Raccourci schema </span><br>
<span STYLE="padding:0 0 0 80px;"> ![image info](./SourcesImages/LogoDataStore_01.jpg) --> DataStore </span><br>
<span STYLE="padding:0 0 0 100px;"> ![image info](./SourcesImages/LogoChamp_01.jpg) --> Colmun </span><br>
<span STYLE="padding:0 0 0 100px;"> ![image info](./SourcesImages/LogoPrimaryKey_01.jpg) --> Primary Key </span><br>
<span STYLE="padding:0 0 0 100px;"> ![image info](./SourcesImages/LogoVariable_01.jpg) --> Variable </span><br>
<span STYLE="padding:0 0 0 100px;"> ![image info](./SourcesImages/LogoFonction_01.jpg) --> Fonction </span><br>
<span STYLE="padding:0 0 0 100px;"> ![image info](./SourcesImages/LogoFilter_01.jpg) --> Filter </span><br>
<span STYLE="padding:0 0 0 100px;"> ![image info](./SourcesImages/LogoIndex_01.jpg) --> Index </span><br>

Lorsque l'on intègre des fichiers de type CSV, on peut avoir l'arborescence suivante:<br><br>

> <span STYLE="padding:0 0 0 20px;"> ![image info](./SourcesImages/Logo_Folder_01.jpg) --> Dossier </span><br>
<span STYLE="padding:0 0 0 40px;"> ![image info](./SourcesImages/LogoMetadataDataMart_01.jpg) --> MetaData </span><br>
<span STYLE="padding:0 0 0 60px;"> ![image info](./SourcesImages/LogoServer_01.jpg) --> Server </span><br>
<span STYLE="padding:0 0 0 80px;"> ![image info](./SourcesImages/LogoDirectory_01.jpg) --> Directory </span><br>
<span STYLE="padding:0 0 0 100px;"> ![image info](./SourcesImages/LogoFileCSV_01.jpg) --> File </span><br>
<span STYLE="padding:0 0 0 120px;"> ![image info](./SourcesImages/LogoChamp_01.jpg) --> Field </span><br>
<span STYLE="padding:0 0 0 120px;"> ![image info](./SourcesImages/LogoComputedField_01.jpg) --> Computed Field </span><br>

Lorsque l'on créé un Web service: on a les éléments suivant qui le constitue:<br><br>

<span STYLE="padding:0 0 0 20px;"> ![image info](./SourcesImages/ItemWebService.jpg) --> Web Service</span> <br>
<span STYLE="padding:0 0 0 40px;"> ![image info](./SourcesImages/WebService_Service.jpg) --> Service </span><br>
<span STYLE="padding:0 0 0 60px;"> ![image info](./SourcesImages/WebService_Verb2.jpg) --> Verb (GET, POST, PATCH, ...)</span><br>
<span STYLE="padding:0 0 0 80px;"> ![image info](./SourcesImages/WebService_Operation.jpg) --> Opération </span><br>
<span STYLE="padding:0 0 0 100px;"> ![image info](./SourcesImages/WebService_Input.jpg) --> Sens du flux (in, out, fault) </span><br>
<span STYLE="padding:0 0 0 120px;"> ![image info](./SourcesImages/WebService_Part.jpg) --> Part (élément structurant le sens du flux) </span><br>
<span STYLE="padding:0 0 0 140px;"> ![image info](./SourcesImages/ListeElementsXML.jpg) --> Liste d'éléments (XML) </span><br>
<span STYLE="padding:0 0 0 140px;"> ![image info](./SourcesImages/ListeElementsJSON.jpg) --> Liste d'éléments (JSON) </span><br>

## 9. Avant l'exécution du process
<br>

Avant de lancer l'exécution d'un mapping ou d'un process, il faut s'assurer d'être connecté à un runtime.<br>
En général, les runtimes sont déjà là prêts à être utilisés. (voir ci-dessous)

![image info](./SourcesImages/SelectionRuntime_01.jpg)

## 10. En cas d'echec durant l'exécution d'un process
<br>

Lorsque vous lancez l'exécution d'un process ou d'un mapping, un nouvel onglet apparaît (voir ci-contre)

![image info](./SourcesImages/EnCasDerreur_01.jpg)

Le contenu ressemble à ceci si l'exécution du process n'est pas allé jusqu'au bout (voir ci-contre)

![image info](./SourcesImages/EnCasDerreur_02.jpg)

On rappelle, que le bleu symbolise une réussite du sous-process, le rouge un echec du sous-process et le gris un sous-process en attente d'exécution.

étape 1: double cliquer sur le sous-process de couleur rouge, jusqu'à obtenir un sous-process avec un signe particulier (voir ci-contre)

![image info](./SourcesImages/EnCasDerreur_03.jpg)

étape 2: Double cliquer sur le panneau d'avertissement, une fenêtre apparaît et vous indique la source du problème à réger (voir un exemple ci-desous)

![image info](./SourcesImages/EnCasDerreur_04.jpg)

Vous remarquerez qu'un historique s'est formé en dessous de l'onglet, un "double-clique" fait apparaître un niveau supplémentaire. Le sense de lecture est de la gauche vers la droite. (voir ci-dessous)

![image info](./SourcesImages/EnCasDerreur_05.jpg)

## 11. Composants de la palette
<br>

Depuis le designer associé aux process vous avez accès à la palette contenant des composants regroupés en différentes sections (voir ci-dessous)

![image info](./SourcesImages/Palette.jpg)

## 11.1 Les liens
<br>

Dans la section "Link"

Pour ordonnancer les différents sous-process entre eux.

![image info](./SourcesImages/PaletteLink_01.jpg)

## 11.2 Les process neutres
<br>

Dans la section "Miscellaneous"

Lorsque l'on a des traitements paralléles asynchrone, on peut temporiser avec l'item "Empty action".

![image info](./SourcesImages/PaletteSectionMiscellaneous_01.jpg)

## 11.3 Les requêtes SQL
<br>

Dans la section "SQL"

Lorsque l'on souhaite exécuté des requêtes SQL on utilisera l'item "SQL Operation"

![image info](./SourcesImages/PaletteSectionSQL_01.jpg)

## 12. Après l'exécution du process
<br>

## 12.1 Mettre à jour son workspace
<br>

Faire un clique droit sur un dossier raçine, passer la sourie sur 'Team' et sélectionner 'Update to Head', (voir ci-dessous).

![image info](./SourcesImages/UpdateToHead.jpg)

## 12.2 Pousser son travail vers le SVN

Faire un clique droit sur un dossier raçine, passer la sourie sur 'Team' et sélectionner 'Commit', (voir ci-dessous).

![image info](./SourcesImages/Commit.jpg)

## 12.3 Revenir à la dernière version du SVN
<br/>

Faire un clique droit sur un dossier raçine, passer la sourie sur 'Team' et sélectionner 'Revert', (voir ci-dessous).

![image info](./SourcesImages/Revert.jpg)

## 13. Gestion des conflits
<br>

étape 1: Identifier l'élément le plus fin qui est en conflit

étape 2: Sélectionnez-le via "Project Explorer", faire un clique droit, passer la sourie sur 'Open with' et sélectionner 'Text Editor', (voir ci-dessous).

![image info](./SourcesImages/ConflitTextEditor.jpg)

## 14. Atteindre un mapping depuis un process
<br/>

Depuis l'éditeur de Designer du process

étape 1: Cliquer sur le mapping, puis sur le logo (voir ci-dessous)

![image info](./SourcesImages/AccèderAuMapping.jpg)

## 15. Identifier le qui utilise quoi
<br/>

Depuis le Project Explorer

étape 1: Sélectionner n'importe quel élément (table, fichier, champ, variable, ...) avec un clique gauche

étape 2: Se rendre dans l'onglet "Impact" (voir ci-dessous)

![image info](./SourcesImages/IdentifierImpact.jpg)

étape 3: Actualiser les résultats

![image info](./SourcesImages/IdentifierImpact2.jpg)

étape 4: Déployer les sections

Si l'élément est utilisé, il y aura une section "Used by".</br>
Il y aura la section "container" pour retrouver où et dans quoi est contenu l'élément depuis le Project Explorer.

![image info](./SourcesImages/IdentifierImpact3.jpg)

## 16. SQL to parameter
<br/>

## 16.1 Définition en début de process
<br/>

Depuis l'éditeur du design du process

étape 1: On ouvre la palette

![image info](./SourcesImages/Palette.jpg)

étape 2: On choisis la section "Sql"

![image info](./SourcesImages/PaletteSectionSQL_01.jpg)

étape 3: On drag and drop l'élément "Sql To Parameters"

![image info](./SourcesImages/SQL_To_Parameter.jpg)

étape 4: Dans la partie "Expression Editor", il faut entrer sa requête en respectant la structure suivante

1) Nom du paramètre
2) Type du paramètre
3) Requête SQL qui donne la valeur du paramètre

![image info](./SourcesImages/SQL_To_Parameter_Structure_à_respecter.jpg)

étape 5: On se rend dans l'onglet "Project Explorer" et on drag and drop le schéma dont dépend la requête SQL.

![image info](./SourcesImages/SchemaDansSqlToParameter.jpg)

## 16.2 Utilisation dans un mapping
<br/>

Depuis l'éditeur du mapping

étape 1: Selectionner soit une jointure, soit un champ quelconque

étape 2: Se rendre dans l'onglet "Expression Editor"

Si le paramètre est de type (chiffré)

![image info](./SourcesImages/UtilisationSqlToParameterDansMapping.jpg)

Si le paramètre est de type (alphanumérique)

![image info](./SourcesImages/UtilisationSqlToParameterDansMapping2.jpg)

## 17 Afficher la date et l'heure actuelle
<br/>

Depuis l'éditeur du mapping

Dans l'onglet "Expression Editor"

![image info](./SourcesImages/DateEtHeureActuelleExpressionEditor.jpg)

Dans le champ "Physical Name"

![image info](./SourcesImages/DateEtHeureActuelleNomFichier.jpg)

## 18 Ajouter un repository dans son workspace depuis le SVN
<br/>

étape 1: Cliquer sur le bouton en haut à droite "SVN Repository Exploring"

![image info](./SourcesImages/BoutonSVNRepository.jpg)

étape 2: déplier la section correspondant à l'adresse du SVN contenant les repository

![image info](./SourcesImages/AdresseSVN.jpg)

étape 3: Faire un clique droit sur le repository

![image info](./SourcesImages/AdresseSVN.jpg)

étape 4: Cliquer sur "checkout

![image info](./SourcesImages/AdresseSVN.jpg)

## 19 Récupèrer la version du runtime
<br/>

## 19.1 Depuis Analytics
<br/>

étape 1: Sélectionner la bonne vue

![image info](./SourcesImages/SelectionnerVuDepuisAnalytics.jpg)

étape 2: Déployer les runtimes

![image info](./SourcesImages/DeployerRuntimesDepuisAnalytics.jpg)

étape 3: Ouvrir le runtime

![image info](./SourcesImages/OuvrirRuntimesDepuisAnalytics.jpg)

étape 4: Cliquer sur la section "Command" sur le nouvel onglet

![image info](./SourcesImages/SectionCommandDepuisAnalytics.jpg)

étape 5: Entrer "versions" dans la 'inputbox'

![image info](./SourcesImages/SaisirVersionDansCommand.jpg)

étape 6: Cliquer sur "Execute" et les résultats seront affichés en dessous

![image info](./SourcesImages/ResultatVersionRuntimes.jpg)

## 20. Redéfinir les liens entre les différentes entitées du workspace
<br>

étape 1: Se rendre dans l'onglet "Impact"

![image info](./SourcesImages/IdentifierImpact.jpg)

étape 2: Cliquer sur la petite fléche

![image info](./SourcesImages/AutreOptionDeImpact.jpg)

étape 3: Cliquer sur "Rebuild cache"

![image info](./SourcesImages/RebuildCache.jpg)

## 21. Web Service, utilisation de la méthode (verb) GET

## 21.1 Exemple 1 : 1 query parameter

Depuis le designer, côté opération

![image info](./SourcesImages/DesignerOperationGet1QueryParameter.jpg)

<span STYLE="padding:0 0 0 40px;"> 1 --> Nom de l'opération </span><br>
<span STYLE="padding:0 0 0 40px;"> 2 --> Le complément de l'URL </span><br>
<span STYLE="padding:0 0 0 40px;"> 3 --> La valeur de cette variable renvoie un token </span><br><br>

Depuis le designer, côté part

![image info](./SourcesImages/WebService_Part_Properties_Designer.jpg)

Avec le reverse, côté opération

![image info](./SourcesImages/WebService_Reverse_Operation_Get_1QP.jpg)

## 22. Mise en recette depuis designer sur le serveur de dev
<br>

étape 1 : Se connecter au runtime de dev

étape 2 : Clique droit sur le process

étape 3 : Sélectionner Build/Execute

étape 4 : Sélectionner Publish

## 23. Mise en recette depuis Analytics
<br>

Ouvrir la documentation dédié à Stambia Analytics

## 24. Utilisation du XML en In et en Out dans un mapping 
<br>

Dans le cadre d'un appel à un web service

Dans la section "INT" de l'appel au web service (partie entrante)

![image info](./SourcesImages/IntOfWebService.jpg)

Dans l'onglet "Properties" indiquer un nom de fichier XML pour le champ "Out File Name"

![image info](./SourcesImages/XMLofIn.jpg)

Dans la section "LOAD" de la table de reception (partie sortante)

![image info](./SourcesImages/Load.jpg)

Dans l'onglet "Properties" indiquer un nom de fichier XML pour le champ "In File Name"

![image info](./SourcesImages/XMLofOUT.jpg)


## 25. Réaliser une condition en fonction de la valeur d'une variable (System) de Stambia
<br>

Cliquer sur le lien

Se rendre dans "Expression Editor"

Exemple de conditions en utilisant les variables du composant source

![image info](./SourcesImages/ConditionLinkFromVariableComposantSource.jpg)

1 : C'est le nom donné au composant source (à partir du lien)<br>
2 : C'est le nom de la variable généré après exécution du composant source 

## 26. Rendre obligatoire l'exécution d'un sous process avant de passer à la suite
<br>

Cliquer sur le lien

Se rendre dans propriété

Changer la valeur de Triggering Behavior

![image info](./SourcesImages/RendreobligatoireExecutionSousProcess.jpg)

## 27. Faire appel à une variable 
<br>

Depuis la fenêtre "Project Explorer"

étape 1 : Drag and Drop la variable dans le process

étape 2 : Sélectionner la variable, on recalculer la valeur de la variable dans les propriétés de la façon suivante:

![image info](./SourcesImages/RefreshVariable.jpg)

étape 3 : utiliser la valeur d'une variable dans un mapping de la façon suivante:

![image info](./SourcesImages/UtilisationVariableDansMapping.jpg)


## 28. Attendre l'apparition d'un fichier 
<br>

Ouvrir la palete

Se rendre dans la rubrique "File"

Choisir l'item "Wait for files" et le drag and drop dans le designer


![image info](./SourcesImages/ExempleMoveFile.jpg)


## 29. Déplacer un ou des fichiers vers un autre dossier
<br>

Ouvrir la palete

Se rendre dans la rubrique "File"

Choisir l'item "Move files" et le drag and drop dans le designer

exemple:

![image info](./SourcesImages/ExempleWaitFile.jpg)

## 30. Réduire totalement l'arborescence de l'onglet Project Explorer
<br>

Se rendre dans l'onglet "Project Explorer"

Cliquer sur le bouton suivant:

![image info](./SourcesImages/ReduireCompletementArborescence.jpg)

(ou utiliser le raccourci Ctrl+Shift+/)

## 31. Supprimer les champs qui n'existent plus en base lors d'un reverse
<br>

Se rendre dans les propriétés d'un schéma/utilisateur

Cliquer sur la case à cocher "Delete No Longer Existing Column":

![image info](./SourcesImages/SupprimerChampsInexistantEnBaseDurantReverse.jpg)

## 32. Réaliser une comparaison entre un élément de votre workspace et le même élement du SVN
<br>

Se rendre dans l'onglet "Project Explorer"

Sélectionner avec un clique gauche l'élément à comparer

faire un clique droit et selectionner "Compare with"

![image info](./SourcesImages/CompareWith.jpg)

Sélectionner "Base révision"

![image info](./SourcesImages/CompareWithBaseRevision.jpg)

C'est à vous de jouer, une nouvelle fenêtre est apparue séparé en deux: la partie de gauche est votre workspace et la partie de droite est votre SVN.

## 33. Ajouter un champ qui indique la valeur du rang pour un élément par rapport à son noeud père dans un fichier XML
<br>

Assurez-vous que votre élément soit contenu dans une séquence

![image info](./SourcesImages/ElementXMLsousUneSequence.jpg)

Clique droit sur l'élément / New / Property Field

![image info](./SourcesImages/PropertyFieldpourElementFichierXML.jpg)

Dans les propriétés, entrer un nom pour "Name" et choisisser "nodeLocalPosition" pour "Property"

![image info](./SourcesImages/PropertyDuRangElementFichierXML.jpg)

PropertyDuRangElementFichierXML

## 34. Utiliser la valeur d'une variable native d'un composant après son exécution
<br>

exemple:
```
__ctx__.sumVariable("SQL_STAT_INSERT","010_MDW_OCT_Exp_Article") > 0
```

sumVariable : correspond à l'onglet contenant toutes les variables (system et custom)

"SQL_STAT_INSERT" : nom de la variable dont l'on veut récupérer la valeur

"010_MDW_OCT_Exp_Article" : nom du composant (mapping en l'occurence) sur lequel on va récupérer la valeur de la variable

## 35. Lancer l'exécution d'une ligne de commande
<br>

étape 1 : Dans la palette, ouvrir la section "Miscellaneous"

![image info](./SourcesImages/OperatingSystemCommand.jpg)

## 35. Utiliser les paramètres d'une metadata
<br>

Considérons l'object "MAPS" comme une metadata permetant la connexion à un SFTP.

![image info](./SourcesImages/MetadataConnexionSFTP.jpg)
MetadataConnexionSFTP

étape 1 : Drag and drop la metadata dans un composant qui le peut OSC (Operating System Command), SQL Operations ...

![image info](./SourcesImages/MetadataAccesSFTPDansOSC.jpg)

étape 2 : Accèder aux propriétés de la metadata MAPS

étape 3 : Faire un clique droit sur "MAPS" et rester sur "Global XPath"

![image info](./SourcesImages/VariablesUtilisableGlobalXPath.jpg)

Prennons par exemple : [host]

étape 4 : Se rendre dans la partie "expression editor" du composant

étape 5 : Entrer ceci pour faire appel à la variable host de MAPS
```
%x{$MAPS/tech:host()}x%
```

MAPS : Le nom de la metadata que l'on a drag en drop dans le composant

host : le nom de la variable présent dans la liste des variables constituant Global XPath de la metadata.

## 36. Copier et coller un composant
<br>

étape 1 : Clique gauche sur le composant

étape 2 : Faire un clique droit sur le composant et se placer sur "Edit"

![image info](./SourcesImages/EditForCopyPaste.jpg)

étape 3 : Clique gauche sur "Copy"

étape 4 : Faire un clique droit là où l'on souhaite placer le composant

étape 5 :  Clique gauche sur "Paste"

## 37. Réaliser un union dans un mapping
<br>

étape 1 : Faite en sorte qu'il y ait un stage entre la ou les tables en entrée et la table en sortie

étape 2 : Sélectionner le mapping

étape 3 : Clique gauche sur "Create Set"

![image info](./SourcesImages/StageCreateSet.jpg)

étape 4 : Cliquer sur le nouveau Set et alimenter les champs

![image info](./SourcesImages/StageNewSet.jpg)

étape 5 : Cliquer sur le stage et se rendre dans l'onglet "Expression Editor" et entrer la formule suivante

![image info](./SourcesImages/StageExpressionEditorFormuleUnion.jpg)

## 38. Analyse des symboles lors d'une recherche d'impact
<br>

Lorsque l'on recherche les impacts d'une table par exemple :

étape 1 : Selectionner la table depuis "Project Explorer"

étape 2 : Se rendre dans l'onglet "impact"

étape 3 : actualiser

étape 4 : Déplier la secton "Used by" et analyser les items suivants

![image info](./SourcesImages/ImpactProcess.jpg)

Lorsque la table est utilisé dans un process, dans un SQL Operation, SQL to parameter ...

![image info](./SourcesImages/ImpactTableSortie.jpg)

Lorsque la table est utilisé en entrée dans un mapping

![image info](./SourcesImages/ImpactTableEntree.jpg)

Lorsque la table est utilisé en sortie dans un mapping

## 39. Attention à la méthode d'intégration durant un stage
<br>

étape 1 : Lorsque vous ajoutez un stage via un drag and drop du schéma de la table cible, vous obtenez ceci

![image info](./SourcesImages/StageAvecTableDeSortie.jpg)

étape 2 : Cliquer sur le "INT" de la table de sortie en haut à droite

![image info](./SourcesImages/INT_Of_Table_Sortie.jpg)

étape 3 : Se rendre dans l'onglet propriété et vérifié que l'on a bien

![image info](./SourcesImages/MethodeIntegrationAfterStageCorrecte.jpg)

## 40. Obligation dans le SQL to parameter
<br>

Note : Même si l'on définit un paramètre via une requête SQL qui n'a pas besoin de table, comme avec dual, il faut tout de même insérer un schéma de base de données dans le composant SQL to parameter.

## 41. Consulter rapidement la nature d'un champ depuis un mapping
<br>

étape 1 : Sélectionner avec un clique gauche le champ d'une table

![image info](./SourcesImages/SelectionChampTable.jpg)

étape 2 : Se rendre dans l'onglet "Propriété"

étape 3 : Sélectionner avec un clique gauche la section "Structure"

![image info](./SourcesImages/TableChampStructure.jpg)

étape 4 : Identifier l'information "Size" et "Type"

![image info](./SourcesImages/TableChampStructureInfos.jpg)

## 42. Prioriser l'ordre d'exécution des jointures dans un mapping
<br>

étape 1 : Sélection une jointure 

![image info](./SourcesImages/Jointure.jpg)

étape 2 : Se rendre dans l'onglet "Propriété"

étape 3 : Sélectionner avec un clique gauche la section "Advanced"

![image info](./SourcesImages/JointurePropertiesAdvanced.jpg)

étape 4 : Entrer un nombre entier > 0 

![image info](./SourcesImages/JointurePropertiesAdvancedOrdre.jpg)

## 43. Rechercher rapidement un process déjà exécuté
<br>

Un exemple, vous recherchez la dernière exécution du process "GNX_MDW_Int_F01_Article_Quable_ora"

étape 1 : Se rendre dans l'onglet "Sessions"

étape 2 : Entrer une partie du nom du process recherché

![image info](./SourcesImages/ProcessRecherché.jpg)

L'utilisation des '*' remplace les '%' comme lors d'un like '%element%' dans une requête SQL.

## 44. Modifier la structure d'un JSON
<br>

étape 1 : Sélectionner soit l'élément array soit l'élément object

![image info](./SourcesImages/JsonObjectOrArray.jpg)

étape 2 : Réaliser un clique droit sur l'élément et sélectionner "Change to"

![image info](./SourcesImages/JsonArrayChangeTo.jpg)

étape 3 : Cliquer sur l'élément de la bascule

## 45. JSON : La différence entre Array [] et Object {}
<br>

Array [] : un ensemble d'élément sans préciser la variable<br>
Object {} : un ensemble d'élément sans préciser la variable

```
["chat", "chien", "rat", "requin"]

{"animal" : "chat",
  "animal" : "chien",
  "animal" : "rat",
  "animal" : "requin"}
```

## 46. Accepter l'erreur sur le composant qui récupère des fichiers à l'aide d'un SFTP
<br>

étape 1 : Sélectionner le composant

![image info](./SourcesImages/GetFileFromSFTP.jpg)

étape 2 : Se rendre dans les propriétés

étape 3 : Cocher la case "Errors Accepted"

![image info](./SourcesImages/GetFileFromSFTPErrorAccepted.jpg)

## 47. Réaliser un Direct Bind
<br>

Pour rappel: Un direct bind permet de boucler sur toutes les lignes d'une table en exécutant à chaque fois une procédure

étape 1 : Sélectionner le composant, exemple un SQL Operation (avec un Select)

![image info](./SourcesImages/SQLOperation.jpg)

étape 2 : Clique gauche sur la flèche du direct bind et cliquer sur le composant cible

![image info](./SourcesImages/LienDirectBind.jpg)

## 48. Zipper un fichier
<br>

étape 1 : Se rendre dans la palette et déplier la section File

![image info](./SourcesImages/Palette.jpg)

étape 2 : Faire un clique gauche sur l'élément Zip files

![image info](./SourcesImages/Palette_Files_ZipFiles.jpg)

étape 3 : Renseigner à minima ces deux champs dans les propriétés

![image info](./SourcesImages/ZipFiles_propriétés.jpg)

