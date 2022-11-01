package run;

import calcul.Calcul;
import entities.DroiteAffine;
import entities.Point2D;
import entities.Segment;
import resultats.ListRecords;
import resultats.Record;


public class Run {
	public static void main(String[] args) {
		//System.out.println("Bonjour");
		ListRecords liRe = new ListRecords();
		
		Point2D centreCercle = new Point2D("Centre", 0.0, 0.0);
		Point2D pointTemp = new Point2D("t", 0.0, 1.0);
		Point2D pointPerm = new Point2D("permanent", 1.0, 0.0);
		
		// 4. Définir Segment co tangeant au cercle
		
		Segment segmentInitiale = new Segment("calcules moi", pointTemp, pointPerm);
		
		// 5. Calculer la taille
		
		Double valeurApproxPi = segmentInitiale.getTaille();
		//System.out.println(valeurApproxPi);
		//affichage.Affichage.afficherValeurFourchette(valeurApproxPi, 7);
		//System.out.println(Calcul.arrondirAuInf(valeurApproxPi, 7));
		//System.out.println(Calcul.arrondirAuSup(valeurApproxPi, 7));
		
		// 6. Créer la séquence
		
		Record r = new Record(valeurApproxPi, 2);
		
		// 7. Stocket la séquence avec les autre
		
		liRe.ajouterRecord(r);
		liRe.afficher();
		
		// 1. Trouver le point du centre du segment
		
		Point2D milieu = segmentInitiale.getPointDuMilieu();
		//milieu.afficher();
		
		// 2. Définir la droite affine perpendiculare
		
		DroiteAffine dCentre = new DroiteAffine("droitePassantParCentre", centreCercle, milieu);
		//dCentre.afficher();
		
		// 3. Définir les points ( approx ) communs entre la la droite et le cercle
		
		pointTemp = dCentre.getPointDuCercle();
		//System.out.println(pointTemp.estQuasiSurCercle());
		//System.out.println(milieu.estQuasiSurCercle());
	}
	
	
	
	
}
