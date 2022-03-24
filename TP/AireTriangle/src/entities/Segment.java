package entities;

import java.util.ArrayList;
import java.util.List;

public class Segment {
	
	String name;
	Point2D point1;
	Point2D point2;

	public Segment(String nom, Point2D pointA, Point2D pointB) {
		setName(nom);
		setPoint1(pointA);
		setPoint2(pointB);
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Point2D getPoint1() {
		return point1;
	}

	public void setPoint1(Point2D point1) {
		this.point1 = point1;
	}

	public Point2D getPoint2() {
		return point2;
	}

	public void setPoint2(Point2D point2) {
		this.point2 = point2;
	}
	
	public void afficher() {
		System.out.println(getName() + " ==> [" + getPoint1().getNom() + " ; " + getPoint2().getNom() + "]");
	}
	
	public Double deltaEnX() {
		return getPoint1().getX() - getPoint2().getX();
	}
	
	public Double deltaEnY() {
		return getPoint1().getY() - getPoint2().getY();
	}
	
	public Double auCarre(Double valeur) {
		return Math.pow(valeur, 2);
	}
	
	public Double getTaille() {
		return Math.sqrt(auCarre(deltaEnX())+auCarre(deltaEnY()));
	}
	
	public List<Point2D> getTousLesPoints(){
		List<Point2D> lp = new ArrayList<Point2D>();
		lp.add(getPoint1());
		lp.add(getPoint2());
		return lp;
	}
	
}
