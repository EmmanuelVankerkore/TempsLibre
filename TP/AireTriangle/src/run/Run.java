package run;

import java.util.List;

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
		List<Segment> ls = t1.getTousLesSegments();
		System.out.println("Ci-dessous la liste des segments eligibles:");
		List<Segment> ls2 = Triangle.getListeSegmentsEligibles(ls);
		for (Segment segment : ls2) {
			segment.afficher();
		}
	}

}
