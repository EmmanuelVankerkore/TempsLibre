package entities;

import java.awt.Point;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class Triangle {
	
	String nom;
	Point2D a;
	Point2D b;
	Point2D c;
	List<Segment> listeSegmentEligible;
	
	public Triangle(String name, Point2D p1, Point2D p2, Point2D p3) {
		setNom(name);
		setA(p1);
		setB(p2);
		setC(p3);
	}
	
	public String getNom() {
		return nom;
	}

	public void setNom(String nom) {
		this.nom = nom;
	}

	public Point2D getA() {
		return a;
	}

	public void setA(Point2D a) {
		this.a = a;
	}

	public Point2D getB() {
		return b;
	}

	public void setB(Point2D b) {
		this.b = b;
	}

	public Point2D getC() {
		return c;
	}

	public void setC(Point2D c) {
		this.c = c;
	}
	
	public List<Segment> getListeSegmentEligible(){
		return listeSegmentEligible;
	}
	
	public void setListeSegmentEligible() {
		this.listeSegmentEligible = getListeSegmentsEligibles(getTousLesSegments());
	}
	
	
	
	public void afficher() {
		System.out.println(getNom() + " est définit par les 3 points suivants:");
		System.out.print("   ");
		getA().afficher();
		System.out.print("   ");
		getB().afficher();
		System.out.print("   ");
		getC().afficher();
		if (getListeSegmentEligible() != null) {
			System.out.println("Les segments éligible du triangle sont les suivant:");
			for (Segment segment : getListeSegmentEligible()) {
				segment.afficher();
			}
		}
	}

	public List<Segment> getTousLesSegments(){
		List<Segment> listeDeTousLesSegments = new ArrayList<Segment>();
		listeDeTousLesSegments.add(new Segment("S1", a, b));
		listeDeTousLesSegments.add(new Segment("S2", b, c));
		listeDeTousLesSegments.add(new Segment("S3", c, a));
		return listeDeTousLesSegments;
	}
	
	public List<Point2D> getTousLesPoints(){
		List<Point2D> lp = new ArrayList<Point2D>();
		lp.add(getA());
		lp.add(getB());
		lp.add(getC());
		return lp;
	}
	
	public Point2D getPointNonAppartenantSegment(Segment seg) {
		for (Point2D p : getTousLesPoints()) {
			if (seg.getTousLesPoints().contains(p) == false) {
				return p;
			}
		}
		return null;
	}
	
	public Boolean estUnPointDuTriangle(Point2D point) {
		for (Point2D p : getTousLesPoints()) {
			if (p.getX().equals(point.getX()) && p.getY().equals(point.getY())) {
				return true;
			}
		}
		return false;
	}
	
	public Point2D PointDuTriangle(Point2D point) {
		for (Point2D p : getTousLesPoints()) {
			if (p.getX().equals(point.getX()) && p.getY().equals(point.getY())) {
				return p;
			}
		}
		return null;
	}
	
	public static Boolean estSegmentEligible(Segment segment) {
		if (segment.getPoint1().getX() - segment.getPoint2().getX() != 0.0 &&
				segment.getPoint1().getY() - segment.getPoint2().getY() != 0.0) {
			return true;
		} else {
			return false;
		}
	}
	
	public static List<Segment> getListeSegmentsEligibles(List<Segment> listSeg){
		List<Segment> ls = new ArrayList<Segment>();
		for (Segment segment : listSeg) {
			if (estSegmentEligible(segment)) {
				ls.add(segment);
			}
		}
		return ls;
	}
	
}
