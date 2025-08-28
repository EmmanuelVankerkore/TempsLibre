import Utils.file as f
import Utils.texte as t
import Classe.Query as q
import Core.Graph_builder as g
import Core.Combinaison as c

pathfile_in = 'C:\\Dev\\TempsLibre\\TP\\SQL_toutes_jointures_possibles\\Data\\Input\\ODI_SQL_balises.sql'
pathfile_out = 'C:\\Dev\\TempsLibre\\TP\\SQL_toutes_jointures_possibles\\Data\\Input\\RequeteSQL_balises.sql'


def main() -> None:
    full_content = f.recupere_contenu_fichier_requete_sql(pathfile_in)
    from_part = t.get_from_part(full_content)
    where_part = t.get_where_part(full_content)
    sql_query = q.Query(from_part, where_part)
    dataset = sql_query.get_dataset_for_graph()
    graph = g.build_jointure_graph(dataset)
    combinations = c.generate_valid_combinations(dataset, graph) # Liste de str
    all_sub_querie = sql_query.get_all_sub_queries(combinations)
    #print(type(combinations[0]))

if  __name__ == '__main__':
    main()