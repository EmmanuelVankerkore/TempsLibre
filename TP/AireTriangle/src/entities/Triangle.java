package entities;

import java.util.ArrayList;
import java.util.List;

public class Triangle {
	
	String nom;
	Point2D a;
	Point2D b;
	Point2D c;
	List<Segment> listeSegmenteligible;
	
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
	/*
	public List<Segment> getListeSegmentEligible(){
		return listeSegmentEligible;
	}
	
	public void setListeSegmentEligible() {
		this.listeSegmentEligible.
	}*/
	
	
	
	public void afficher() {
		System.out.println(getNom() + " est définit par les 3 points suivants:");
		System.out.print("   ");
		getA().afficher();
		System.out.print("   ");
		getB().afficher();
		System.out.print("   ");
		getC().afficher();
	}

	public List<Segment> getTousLesSegments(){
		List<Segment> listeDeTousLesSegments = new ArrayList<Segment>();
		listeDeTousLesSegments.add(new Segment("S1", a, b));
		listeDeTousLesSegments.add(new Segment("S2", b, c));
		listeDeTousLesSegments.add(new Segment("S3", c, a));
		return listeDeTousLesSegments;
	}
	
	public static Boolean estSegmentEligible(Segment segment) {
		if (segment.getPoint1().getX() - segment.getPoint2().getX() != 0.0 &&
				segment.getPoint1().getY() - segment.getPoint2().getY() != 0.0) {
			return true;
		} else {
			return false;
		}
	}
	
}
