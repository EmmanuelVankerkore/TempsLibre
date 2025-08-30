import itertools
import networkx as nx
from typing import List, Dict, Set

def generate_valid_combinations(jointures: Dict[str, Set[str]], graph: nx.Graph) -> List[str]:
    valid_combinations = []
    all_jointures = list(jointures.keys())

    for r in range(1, len(all_jointures) + 1): # Parcours d'un boucle de 1 au nomnbre de noeuds dans un graph
        for subset in itertools.combinations(all_jointures, r): # Pour chaque combinaison de l'ensemble des combinaisons possible sans répétition
            subgraph = graph.subgraph(subset) # Création d'un sous graph en prenant un ensemble de jointure
            if nx.is_connected(subgraph): # Si tous les noeuds du sous graph sont reliés alors la condition est validé, on dit que le graph est connexe
                valid_combinations.append("".join(str(subset)))
    return valid_combinations

def get_list_of_int_from_combinations(combinations: List[str]) -> List[List[int]]:
    list_of_list_int = []
    for comb in combinations:
        list_of_list_int.append([int(idx) for idx in comb if str(idx).isdigit()])
    return list_of_list_int

