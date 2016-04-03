import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class CCipher {
	
	public String decode(String cipherText, int shift) {
		String aTwice = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ";
		StringBuffer sb = new StringBuffer();
		for (int i = 0; i < cipherText.length(); i++) {
			char ith = cipherText.charAt(i);
			int secondIndex = aTwice.lastIndexOf(ith);
			sb.append(aTwice.charAt(secondIndex - shift));
		}
		return sb.toString();
	}
}
