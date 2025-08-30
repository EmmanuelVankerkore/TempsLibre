def get_index_from(requete: str) -> int:
    return requete.index('from')

def get_index_where(requete: str) -> int:
    return requete.index('where')

def get_index_balise_first(requete: str) -> int:
    return requete.index('/**/')

def get_index_balise_second(requete: str) -> int:
    return requete.index('/**/', get_index_balise_first(requete)+1)

def get_from_part(requete: str) -> str:
    index_from = get_index_from(requete)
    index_where = get_index_where(requete)
    return requete[index_from+4:index_where].replace('\t', ' ')

def get_where_part(requete: str) -> str:
    index_join_start = get_index_balise_first(requete)
    index_join_end = get_index_balise_second(requete)
    return requete[index_join_start+4:index_join_end]

def replace_str_by_int_from_list(liste: list[int]) -> str:
    return "".join(chr(65 + idx) for idx in liste) 