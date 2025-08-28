import networkx as nx
from typing import Dict, Set

def build_jointure_graph(jointures: Dict[str, Set[str]]) -> nx.Graph:
    G = nx.Graph()
    for j1, tables1 in jointures.items(): #j1 la jointure et tables1 l'ensemble des tables
        G.add_node(j1) # Ajoute un noeud dans le graph
        for j2, tables2 in jointures.items():
            if j1 != j2 and tables1 & tables2: # Si les jointures sont différentes et qu'il existe au moins une table en commun entre les deux ensembles
                G.add_edge(j1, j2) # Ajoute un lien dans le graph
    return G
