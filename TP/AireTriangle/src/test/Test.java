package test;

import entities.DroiteAffine;
import entities.Point2D;
import entities.Segment;
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
	
	public void afficherSegmentetTaille() {
		Point2D pointA = new Point2D("A", 0.0, 0.0);
		Point2D pointB = new Point2D("B", 4.0, 3.0);
		Segment s1 = new Segment("s1", pointA, pointB);
		s1.afficher();
		System.out.println("La taille du segment " + s1.getName() + " est de " + s1.getTaille());
	}
	
	public void CreationDroitePerpendiculaire() {
		Point2D pointB = new Point2D("B", 4.0, 3.0);
		DroiteAffine da = new DroiteAffine("d1", 2.0, 3.0);
		DroiteAffine da2 = da.getDroiteAffinePerpendiculaireFromPoint(pointB);
		da.afficher();
		da2.afficher();
	}
	
	public void afficherLeNomIntersectionDe2DroitesAffines() {
		Point2D pointB = new Point2D("B", 4.0, 3.0);
		DroiteAffine da = new DroiteAffine("d1", 2.0, 3.0);
		DroiteAffine da2 = da.getDroiteAffinePerpendiculaireFromPoint(pointB);
		System.out.println("Le nom de l'intersection est  : " + da.getNameIntersection(da2)); 
	}
	
	public void afficherCoordonneeIssuIntersectionDeDeuxDroitesAffines() {
		Point2D pointB = new Point2D("B", 4.0, 3.0);
		DroiteAffine da = new DroiteAffine("d1", 2.0, 3.0);
		DroiteAffine da2 = da.getDroiteAffinePerpendiculaireFromPoint(pointB);
		Point2D intersection = da.getPointIntersection(da2);
		intersection.afficher();
	}
}
