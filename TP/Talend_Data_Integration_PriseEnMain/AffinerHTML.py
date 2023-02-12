# -*- coding: utf-8 -*-
"""
Created on Tue Nov  1 23:28:14 2022
@objectif: Supprimer le contenu html inutile à la documentation du flux Talend
@author: Surichat
"""

def texteSubNonVoulu(texte, nonVouluDebut, nonVouluFin):
    return texte[:nonVouluDebut] + texte[nonVouluFin:]

def concatTextesSubNonVoulu(listeTexte, listeNonVoulu):
    newTexte = ""
    for i in range(len(listeTexte)):
        newTexte = newTexte + texteSubNonVoulu(listeTexte[i], listeNonVoulu[i][0], listeNonVoulu[i][1])
    return newTexte

# Folders

path_file_input = "C:\\Dev\\GitHub\\Repository\\TP\\Talend_Data_Integration_PriseEnMain\\SAS\\DefinirContextDepuisUnFichier_1.1\\DefinirContextDepuisUnFichier"
path_folder_output = "C:\\Dev\\GitHub\\Repository\\TP\\Talend_Data_Integration_PriseEnMain\\DocumentationJob"

# Stocker dans une liste toutes les lignes du fichier

Inputfile = open(path_file_input + "\\DefinirContextDepuisUnFichier_1.1.html", 'r')
contenuFichier = Inputfile.readlines()
Inputfile.close()

# Stocker dans un dictionnaire les thématiques selectionnées par l'utilisateur

InputfileContext = open("C:\\Dev\\GitHub\\Repository\\TP\\Talend_Data_Integration_PriseEnMain\\ThematiqueALaCarte.txt", 'r')
contenuContexte = InputfileContext.readlines()
InputfileContext.close()

dicoContext = {contenuContexte[i][:44].strip(): contenuContexte[i][-4:].strip() for i in range(len(contenuContexte)-1) if (contenuContexte[i][-4:].strip() == "non") }



# Création d'une liste constituer des tronçons du texte


"""
Description du projet                       --> thématique 1
Description                                 --> thématique 2
Prévisualiser l'image                       --> thématique 3
Paramètres_Paramètres supplémentaires       --> thématique 4.1
Paramètres_Statut & Logs                    --> thématique 4.2
Liste des contextes_1                       --> thématique 5.1
Liste des composants_1                      --> thématique 6.1
Description des composants_1                --> thématique 7.1
"""

# Value --> [sommaireDebut; sommaireFin; contenuDebut; contenuFin]
dictThematique = {"Description du projet": [], 
                  "Description": [],
                  }

libTh1Som = '<a href="#ProjectDescription">Description du projet</a>'
libTh1ContDeb = '<h2 class="FONTSTYLE"><a id="ProjectDescription" name="#ProjectDescription">Description du projet</a></h2>'
idxTh1Som = contenuFichier[0].find(libTh1Som)
idxTh1ContDeb = contenuFichier[0].find(libTh1ContDeb)
idxTh1ContFin = contenuFichier[0][idxTh1ContDeb:].find('</table>') + idxTh1ContDeb + len('</table>')
#print('Sommaire : \n\n' + contenuFichier[0][idxTh1Som:idxTh1Som + len(libTh1Som)] + '\n\n')
#print('Contenu : \n\n' + contenuFichier[0][idxTh1ContDeb:idxTh1ContFin] + '\n\n')
#print(contenuContexte[0][:44].strip())
#print(contenuContexte[0][47:].strip())
#print(contenuContexte[1][:44].strip())
#print(contenuContexte[1][47:].strip())
#print(dicoContext)
#print(dicoContext.get('Description du projet'))
#print(dicoContext.get('Description'))
#l1 = ["azertyuiop", "123456789", "qsdfghjkl"]
#l2 = [[2, 6], [1, 3], [2, 5]]
#print(l1)
#print(l2)
#print(concatTextesSubNonVoulu(l1, l2))


        
