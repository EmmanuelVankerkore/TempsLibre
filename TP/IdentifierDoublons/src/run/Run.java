package run;

import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

public class Run {
	
	static String input = "v4 | v1 | v2 | v3 | v2 | v4 | v5 | v4 | v6 | v10 | v5";

	public static void main(String[] args) {
		afficherInputEtOutput(input, trouverLesElementsEnDoublons(input));
	}
	
	public static List<String> texteVersListeAvecDoublons(String texteAvecDoublons){
		return Arrays.asList(texteAvecDoublons.split("\\W+"));
	}
	
	public static Set<String> listeAvecDoublonsVersListeSansDoublons(List<String> listeAvecDoublons){
		return new HashSet<>(listeAvecDoublons);
	}
	
	public static Map<String, Integer> TrouverNbOccurenceDepuisListeAvecDoublons(List<String> listeAvecDoublons, Set<String> listeSansDoublons){
		Map<String, Integer> elementEtOccurence = new HashMap<>();
		for (String elementListe : listeSansDoublons) {
			elementEtOccurence.put(elementListe, Collections.frequency(listeAvecDoublons, elementListe))  ;
		}
		return elementEtOccurence;
	}
	
	public static String TexteDesDoubons(Map<String, Integer> elementEtOccurence) {
		String texteDesDoubons = "";
		for (Map.Entry<String, Integer> mapentry : elementEtOccurence.entrySet()) {
			if (mapentry.getValue() > 1) {
				texteDesDoubons = texteDesDoubons.concat(mapentry.getKey() + " | ");
			}
		}
		return enlever3DerniersCaracteres(texteDesDoubons);
	}
	
	public static String enlever3DerniersCaracteres(String texteDesDoublonsImparfait) {
		return texteDesDoublonsImparfait.substring(0,texteDesDoublonsImparfait.length()-3);
	}
	
	public static String trouverLesElementsEnDoublons(String input) {
		List<String> listeAvecDoublons = texteVersListeAvecDoublons(input);
		Set<String> listeSansDoublons = listeAvecDoublonsVersListeSansDoublons(listeAvecDoublons);
		Map<String, Integer> elementsOccurences = TrouverNbOccurenceDepuisListeAvecDoublons(listeAvecDoublons, listeSansDoublons);
		return TexteDesDoubons(elementsOccurences); 
	}
	
	public static void afficherInputEtOutput(String input, String output) {
		System.out.println("Entrée : \n\n" + input + "\n");
		System.out.println("Sortie : \n\n" + output);
	}
}
