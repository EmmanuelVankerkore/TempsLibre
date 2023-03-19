# -*- coding: utf-8 -*-
"""
Created on Sat Mar 18 13:22:39 2023

@author: Surichat
"""

folder_in = 'C:/Dev/GitHub/Repository/TP/CreateTable_ListeChamps/Input'
folder_out = 'C:/Dev/GitHub/Repository/TP/CreateTable_ListeChamps/Output'

file_in = 'create_table.SQL'
file_out = 'ListeVariables__enligne.txt'
file_out2 = 'ListeVariables__enligneSimpleCote.txt'

separateur = ','
encadrement = '\''

resultat = ''
resultat2 = ''

# Ouverture des fichiers
fichier_data = open(folder_in + '/' + file_in ,'r')
fichier = open(folder_out + '/' + file_out ,'w')
fichier2 = open(folder_out + '/' + file_out2 ,'w')

# Récupération du contenu du fichier d'entré
data = fichier_data.readlines()

# Traitement
for ligne in data:
    if ligne.split(' ')[0].strip().upper() != 'CREATE' and ligne.split(' ')[0].strip().upper() != 'PRIMARY' :
        resultat = resultat + ligne.split(' ')[0].strip() + separateur
        resultat2 = resultat2 + encadrement + ligne.split(' ')[0].strip() + encadrement + separateur

# Ecriture dans les fichiers
fichier.write(resultat[0:len(resultat)-1])
fichier2.write(resultat2[0:len(resultat2)-1])

# Fermeture des fichiers
fichier_data.close()
fichier.close()
fichier2.close()