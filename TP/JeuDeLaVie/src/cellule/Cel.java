package cellule;

public class Cel {
	
	public static int nombreCelluleVivantesAutour(int[][] tab, int x, int y) {
		int compteur = 0;
		for (int i = -1; i < 2; i++) {
			for (int j = -1; j < 2; j++) {
				if ((x+i)>=0 && (x+i)<=tab.length-1 && (y+j)>=0 && (y+j)<=tab[0].length-1) {
					if (!(i == 0 && j== 0)) {
						if (tab[x+i][y+j]==1) {
							compteur += 1;
						}
					}
				}
			}
		}
		return compteur;
	}
	
	public static int nombreTotalCellulesVivantes(int[][] tab) {
		int resultat = 0;
		for (int i = 0; i < tab.length; i++) {
			for (int j = 0; j < tab[0].length; j++) {
				if (tab[i][j] == 1) {
					resultat +=1;
				}
			}
		}
		return resultat;
	}
}
