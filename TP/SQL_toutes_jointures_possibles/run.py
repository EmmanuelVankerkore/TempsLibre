

pathfile_in = 'C:\\Dev\\Comptage_Force_Filtre\\Data\\Input\\RequeteSQL_balises.sql'
pathfile_out = 'C:\\Dev\\Comptage_Force_Filtre\\Data\\Input\\RequeteSQL_balises.sql'
expression_prefixe = 'round( (count(1) - count(case when' 
expression_suffixe = 'then 0 end )) / count(1) * 100) as population_restante_filtre_'

def main() -> None:
    pass

if  __main__ == '__main__':
    main()