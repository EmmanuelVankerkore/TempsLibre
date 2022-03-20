package run;

import entities.DroiteAffine;
import entities.Point2D;

public class Run {
	
	public static void main(String[] args) {
		System.out.println("Bonjour");
		Point2D pointA = new Point2D("A", 0.5, 2.0);
		Point2D pointB = new Point2D("B", -0.5, 1.0);
		DroiteAffine da1 = new DroiteAffine("D1", pointA, pointB);
		DroiteAffine da2 = new DroiteAffine("D2", 3.25, -4.201);
		da1.afficher();
		da2.afficher();
	}

}
