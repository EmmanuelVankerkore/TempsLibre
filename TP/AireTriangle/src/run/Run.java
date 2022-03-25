package run;

import entities.DroiteAffine;
import entities.Point2D;
import entities.Segment;
import entities.Triangle;

public class Run {
	
	public static void main(String[] args) {
		Point2D pointA = new Point2D("A", 0.0, 4.0);
		Point2D pointB = new Point2D("B", 3.0, 0.0);
		Point2D pointC = new Point2D("C", 0.0, 0.0);
		
		// Définition du triangle
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		
		// Initialisation de la liste des segments éligibles au calcul
		t1.setListeSegmentEligible();
		
		// Définition du segment eligible
		Segment segElig =  t1.getListeSegmentEligible().get(0);
		
		// Définition de la droite affine à partir du segment eligible
		DroiteAffine dFromSegElig = new DroiteAffine("dse", segElig.getPoint1(), segElig.getPoint2());
		
		// Définition du point qui n'appartient pas au segment éligible
		Point2D pointD = t1.getPointNonAppartenantSegment(segElig);
		
		// Définition de la droite affine correspondant à la perpendiculaire du segment éligible
		DroiteAffine dFromSegEligPerp = dFromSegElig.getDroiteAffinePerpendiculaireFromPoint(pointD);
	}

}
