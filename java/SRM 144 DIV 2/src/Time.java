import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class Time {
	
	public String whatTime(int seconds) {
		int h = seconds / 3600;
		//(seconds - h * 3600) == (seconds % 3600)
		int m = (seconds % 3600) / 60;
		int s = seconds % 60;
		return h + ":" + m + ":" + s;
	}
}
