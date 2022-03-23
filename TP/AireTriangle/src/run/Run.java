package run;

import java.util.List;

import entities.Point2D;
import entities.Segment;
import entities.Triangle;

public class Run {
	
	public static void main(String[] args) {
		System.out.println("Bonjour");
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

}
