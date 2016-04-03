import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class MultiplicationTable2Easy {

	public String isGoodSet(int[] table, int[] t) {
		int n = (int)Math.sqrt(table.length);
		for (int i = 0; i < t.length; i++) {
			for (int j = 0; j < t.length; j++) {
				int val = table[t[i]*n + t[j]];
				boolean contains = false;
				for (int k = 0; k < t.length; k++) {
					if(val == t[k]){
						contains = true;
					}
				}
				if(!contains){
					return "Not Good";
				}
			}
		}

		return "Good";
	}
}
