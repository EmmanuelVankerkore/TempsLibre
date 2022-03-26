package run;

import java.util.List;
import java.util.Map;

import entities.DroiteAffine;
import entities.Point2D;
import entities.Segment;
import entities.Triangle;

public class Run {
	
	public static void main(String[] args) {
		System.out.println("Bonjour");
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
}
