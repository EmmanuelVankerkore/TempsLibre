# -*- coding: utf-8 -*-
"""
Created on Mon Feb 13 13:51:38 2023

@author: Surichat
"""

import random
import math

x = 10 # Nombre de séquences

# Fonction qui affiche 10 façon de randomisé les lettres de l'alphabet
def afficher_X_sequences_alphabet_randomise():
    for i in range(x):
            
        chaine_alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
        liste_alphabet =  list(chaine_alphabet.strip())
        liste_alphabet_new = []
    
        while len(liste_alphabet) != 0:
            
            indice_alea = random.randint(0,len(liste_alphabet)-1)
            liste_alphabet_new.append(liste_alphabet[indice_alea])
            del liste_alphabet[indice_alea]
    
        print(liste_alphabet_new)

# afficher_X_sequences_alphabet_randomise()

liste_01 = ['U', 'L', 'T', 'I', 'Z', 'N', 'Y', 'J', 'B', 'F', 'O', 'A', 'K', 'W', 'M', 'G', 'Q', 'E', 'D', 'X', 'P', 'C', 'S', 'R', 'V', 'H']
liste_02 = ['C', 'N', 'L', 'E', 'J', 'A', 'P', 'S', 'D', 'M', 'O', 'H', 'R', 'F', 'V', 'K', 'U', 'Q', 'Y', 'G', 'I', 'X', 'Z', 'B', 'W', 'T']
liste_03 = ['N', 'Z', 'P', 'W', 'X', 'O', 'K', 'Y', 'T', 'M', 'L', 'G', 'E', 'F', 'D', 'C', 'A', 'R', 'B', 'I', 'U', 'V', 'S', 'J', 'H', 'Q']
liste_04 = ['Z', 'P', 'T', 'D', 'R', 'S', 'X', 'Q', 'G', 'K', 'Y', 'I', 'C', 'V', 'B', 'U', 'A', 'M', 'W', 'J', 'L', 'N', 'H', 'E', 'O', 'F']
liste_05 = ['P', 'Z', 'J', 'F', 'I', 'S', 'V', 'H', 'T', 'C', 'X', 'M', 'U', 'A', 'Y', 'D', 'L', 'E', 'G', 'B', 'W', 'N', 'R', 'O', 'K', 'Q']
liste_06 = ['L', 'O', 'N', 'S', 'V', 'K', 'E', 'B', 'Y', 'U', 'I', 'Q', 'H', 'R', 'A', 'Z', 'W', 'X', 'D', 'M', 'F', 'T', 'J', 'C', 'G', 'P']
liste_07 = ['E', 'H', 'V', 'M', 'O', 'Z', 'I', 'P', 'Y', 'Q', 'G', 'T', 'W', 'B', 'R', 'S', 'J', 'C', 'X', 'U', 'A', 'L', 'F', 'D', 'N', 'K']
liste_08 = ['W', 'C', 'Y', 'K', 'F', 'B', 'H', 'G', 'S', 'V', 'P', 'E', 'J', 'D', 'T', 'M', 'X', 'L', 'Z', 'Q', 'O', 'I', 'N', 'A', 'R', 'U']
liste_09 = ['Z', 'Q', 'O', 'J', 'P', 'R', 'N', 'L', 'D', 'I', 'B', 'F', 'Y', 'M', 'C', 'K', 'S', 'A', 'W', 'G', 'V', 'X', 'E', 'H', 'U', 'T']
liste_10 = ['J', 'C', 'F', 'X', 'Q', 'W', 'R', 'V', 'O', 'B', 'H', 'T', 'A', 'I', 'S', 'N', 'K', 'D', 'U', 'L', 'E', 'G', 'Y', 'P', 'M', 'Z']

# Vérifier la présence d'un élément dans une liste
print('u' in liste_01)
print('U' in liste_01)

# Identifier l'index d'un élément dans une liste
print(liste_02.index('U', 0, len(liste_02)))
print(liste_02[liste_02.index('U', 0, len(liste_02))])

# Sortir un chiffre compris entre 10 000 et 99 999
print(random.randint(10000,99999))

dico_emplacement_message = {'*' : 0,
                            ':' : 1, 
                            '+' : 2, 
                            ',' : 3, 
                            '$' : 4, 
                            '!' : 5, 
                            '.' : 6, 
                            '%' : 7}
dico_indice_sequence = {'X' : 0, 
                        'K' : 1, 
                        'V' : 2, 
                        'B' : 3, 
                        'L' : 4, 
                        'A' : 5, 
                        'F' : 6}

def TrouverCle(dictionnaire, valeur):
    for key, value in dictionnaire.items():
        if dictionnaire[key] == valeur:
            return key

def chiffre(dictionnaire, valeur_num):
    base = len(dictionnaire)
    if valeur_num >= base*base:
        car1 = math.floor(valeur_num / (base*base))
        car2 = math.floor((valeur_num - base*base * car1 ) / base) 
        car3 = valeur_num - (car1 * base * base) - (car2 * base)
        resultat = str(TrouverCle(dictionnaire, car1)) + str(TrouverCle(dictionnaire, car2)) + str(TrouverCle(dictionnaire, car3))
        #print(str(valeur_num) + ' : ' + resultat + ' --> ' + str(car1) + ' * ' + str(base*base) + ' + ' + str(car2) + ' * ' + str(base) + ' + ' + str(car3))
    else:
        car2 = math.floor((valeur_num) / base)
        car3 = (valeur_num) - ((base) * car2)
        resultat = TrouverCle(dictionnaire, 0) + str(TrouverCle(dictionnaire, car2)) + str(TrouverCle(dictionnaire, car3))
        #(str(valeur_num) + ' : ' + resultat + ' --> ' + str(car2) + ' * ' + str(base) + ' + ' + str(car3))
    return resultat

for i in range(30, 90):
    #chiffre(dico_emplacement_message, i)
    chiffre(dico_indice_sequence, i)
    