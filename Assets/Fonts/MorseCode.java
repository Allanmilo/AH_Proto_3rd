package exercises;

import java.util.HashMap;

public class MorseCode {

	public static void Run() {
		
		HashMap<String, String> dictionary = new HashMap<>();
        dictionary.put(" ", " ");
        dictionary.put("A", ".-");
        dictionary.put("B", "-...");
        dictionary.put("C", "-.-.");
        dictionary.put("D", "-..");
        dictionary.put("E", ".");
        dictionary.put("F", "..-.");
        dictionary.put("G", "--.");
        dictionary.put("H", "....");
        dictionary.put("I", "..");
        dictionary.put("J", ".---");
        dictionary.put("K", "-.-");
        dictionary.put("L", ".-..");
        dictionary.put("M", "--");
        dictionary.put("N", "-.");
        dictionary.put("O", "---");
        dictionary.put("P", ".--.");
        dictionary.put("Q", "--.-");
        dictionary.put("R", ".-.");
        dictionary.put("S", "...");
        dictionary.put("T", "-");
        dictionary.put("U", "..-");
        dictionary.put("V", "...-");
        dictionary.put("W", ".--");
        dictionary.put("X", "-..-");
        dictionary.put("Y", "-.--");
        dictionary.put("Z", "--..");

        dictionary.put("1", ".----");
        dictionary.put("2", "..---");
        dictionary.put("3", "...--");
        dictionary.put("4", "....-");
        dictionary.put("5", ".....");
        dictionary.put("6", "-....");
        dictionary.put("7", "--...");
        dictionary.put("8", "---..");
        dictionary.put("9", "----.");
        dictionary.put("0", "-----");
        
        String text = "this is morse code";
        System.out.println("text: " + text);
        
        String morse = "";
        
        for (char c : text.toCharArray()) {
        	
        	morse += dictionary.get((c + "").toUpperCase()) + " ";
        }
        
        System.out.println("morse: " + morse);
	}
}











