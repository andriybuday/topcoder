import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class DivisorDigits {
	
	public int howMany(int number) {
		int numberCopy = number;
		int counter = 0;
		while (numberCopy != 0) {
			int r = numberCopy % 10;
			numberCopy /= 10;
			if(r != 0 && number % r == 0) {
				counter ++;
			}
		}
		return counter;
	}
}
