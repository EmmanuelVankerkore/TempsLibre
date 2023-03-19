# -*- coding: utf-8 -*-
"""
Created on Sun Mar 19 00:37:49 2023

@author: Surichat
"""

import re

folder_in = 'C:/Dev/GitHub/Repository/TP/GoogleSalon_ListeEmails/Input'
folder_out = 'C:/Dev/GitHub/Repository/TP/GoogleSalon_ListeEmails/Output'

file_in = 'GoogleSalon.html'
file_out = 'ListeEmails.txt'

separateur = ' ; '
regex = '(\w|[-.]){1,30}@(\w|[-.]){1,20}'
resultat = ''

# Ouverture des fichiers
fichier_data = open(folder_in + '/' + file_in ,'r')
fichier = open(folder_out + '/' + file_out ,'w')

# Récupération du contenu du fichier d'entré
data = fichier_data.readlines()[0]

# Récupération des objects pour lesquels on a une correspondance avec une adresse email
indices_object = re.finditer(pattern=regex, string=data)

# Récupération des index pour lesquels on a une correspondance avec une adresse email
list_index_attribut = [index.start() for index in indices_object]

# Récupération des adresses emails
liste_emails = {re.search(regex, data[i:i+50]).group(0) for i in list_index_attribut}

# Mise en forme de la liste
for email in liste_emails:
    resultat = resultat + email + separateur
    
# Ecriture dans le fichier
fichier.write(resultat[0:len(resultat)-3])

# Fermeture des fichiers
fichier_data.close()
fichier.close()