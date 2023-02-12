# -*- coding: utf-8 -*-
"""
Created on Tue Nov 15 18:47:16 2022

@author: Surichat
"""

def definitionNomJoueur(id):
    return input('Joueur n° ' + id + ' : ')

def reponseValidationNomJoueur(id, nomJoueur):
    return input('Joueur n° ' + id + ' : vous êtes ' + nomJoueur  + ' ? (y/n) ')

def afficherValidationNomJoueur(nomJoueur):
    print('Parfait ' + nomJoueur + ' !')

def rechercherNomJoueur(id):
    reponseJoueur = 'n'
    while reponseJoueur == 'n':
        nomJoueur = definitionNomJoueur(id)
        reponseJoueur = reponseValidationNomJoueur(id, nomJoueur)
    afficherValidationNomJoueur(nomJoueur)
    return nomJoueur
    
def definirRole(j1, j2):
    j1Role = input('Quel rôle tient ' + j1 + ' ? \n 1. il/elle devine le mot \n 2. il/elle donne le mot à deviner \n (1/2) ')
    if (j1Role in ("1", "2")):
        if j1Role == "1":
            print(j1 + ' est celui/celle qui devine le mot')
            print(j2 + ' est celui/celle qui donne le mot à deviner')
            return {j1 : "1" , j2 : "2"}
        else:
            print(j1 + ' est celui/celle qui donne le mot à deviner')
            print(j2 + ' est celui/celle qui devine le mot')
            return {j1 : "2" , j2 : "1"}
    else:
        definirRole(j1, j2)
        
def TrouverNomJoueurQuiDevine(dicorole):
    for cle, valeur in dicorole.items():
        if valeur == "1":
            return cle

def TrouverNomJoueurQuiDonne(dicorole):
    for cle, valeur in dicorole.items():
        if valeur == "2":
            return cle
        
def recupererMotADeviner(dicorole):
    return input(TrouverNomJoueurQuiDonne(dicorole) + ' entre le mot que tu souhaites faire deviner : ')

def simulerClearConsole():
    for i in range(40): print('\n')
    
def inviterJoueurADeviner(j):
    print(j + ', c est à toi :')
    print('\n')

def initialiserMotMystere(mot):
    motMystere = ''
    for i in range(len(mot)): 
        motMystere = motMystere + '*'
    return motMystere

def afficherMotPartiel(MotPartiel):
    return


j1 = rechercherNomJoueur("1")
j2 = rechercherNomJoueur("2")
dicoRoles = definirRole(j1, j2)
mot = recupererMotADeviner(dicoRoles)
simulerClearConsole()
inviterJoueurADeviner(TrouverNomJoueurQuiDevine(dicoRoles))
print(initialiserMotMystere(mot))
    
    
# nomJoueur2 = definitionNomJoueur2()
# reponseJoueur2 = 'n'