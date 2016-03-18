import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class ImageDithering {
	
	public int count(String dithered, String[] screen) {
		int count = 0;
		for (int i = 0; i < screen.length; i++) {
			for (int j = 0; j < screen[i].length(); j++) {
				char c = screen[i].charAt(j);
				if(dithered.indexOf(c) > -1){
					count++;
				}
			}
		}
		return count;
	}
}
