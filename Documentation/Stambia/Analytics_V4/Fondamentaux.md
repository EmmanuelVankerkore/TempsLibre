<head>
<style>
#boiteimagetexte {display:flex; align-items: flex-start}
</style>
</head>

# Tuto sur les fondamentaux Stambia Analytics


## 0. Se connecter à Stambia Analytics

Prod : http://scsmdw01:8080/analytics/stambia

User : ntico<br>
Mot de passe : Nt1c0@fr

## 1. Selectionner un type de vue
<br>

étape 1 : Identifier l'image ci-dessous en haut à gauche de l'application

![image info](./SourcesImages/SelectionVue.jpg)

étape 2 : Selectionner toutes les vues ou une vue en particulier

![image info](./SourcesImages/SelectionnerLaVue.jpg)


## 2. Créer ses propres suivis (non publics)
<br>

étape 1 : Identifier la partie "My Session Reports"

![image info](./SourcesImages/PartieExplorer.jpg)

étape 2 : Faire un clic droit sur "My Session Reports"

![image info](./SourcesImages/ItemsInMySessionReports.png)

étape 3 : Clique gauche sur "New Folder" pour ajouter un nouveau dossier

étape 4 : Clique gauche sur "New Session Report" pour ajouter un nouveau suivi

## 3. Acccéder aux suivis (publics)
<br>

étape 1 : Cliquer sur "Public Session Reports"

![image info](./SourcesImages/PublicSessionReports.jpg)

## 4. Publier un nouveau process
<br>

étape 0 : Sur Stambia Designer

Cliquer droit sur le process "Build/Execute"

![image info](./SourcesImages/DesignerBuildExecute.jpg)

Se rendre sur le process "Build"

![image info](./SourcesImages/DesignerBuild.jpg)

Cliquer gauche sur "Package With Documentation"

![image info](./SourcesImages/DesignerPackageWithDocumentation.jpg)

Se rendre le dossier "D:\stambiaDesigner\Stambia_Designer_S19-0-27\stambiaRuntime\build\packages" en local

Vous pouvez constatez la présence d'un fichier ayant la forme suivante : {nom_du_process}.pck

![image info](./SourcesImages/LocalExempleFichierPackage.jpg)

étape 1 : Sélectionner la partie "Deployments"

![image info](./SourcesImages/Deployments.jpg)

étape 2 : Sélectionner avec un double cilque un gestionnaire de déploiement

![image info](./SourcesImages/GestionnaireDeDeploiments.jpg)

étape 3 : Importer un package (fichier permettant la construction du delivery)

![image info](./SourcesImages/ImporterPackage.jpg)

étape 4 : Sélectionner le package sur votre espace de stockage en local

étape 5 : Votre process apparait dans la fenêtre, vous pouvez le drag and drop

![image info](./SourcesImages/PackageImporteDansGestionnaireDeploiement.jpg)

En l'état, votre package est :<br>
  importé :     oui<br>
Le livrable est :<br>
  construit :   non<br>
  deployé :     non

étape 6 : Ajouter une spécification de déploiement, clique droit sur "Deployment Specifications"

![image info](./SourcesImages/SpecificationDeploiement.png)

étape 7 : Sélectionner un schema de déploiement

![image info](./SourcesImages/SchemaDeploiement.jpg)

étape 8 : Ajouter un schéma associé à un runtime et vérifier qu'il n'y pas pas d'informations manquantes

![image info](./SourcesImages/ConfigurationSchemaDeploiement.jpg)

étape 9 : Selectionner la spécification de déploiement

![image info](./SourcesImages/SelectionSpecificationDeploiement.jpg)

étape 10 : Construction du delivery, clique droit et selectionner "Build Deliveries"

![image info](./SourcesImages/BuildDelivery.png)

On a construit notre livrable, Donc.

En l'état, votre package est :<br>
  importé :     oui<br>
