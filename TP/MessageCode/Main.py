# -*- coding: utf-8 -*-
"""
Created on Mon Feb 13 13:51:38 2023

@author: Surichat
"""

import random
import math

chaine_alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
dico_message_code = {}
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

dictionnaire_sequence = {}
dictionnaire_sequence[1] = liste_01
dictionnaire_sequence[2] = liste_02
dictionnaire_sequence[3] = liste_03
dictionnaire_sequence[4] = liste_04
dictionnaire_sequence[5] = liste_05
dictionnaire_sequence[6] = liste_06
dictionnaire_sequence[7] = liste_07
dictionnaire_sequence[8] = liste_08
dictionnaire_sequence[9] = liste_09
dictionnaire_sequence[10] = liste_10

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
        return resultat
    else:
        car2 = math.floor((valeur_num) / base)
        car3 = (valeur_num) - ((base) * car2)
        resultat = TrouverCle(dictionnaire, 0) + str(TrouverCle(dictionnaire, car2)) + str(TrouverCle(dictionnaire, car3))
        return resultat

def dechiffre(dictionnaire, valeur_chiffree):
    base = len(dictionnaire)
    return dictionnaire[str(valeur_chiffree)[0]]*base*base + dictionnaire[str(valeur_chiffree)[1]]*base + dictionnaire[str(valeur_chiffree)[2]]

def dispose_aleatoirement(dictionnaire):
    nouveau_dictionnaire = {}
    liste_cle_aleatoire = random.sample(list(dictionnaire.keys()), len(list(dictionnaire.keys())))
    for cle_alea in liste_cle_aleatoire:
        nouveau_dictionnaire[cle_alea] = dictionnaire[cle_alea]
        del dictionnaire[cle_alea]
    return nouveau_dictionnaire

def concatener_valeurs(dictionnaire):
    resultat = ''
    for value in list(dictionnaire.values()):
        resultat = resultat + value
    return resultat

def renvoyer_sur_2_caracteres(nombre):
    if nombre < 10:
        return '0' + str(nombre)
    else:
        return str(nombre)
    
def renvoyer_code_partie3(lettre, num_sequence):
    num_sequence_iteration = 100 - (dictionnaire_sequence[num_sequence].index(lettre, 0, len(dictionnaire_sequence[num_sequence]))) * 3
    return chiffre(dico_indice_sequence, num_sequence_iteration)

def renvoyer_code_partie2(num_sequence):
    return renvoyer_sur_2_caracteres(num_sequence)

def renvoyer_code_partie1(iteration):
    return chiffre(dico_emplacement_message, iteration)

def renvoyer_code(lettre, num_sequence, iteration):
    return renvoyer_code_partie1(iteration) + renvoyer_code_partie2(num_sequence) + renvoyer_code_partie3(lettre, num_sequence)
    
def renvoyer_message_code(message):
    iteration_message_code = 0
    for caractere in list(message):
        if caractere in chaine_alphabet:
            num_sequence = random.randint(1,10)
            dico_message_code[iteration_message_code] = renvoyer_code(caractere, num_sequence, iteration_message_code)
        iteration_message_code = iteration_message_code + 1
    return concatener_valeurs(dispose_aleatoirement(dico_message_code))
    
def afficher_message_code(message):
    print(renvoyer_message_code(message))

def decompose_message_en_batch(message):
    liste_batch = []
    while len(message) != 0 :
        message_batch = message[0:8]
        liste_batch.append(message_batch)
        message = message[8:]
    return liste_batch

def constituer_message_explose(message):
    dico_message_dechiffre = {}
    liste_lettre_codee = decompose_message_en_batch(message)
    for code in liste_lettre_codee:
        dico_message_dechiffre[dechiffre(dico_emplacement_message,code[0:3])] = dictionnaire_sequence[int(code[3:5])][math.floor(int(100 - dechiffre(dico_indice_sequence, code[5:8]))/3)]
    return dico_message_dechiffre 

def trouver_valeur_cle_maximal(dictionnaire):
    valeur_max = 0
    for cle in list(dictionnaire.keys()):
        if cle > valeur_max:
            valeur_max = cle
    return valeur_max

def reconstituer_message(dictionnaire_message_explose):
    message = ''
    liste_keys = list(dictionnaire_message_explose.keys())
    for i in range(0, trouver_valeur_cle_maximal(dictionnaire_message_explose)+1):
        if i in liste_keys:
            message = message + dictionnaire_message_explose[i]
        else:
            message = message + ' '
    return message

def dechiffrer_message_decode(message_code):
    return reconstituer_message(constituer_message_explose(message_code))

def afficher_message_decode(message_code):
    print(dechiffrer_message_decode(message_code))
    
#afficher_message_code('LE LION EST MORT CE SOIR')
afficher_message_decode('**,05KXB*:$02KBB*:!06KFF**$05KAL**:06KLA***10XFK*::07KXF*+%01XLB*:*03KVK*+.01KFX*++04XLB*+!05XLB*+$01XLF*:%01KFB*+:03KXF**.01KAK**!05XLB*:.05XLF*:+09XBL')