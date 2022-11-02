package run;


import entities.DroiteAffine;
import entities.Point2D;
import entities.Segment;
import resultats.ListRecords;
import resultats.Record;


public class Run {
	
	static Point2D pPermanent = new Point2D("permanent", 1.0, 0.0);
	static Point2D pCentreCercle = new Point2D("Centre", 0.0, 0.0);
	
	public static void main(String[] args) {
		ListRecords liRe = new ListRecords();
		Point2D pHautSegment = new Point2D("t", 0.0, 1.0);
		liRe = getToutLesEnregistrements(liRe, pHautSegment, 2, 1, 12);
		liRe.afficher();
	}
	
	public static Point2D getNouveauPoint(Point2D pHautSegment) {
		Segment sInitiale = new Segment("SegmentTailleDejaConnue", pHautSegment, pPermanent);
		Point2D pmilieu = sInitiale.getPointDuMilieu();
		DroiteAffine dCentre = new DroiteAffine("droitePassantParCentre", pCentreCercle, pmilieu);
		return dCentre.getPointDuCercle();
	}
	
	public static Record getNouvelEnregistrement(Point2D pHautSegment, int coefMult) {
		Segment sFinal = new Segment("SegmentTailleInconnue", pHautSegment, pPermanent);
		Double valeurApproxPi = sFinal.getTaille();
		return new Record(valeurApproxPi, coefMult);
	}
	
	public static ListRecords getToutLesEnregistrements(ListRecords oldListeRec, 
														Point2D pDepart,
														int coefMultSegment,
														int Iteration, 
														int nbIterations) {
		if (Iteration <= nbIterations) {
			ListRecords newListeRec = oldListeRec;
			Point2D pNewDepart = getNouveauPoint(pDepart);
			newListeRec.ajouterRecord(getNouvelEnregistrement(pNewDepart, coefMultSegment));
			return getToutLesEnregistrements(newListeRec, pNewDepart, coefMultSegment*2, Iteration+1, nbIterations);
		} 
		else {
			return oldListeRec;
		}
	}
	
	
}
