package run;

import entities.DroiteAffine;
import entities.Point2D;
import entities.Segment;
import entities.Triangle;

public class Run {
	
	public static void main(String[] args) {
		
		Point2D pointA = new Point2D("A", 10.0, -3.0);
		Point2D pointB = new Point2D("B", 30.0, 4.0);
		Point2D pointC = new Point2D("C", 0.0, -3.0);
		
		// D�finition du triangle
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		
		// Initialisation de la liste des segments �ligibles au calcul
		t1.setListeSegmentEligible();
		
		// D�finition du segment eligible
		Segment segElig =  t1.getListeSegmentEligible().get(0);
		
		// D�finition de la droite affine � partir du segment eligible
		DroiteAffine dFromSegElig = new DroiteAffine("dse", segElig.getPoint1(), segElig.getPoint2());
		
		// D�finition du point qui n'appartient pas au segment �ligible
		Point2D pointD = t1.getPointNonAppartenantSegment(segElig);
		
		// D�finition de la droite affine correspondant � la perpendiculaire du segment �ligible
		DroiteAffine dFromSegEligPerp = dFromSegElig.getDroiteAffinePerpendiculaireFromPoint(pointD);
		
		// D�finition du point correspondant � l'intersection d'une droite affine et de sa parall�le
		Point2D pointI = dFromSegElig.getPointIntersection(dFromSegEligPerp);
		
		// Affichage de la taille du triangle
		System.out.println("L'aire du triangle est de : " + t1.getAire(segElig, pointI));
	}
}