Le livrable est :<br>
  construit :   oui<br>
  deployé :     non

étape 11 : Publication de notre livrable, clique droit sur la spécification de déploiement

![image info](./SourcesImages/PublishDelivery.png)

étape 12 : Ne pas oublié de sauvegarder --> Ctrl + S

C'est fini, le process est publié !

## 5. Importer un package dont le process a déjà été publié
<br>

étape 1 : Importer le package associé à la nouvelle version du process

![image info](./SourcesImages/ImporterPackage.jpg)

étape 2 : Observer à présent votre process notifié de la façon suivante

![image info](./SourcesImages/ConflitApresImportPackage.jpg)

étape 3 : Observer la notification associée au livrable publié

Explication : Lorsque l'on importe un nouveau package d'un process déjà existant, Stambia Analytics considère qu'il faut prendre en compte le package le plus récent. Mais le package le plus récent ne correspond pas à la version du livrable publié.

![image info](./SourcesImages/PackageMissMatch.jpg)

Il nous faut donc construire un nouveau livrable à partir nouveau package

étape 4 : Construction du delivery, clique droit et selectionner "Build Deliveries"

![image info](./SourcesImages/BuildDelivery.png) 

étape 5 : Publication de notre livrable, clique droit sur la spécification de déploiement

![image info](./SourcesImages/PublishDelivery.png)

## 6. Revenir sur un package antérieur
<br>

étape 1 : Sélectionner l'ancien package

![image info](./SourcesImages/SelectionOldPackage.jpg)

étape 2 : Définir le package comme celui à utiliser lors de la construction

![image info](./SourcesImages/SetAsCurrentPackage.png)

## 7. Consulter l'historique des exécutions d'un process sur un runtime
<br>

étape 1 : Se rendre dans la section "Runtimes"

![image info](./SourcesImages/Runtimes.jpg)

étape 2 : Double clique gauche sur le runtime

![image info](./SourcesImages/SelectionDuRuntimes.jpg)

étape 3 : Ouvrir "wsdl" pour les web services ou "default" pour les autres

étape 4 : Double clique gauche sur un process

Une nouvelle fenêtre apparaît, c'est l'historique des exécution du process sur ce runtime.

## 8. Consulter les paramètres lors de l'exécution d'un process sur un runtime
<br>

étape 1 : Se rendre dans la section "Runtimes"

![image info](./SourcesImages/Runtimes.jpg)

étape 2 : Double clique gauche sur le runtime

![image info](./SourcesImages/SelectionDuRuntimes.jpg)

étape 3 : Ouvrir "wsdl" pour les web services ou "default" pour les autres

étape 4 : Double clique gauche sur un process

étape 5 : Selection une exécution est vous trouverez les paramètres avec lesquels il a été lancé

![image info](./SourcesImages/ParameterExecutionProcessRuntime.jpg)

## 9. Vérifier que l'on est bien connecté aux runtimes
<br>

étape 1 : Se rendre dans l'onglet "Logs"

![image info](./SourcesImages/ConnectionAuxRuntimes.jpg)

## 10. Relancer l'application Apache Tomcat
<br>

étape 1: Appuyer sur la touche windows

étape 2: Entrer mstsc

étape 3: Appuyer sur entrée

étape 4: Dans la fenêtre de connexion bureau à distance, entrer "scsmdw01"

étape 5: Appuyer sur "Connexion"

étape 6: Saisir pour le user "scsmdw01\administrateur"

étape 7: Saisir pour le password "AdminTopS"

étape 8: Se rendre dans l'application "Services"

étape 9: Arrêter le service "Apache Tomcat 8.5 Tomcat8"

étape 10: si étape 9 ne fonctionne pas, faire un clique droit sur l'application "Commons Daemon Service Runner" et clique gauche sur "Fin de tâche"

étape 11: Démarrer le service "Apache Tomcat 8.5 Tomcat8"

étape 12: Fermer le bureau à distance