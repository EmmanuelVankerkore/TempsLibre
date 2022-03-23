package run;

import entities.Point2D;
import entities.Segment;
import entities.Triangle;

public class Run {
	
	public static void main(String[] args) {
		System.out.println("Bonjour");
		Point2D pointA = new Point2D("A", 0.0, 5.0);
		Point2D pointB = new Point2D("B", 2.0, 0.0);
		Segment s1 = new Segment("s1", pointA, pointB);
		System.out.print("Le triangle s1 est éligible ? --> ");
		System.out.println(Triangle.estSegmentEligible(s1));
	}

}
