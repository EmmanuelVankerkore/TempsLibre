package run;

import entities.Point2D;
import entities.Segment;
import entities.Triangle;

public class Run {
	
	public static void main(String[] args) {
		System.out.println("Bonjour");
		Point2D pointA = new Point2D("A", 0.0, 4.0);
		Point2D pointB = new Point2D("B", 3.0, 0.0);
		Point2D pointC = new Point2D("C", 0.0, 0.0);
		Triangle t1 = new Triangle("T1", pointA, pointB, pointC);
		Segment s = new Segment("S1", pointC, pointB);
		t1.getPointNonAppartenantSegment(s).afficher();
	}

}
