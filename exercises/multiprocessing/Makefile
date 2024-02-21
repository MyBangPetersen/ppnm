CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output=$ --append --format "$$(nthreads) %e %U

Out.times.svg : out.times.txt
	echo '/
		set terminal svg background "white" ;/
		set

N = 2e8
out.times.txt : main.exe
	for nthreads in 1 2 3 4; do\
		 $(TIME) mono main.exe -nthreads:$$nthreads -terms:$(N);\
	done

main.exe : main.cs sfuns.dll; $(MKEXE)

clean:
        $(RM) *.exe *.dll [Oo]ut* [Ll]og*


