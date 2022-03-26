package test;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

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
	
	public void afficherListeSegmentsIssusDuTriangle() {
		Point2D pointA = new Point2D("A", 0.1278, 1.6497);
		Point2D pointB = new Point2D("B", 5.201, -4.05279);
		Point2D pointC = new Point2D("C", -2.475, 10.4136);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		List<Segment> ls = t1.getTousLesSegments();
		System.out.println("Liste des segments issus du triangle");
		for (Segment segment : ls) {
			segment.afficher();
		}
	}
	
	public void verifierSiUnSegmentEstEligibleAuCalculDeSaPerpendiculaire() {
		Point2D pointA = new Point2D("A", 0.0, 5.0);
		Point2D pointB = new Point2D("B", 2.0, 0.0);
		Segment s1 = new Segment("s1", pointA, pointB);
		System.out.print("Le triangle s1 est éligible ? --> ");
		System.out.println(Triangle.estSegmentEligible(s1));
	}
	
	public void recupererListeDesSegmentsEligiblesAuCalculDeDroiteAffine() {
		Point2D pointA = new Point2D("A", 0.0, 4.0);
		Point2D pointB = new Point2D("B", 3.0, 0.0);
		Point2D pointC = new Point2D("C", 0.0, 0.0);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		List<Segment> ls = t1.getTousLesSegments();
		System.out.println("Ci-dessous la liste des segments eligibles:");
		List<Segment> ls2 = Triangle.getListeSegmentsEligibles(ls);
		for (Segment segment : ls2) {
			segment.afficher();
		}
	}
	
	public void initialisationDeLaListeDesSegmentsEligibleDansLObjetTriangle() {
		Point2D pointA = new Point2D("A", 0.0, 4.0);
		Point2D pointB = new Point2D("B", 3.0, 0.0);
		Point2D pointC = new Point2D("C", 0.0, 0.0);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		t1.afficher();
		t1.setListeSegmentEligible();
		t1.afficher();
	}
	
	public void identifierSiUnPointAppartientAUneListeDePoints() {
		List<Point2D> lpS = new ArrayList<Point2D>();
		List<Point2D> lpT = new ArrayList<Point2D>();
		Point2D p1 = new Point2D("A", 0.0, 0.0);
		Point2D p2 = new Point2D("B", 0.0, 4.0);
		Point2D p3 = new Point2D("C", 5.0, 0.0);
		lpS.add(p1);
		lpS.add(p3);
		lpT.add(p1);
		lpT.add(p2);
		lpT.add(p3);
		System.out.println(lpS.contains(p1));
		System.out.println(lpS.contains(p2));
		System.out.println(lpS.contains(p3));
	}
	
	public void récupérerLePointDuTriangleNonInclusDansLeSegmentDuTriangle() {
		Point2D pointA = new Point2D("A", 0.0, 4.0);
		Point2D pointB = new Point2D("B", 3.0, 0.0);
		Point2D pointC = new Point2D("C", 0.0, 0.0);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		Segment s = new Segment("S1", pointC, pointB);
		t1.getPointNonAppartenantSegment(s).afficher();
	}
	
	public void identifierLaPositionDuPointIntersectionParRapportAuSegment() {
		Point2D pointA = new Point2D("A", 4.0, 4.0);
		Point2D pointB = new Point2D("B", 2.0, 12.0);
		Point2D pointC = new Point2D("C", 4.0, 0.0);
		Segment s = new Segment("s1", pointA, pointB);
		System.out.println(s.getDispositionPointFromSegment(pointC));
	}
	
	public void identifierSiUnPointCorrespondALUnDesPointsDuTriangle() {
		Point2D pointA = new Point2D("A", 0.0, 4.0);
		Point2D pointB = new Point2D("B", 3.0, 0.0);
		Point2D pointC = new Point2D("C", 0.0, 0.0);
		Point2D pointD = new Point2D("D", 3.0, 5.0);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		System.out.println(t1.estUnPointDuTriangle(pointD));
	}
	
	public void identifierLePointDuTriangleCorrespondantAUnAutrePoint() {
		Point2D pointA = new Point2D("A", 0.0, 4.0);
		Point2D pointB = new Point2D("B", 3.0, 0.0);
		Point2D pointC = new Point2D("C", 0.0, 0.0);
		Point2D pointD = new Point2D("D", 0.0, 4.0);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		t1.PointDuTriangle(pointD).afficher();
	}
	
	public void CreationListeContenantSegmentsPourCalcul() {
		Point2D pointA = new Point2D("A", 4.0, 4.0);
		Point2D pointB = new Point2D("B", 2.0, 12.0);
		Segment s = new Segment("s1", pointA, pointB);
		System.out.print("Point gauche : ");
		s.getPointGauche().afficher();
		System.out.print("Point droit : ");
		s.getPointDroit().afficher();
	}
	
	public void ListerSegmentsPourCalculerAire() {
		Point2D pointA = new Point2D("A", 4.0, 4.0);
		Point2D pointB = new Point2D("B", 2.0, 12.0);
		Point2D pointC = new Point2D("C", 0.0, 0.0);
		Point2D pointI = new Point2D("I", 2.0, 12.0);
		Segment s = new Segment("s1", pointA, pointB);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		List<Segment> ls = t1.getListSegmentForCalcul(s, pointI);
		for (Segment segment : ls) {
			segment.afficher();
		}
	}
	
	public void CreationMappingNomSegmentEtDistance() {
		Point2D pointA = new Point2D("A", 0.0, 0.0);
		Point2D pointB = new Point2D("B", 4.0, 0.0);
		Point2D pointC = new Point2D("C", 2.0, 4.0);
		Point2D pointI = new Point2D("I", 2.0, 0.0);
		Segment s = new Segment("s1", pointA, pointB);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		List<Segment> ls = t1.getListSegmentForCalcul(s, pointI);
		Map<String, Double> mapSegDis = Triangle.getMapSegmentDistancePourCalcul(ls);
		for (String key : mapSegDis.keySet()) {
			System.out.println("clé : " + key + " , valeur : " + mapSegDis.get(key));
		}
	}
	
	public void test_final() {
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
		
		// Définition du point correspondant à l'intersection d'une droite affine et de sa parallèle
		Point2D pointI = dFromSegElig.getPointIntersection(dFromSegEligPerp);
	}
}
