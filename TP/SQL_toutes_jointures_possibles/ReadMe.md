# SQL Join Analyzer

Ce projet permet d’analyser une requête SQL complexe et de générer automatiquement toutes les sous-requêtes correspondant aux différentes combinaisons de jointures.


## Définitions

- **ODI (Oracle Data Integrator)**  
  Un outil d’intégration de données permettant de concevoir des flux ETL (Extract, Transform, Load).  
  Dans ce projet, ODI est utilisé pour simuler une interface et générer la requête SQL initiale.

- **Requête SQL**  
  Une instruction rédigée en langage SQL (Structured Query Language) pour interroger une base de données.  
  Exemple simple :  
  ```sql
  SELECT * FROM Clients WHERE Pays = 'FR';

## Contexte

La requête SQL utilisée en entrée est généralement le résultat d’une **simulation d’interface dans l’outil ODI**.  
Elle contient de nombreuses jointures entre tables, difficiles à tester ou valider manuellement.  

L’objectif du projet est de :
- Identifier automatiquement les jointures.  
- Construire un graphe représentant les relations entre tables.  
- Générer toutes les combinaisons possibles de jointures pour produire des sous-requêtes de contrôle.  

## Préparation et exécution

### Étape 1 : Préparer le fichier SQL d’entrée
Avant d’exécuter le programme, il faut annoter la requête avec des balises spécifiques :  
- Ajouter `/**/` pour délimiter la zone des jointures :  
  - la première balise **avant la première jointure** ;  
  - la seconde balise **après la dernière jointure**.  
- Ajouter `/* Jointure */` juste **avant chaque `AND`** introduisant une condition de jointure.  

### Étape 2 : Configurer les chemins
Dans le script Python :  
- Définir correctement les variables `pathfile_in` (fichier SQL d’entrée) et `pathfile_out` (fichier de sortie).  
- Vérifier que les chemins contiennent bien deux `\\` (échappement nécessaire en Python).  

### Étape 3 : Lancer le programme
Exécuter la commande suivante :  

```bash
python run.py
