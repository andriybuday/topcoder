import java.util.*;
import java.math.*;

import static java.lang.Math.*;

public class BinaryCode {

  public String decode(String message, char r0) {
    if (message.length() == 1) {
      if (new String(new char[]{r0}).equals(message)) {
        return message;
      }
      return "NONE";
    }
    char[] m = message.toCharArray();
    char[] r = new char[m.length];
    r[0] = r0;
    int z = 48;
    for (int i = 1; i < m.length + 1; i++) {
      int ri = (m[i - 1] - z) - (r[i - 1] - z) - ((i - 2 >= 0 ? r[i - 2] : '0') - z);
      if (ri == 0 || ri == 1) {
        if (i < m.length) {
          r[i] = (char) (ri + z);
        } else if (ri == 1) {
          return "NONE";
        }
      } else {
        return "NONE";
      }
    }
    return new String(r);
  }

  public String[] decode(String message) {
    return new String[]{decode(message, '0'), decode(message, '1')};
  }
}
