package test;

import entities.DroiteAffine;
import entities.Point2D;
import entities.Triangle;

public class Test {

	public void afficherPoint2D() {
		Point2D pointA = new Point2D("A", 0.1278, 1.6497);
		pointA.afficher();
	}
	
	public void afficherTriangleQuelconque() {
		Point2D pointA = new Point2D("A", 0.1278, 1.6497);
		Point2D pointB = new Point2D("B", 5.201, -4.05279);
		Point2D pointC = new Point2D("C", -2.475, 10.4136);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		t1.afficher();
	}
	
	public void afficher2DroitesAffines() {
		Point2D pointA = new Point2D("A", 0.5, 2.0);
		Point2D pointB = new Point2D("B", -0.5, 1.0);
		DroiteAffine da1 = new DroiteAffine("D1", pointA, pointB);
		DroiteAffine da2 = new DroiteAffine("D2", 3.25, -4.201);
		da1.afficher();
		da2.afficher();
	}
}
