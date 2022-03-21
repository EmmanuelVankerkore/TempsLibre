package run;

import entities.DroiteAffine;
import entities.Point2D;

public class Run {
	
	public static void main(String[] args) {
		System.out.println("Bonjour");
		Point2D pointB = new Point2D("B", 4.0, 3.0);
		DroiteAffine da = new DroiteAffine("d1", 2.0, 3.0);
		DroiteAffine da2 = da.getDroiteAffinePerpendiculaireFromPoint(pointB);
		Point2D intersection = da.getPointIntersection(da2);
		intersection.afficher();
	}

}
