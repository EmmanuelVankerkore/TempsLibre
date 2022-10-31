# -*- coding: utf-8 -*-
"""
Created on Sun Oct 16 16:39:04 2022

@author: Surichat
"""

from os import listdir
import shutil

# Folders

path_folder_input = "C:\\Dev\\GitHub\\Repository\\TP\\RangementFichiers\\DossierSAS"
path_folder_output = "C:\\Dev\\GitHub\\Repository\\TP\\RangementFichiers\\DossierFinal"

# Liste des pays

dict_pays = {"ES": "Espagne", 
             "FR": "France",
             "PT": "Portugal"}

# Liste des fichiers dont l'extension correspond au CSV

liste_file_input = [f for f in listdir(path_folder_input) if (f[-4:] == ".csv")]

# Traitement des fichiers 

for f in liste_file_input:
    if f[12:14] in dict_pays: 
        shutil.move(path_folder_input + "\\" + f,
                    path_folder_output + "\\" + dict_pays[f[12:14]])
    else:
        shutil.move(path_folder_input + "\\" + f,
                    path_folder_output + "\\__NonReference__")