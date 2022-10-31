# -*- coding: utf-8 -*-
"""
Created on Wed Jul 27 18:43:52 2022

@author: Surichat
"""

from tkinter import Tk
from tkinter import Label
from tkinter import Frame
from tkinter import Button
from tkinter import Entry
from tkinter import Checkbutton
from tkinter import Listbox
from tkinter import Scrollbar

# Création d'une fenêtre
window = Tk()

# Création d'un cadre
    # Définir une bordure d'une épaisseur de 1
cadre = Frame(window, bg="#17a36b", bd=1, relief="sunken")

# Donner un titre à sa fenêtre
window.title("Le nom de mon application")

# Définir la dimension de ma fenêtre
window.geometry("1080x720")

# Définir la taille minimale de la fenêtre
window.minsize(480, 360)

# Définir l'icône de notre fenêtre
window.iconbitmap("./Ressources/Cavalier.ico")

# Définir la couleur d'arrière plan de la fenêtre
window.config(background="#17a36b")

# Définir une étiquette
     # La valeur
     # La police
     # La taille de la police
     # La couleur d'arrière plan
     # La couleur de la police
texte = Label(cadre, text="Une étiquette", font=("Courrier", 40), bg="#17a36b", fg="white")

# Empaqueter un composant dans une fenêtre
    # Définir le positionnement par rapport au père
        #texte.pack(side="left")
texte.pack()

texte2 = Label(cadre, text="Une plus petite étiquette", font=("Courrier", 25), bg="#17a36b", fg="white")
texte2.pack()

# Empaqueter un composant dans une fenêtre
    # Occuper au maximum l'espace disponible dans la fenêtre père
cadre.pack(expand="yes")

# bouton de sortie
bouton = Button(cadre, text="Quitter l'application", command=window.destroy)
bouton.pack()

# Zone de saisi
entree = Entry(cadre, width=30)
entree.pack()

# Cases à cocher
cb1 = Checkbutton(cadre, text="Youtube", bg="#17a36b").pack(side="left")
cb2 = Checkbutton(cadre, text="Tweeter", bg="#17a36b").pack(side="left")
cb3 = Checkbutton(cadre, text="Facebook", bg="#17a36b").pack(side="left")

# Liste d'éléments
    # Définir le nombre d'éléments affichage sans scroll
    # Préciser la possibilité de sélectionner plusieurs éléments (avec la touche Ctrl)
liste = Listbox(cadre, height=2, selectmode="extended")
liste.insert(1, "Stambia")
liste.insert(2, "Talend")
liste.insert(3, "ODI")
liste.insert(4, "Kestra")
liste.pack()

# Barre de scrolling
scrollbar = Scrollbar(cadre, orient='vertical', command=liste.yview).pack()


window.mainloop() 