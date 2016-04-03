import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class TreeAndVertex {
	
	public int get(int[] tree) {
		int n = tree.length;
		int a[] = new int[101];

		for (int i = 0; i < n; i++) {
			a[tree[i]]++;
			a[i+1]++;
		}
		int max = Integer.MIN_VALUE;
		for (int i = 0; i <= n; i++) {
			if(a[i] > max) max = a[i];
		}

		return max;
	}
}
