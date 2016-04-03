import math,string

class Time:
	def whatTime(self,seconds):
		h = seconds // 3600
		m = (seconds - h*3600) // 60
		s = seconds - h*3600 - m*60
		return '{0}:{1}:{2}'.format(h, m, s)

# test code
t = Time()
print(t.whatTime(3665))
		