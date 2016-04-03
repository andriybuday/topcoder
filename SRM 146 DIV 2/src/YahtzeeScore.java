import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class YahtzeeScore {
	
	public int maxPoints(int[] toss) {
		int max = Integer.MIN_VALUE;
		for (int i = 1; i <= 6; i++) {
			int sum = 0;
			for (int j = 0; j < toss.length; j++) {
				if(toss[j]==i)sum+=toss[j];
			}
			if(sum>max){
				max=sum;
			}
		}
		return max;
	}
}
