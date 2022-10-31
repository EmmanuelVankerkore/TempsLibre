# -*- coding: utf-8 -*-
"""
Created on Mon Oct 17 19:46:42 2022

@author: Surichat
"""
from math import ceil

# Folders

path_file_input = "C:\\Dev\\GitHub\\Repository\\TP\\FichierCSVExplose\\data\\Input\\Dataframe.csv"
path_folder_output = "C:\\Dev\\GitHub\\Repository\\TP\\FichierCSVExplose\\data\\Output"

# Nombre de lignes par fichier

NbLignes = 10

# Stocker dans une liste toutes les lignes du fichier

Inputfile = open(path_file_input, 'r')
contenu_du_fichier = Inputfile.readlines()
Inputfile.close()

# On crée un nouveau fichier qui contiendront tout au plus 10 lignes

j = 0
for i in range(ceil(len(contenu_du_fichier)/NbLignes)): # i : boucle sur le nombre de fichier à produire
    if ((j+NbLignes) <= (len(contenu_du_fichier)-1)):
        OutputFile = open(path_folder_output + "\\Dataframe_seq_" + str(i+1) + ".txt", "a")
        OutputFile.write("".join(contenu_du_fichier[j:j+NbLignes]))
        OutputFile.close()
        j=j+NbLignes
    else:
        OutputFile = open(path_folder_output + "\\Dataframe_seq_" + str(i+1) + ".txt", "a")
        OutputFile.write("".join(contenu_du_fichier[j:]))
        OutputFile.close()
