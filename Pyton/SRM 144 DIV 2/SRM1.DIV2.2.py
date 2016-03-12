import math,string

class BinaryCode:
	def decode(self, message):
		s1 = '0'
		s2 = '1'
		c1 = '0'
		c2 = '1'
		c1p = '0'
		c2p = '0'
		cPrev = '$'
		rev = ['1','0']
		m = [[['0','0','N','N'],['0','X','1','N'],['N','1','1','N'],['N','N','N','N']],[['N','N','N','N'],['N','0','0','N'],['N','0','X','1'],['N','N','1','1']]]
		z = ord('0')
		for c in message:
			if cPrev == '$':
				cPrev = c
				continue
			#print(ord(c2)-z,ord(c)-z,ord(cPrev)-z)
			#print(m[ord(c2)-z][ord(c)-z][ord(cPrev)-z])
			c1t = c1
			c2t = c2
			if c1 != 'N':
				c1 = m[ord(c1)-z][ord(c)-z][ord(cPrev)-z]
			if c2 != 'N':
				c2 = m[ord(c2)-z][ord(c)-z][ord(cPrev)-z]

			if c1 == 'X':
				c1 = rev[ord(c1p)-z]
			if c2 == 'X':
				c2 = rev[ord(c2p)-z]

			s1 += c1
			s2 += c2
			cPrev = c
			c1p = c1t
			c2p = c2t
			#print(c1, c2)
		if 'N' in s1:
			s1 = 'NONE'
		else:
			s1 = self.test(message,s1)
		if 'N' in s2:
			s2 = 'NONE'
		else:
			s2 = self.test(message,s2)
		return (s1, s2)
	def test(self, message, str):
		m = '0' + message + '0'
		s = '0' + str + '0'
		z = ord('0')
		for i in range(1, len(m)-1):
			tot = ord(s[i-1])+ord(s[i])+ord(s[i+1]) - 3*z
			if tot != (ord(m[i])-z):
				return 'NONE'
		return str

t = BinaryCode()
print(t.decode('123210122'))
		