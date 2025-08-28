from typing import Dict, List, Tuple, Set
import re

'select count(1)\n'
alias_regex = re.compile(r'\w{4,15}$')
alias_join_regex = re.compile(r'\w{4,15}\.')
owner_table_regex = re.compile(r'\w{4,15}\.\w{4,15}')

class Query:

    def __init__(self, from_part :str, join_part: str):
        self.dict_alias = self.set_dict_alias(from_part)
        self.conditions = self.set_conditions(join_part)

    def set_dict_alias(self, from_part: str) -> dict:
        dict_from = {}
        for e in from_part.split(','):
            alias = alias_regex.search(e).group(0)
            owner_table = owner_table_regex.search(e).group(0)
            dict_from[alias] = owner_table
        return dict_from

    def set_conditions(self, join_part: str) -> List[Tuple[str, Set[str], str]]:
        list_conditions = []
        for idx, e in enumerate(join_part.split('/* Jointure */')):
            tag_join = idx
            set_alias = set(alias[:-1] for alias in alias_join_regex.findall(e))
            expression = e
            list_conditions.append((tag_join, set_alias, expression))
        return list_conditions

    def __str__(self) -> str:
        return f"Query(dict_alias={self.dict_alias}, conditions={self.conditions})"

    def get_dataset_for_graph(self) -> Dict[str, Set[str]]:
        dict_from = {}
        for join in self.conditions:
            dict_from[join[0]] = join[1]
        return dict_from

    def get_specific_sub_query(self, list_idx_join: List[int]) -> str:
        aliases_in_joins = set()
        idx_display = "".join(idx for idx in list_idx_join)
        
        for idx in list(list_idx_join):
            if str(idx).isdigit():
                aliases_in_joins.update(self.conditions[int(idx)][1])
        join_part = '\t' + "\n\t".join(self.conditions[idx][2] for idx in list_idx_join) + ';'
        from_part = ",\n".join(f"\t{self.dict_alias[alias]} {alias}" for alias in self.dict_alias if alias in aliases_in_joins)
        return f"-- {idx_display}\n\nselect count(1)\nfrom\n{from_part}\nwhere\n{join_part}\n\n"

    def get_all_sub_queries(self, listes: List) -> str:
        all_sub_queries = "".join(self.get_specific_sub_query(list_idx_join) for list_idx_join in listes)
        return all_sub_queries