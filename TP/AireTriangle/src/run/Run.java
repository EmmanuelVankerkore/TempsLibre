package run;

import java.util.List;

import entities.DroiteAffine;
import entities.Point2D;
import entities.Segment;
import entities.Triangle;

public class Run {
	
	public static void main(String[] args) {
		System.out.println("Bonjour");
		Point2D pointA = new Point2D("A", 4.0, 4.0);
		Point2D pointB = new Point2D("B", 2.0, 12.0);
		Segment s = new Segment("s1", pointA, pointB);
		System.out.print("Point gauche : ");
		s.getPointGauche().afficher();
		System.out.print("Point droit : ");
		s.getPointDroit().afficher();
	}
}
