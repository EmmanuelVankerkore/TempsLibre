# -*- coding: utf-8 -*-
"""

Created on Sun Nov  6 14:39:55 2022
@Objectif : transformer le nom des noeud de dynamique de statique, il faut passer de < lasagnes : {} > à < recette : "lasagnes" >
@author: Surichat

"""

import json

contenuFile = {
    "recettes": {
        "Lasagnes" : {
            "ingredients" : ["Tomate", "Hachi de boeuf", "Bechamelle"],
            "CuissonFour" : {
                "temps" : 20,
                "unitéTemps" : "minute",
                "puissance" :  750,
                "unitéPuissance" : "Watt"
            },
            "NombreDePersonnes" : 6,
            "TypePlat" : "plat de résistance"
        },
        "pot-au-feu" : {
            "ingredients": ["pommes de terre", "poireaux", "navets", "carotte", "choux"],
            "CuissonVapeur" : {
                "temps" : 2,
                "unitéTemps" : "heure",
                "puissance" : "feu doux"
            },
            "NombreDePersonnes" : 6,
            "TypePlat" : "plat de résistance"
        },
        "Tiramisu":{
            "ingredient": ["Mascarpone", "Café", "Créme", "Biscuit"],
            "CuissonFour" : {
                "temps" : 10,
                "unitéTemps" : "minute",
                "puissance" :  600,
                "unitéPuissance" : "Watt"
            },
            "NombreDePersonnes" : 2,
            "TypePlat" : "déssert"
        }
    }
}

#tmp = json.dumps(contenuFile, indent=4)
tmp = json.dumps(contenuFile, indent=4)
#print(type(tmp))
for item in contenuFile.get('recettes'):
    print(item)
    
print(contenuFile)