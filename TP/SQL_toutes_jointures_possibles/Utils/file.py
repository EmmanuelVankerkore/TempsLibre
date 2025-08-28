from pathlib import Path

def recupere_contenu_fichier_requete_sql(pathfile_SQL : str) -> str:
    with open(pathfile_SQL, 'r') as file:
        return file.read().replace('\n', '')

def ecrire_fichier(chemin_absolu: str, contenu: str) -> None:
    fichier = Path(chemin_absolu)
    fichier.parent.mkdir(parents=True, exist_ok=True)
    with fichier.open(mode="w", encoding="utf-8") as f:
        f.write(contenu)