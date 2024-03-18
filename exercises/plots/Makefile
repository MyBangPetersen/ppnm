CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.erf.gnuplot.svg : Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "erf(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Error function" ;\
		plot [-3:3]\
			"$<" with lines \
			,"erf.data.txt" using 1:2 with points pointtype 6 notitle \
			,"erf.data.txt" using (-($$1)):(-$$2)) with points pointtype 6 notitle ;\
	' | tee log.gpi | gnuplot


Out.gamma.gnuplot.svg : Out2.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "gamma(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Gamma function" ;\
		plot [-3:3]\
			"$<" with lines \
			,"gamma.data.txt" using (-($$1)):(-$$2)) with points pointtype 6 notitle ;\
	' | tee log2.gpi | gnuplot


Out.lngamma.gnuplot.svg : Out3.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel Ln"gamma(x)" ;\
		set tics out ;\
		set grid ;\
		set title "LnGamma function" ;\
		plot [-3:3]\
			"$<" with lines \
			,"lngamma.data.txt" using (-($$1)):(-$$2)) with points pointtype 6 notitle ;\
	' | tee log3.gpi | gnuplot



Out.txt: main.exe
	mono $< >$@

Out2.txt: main2.exe
	mono $< >$@

Out3.txt: main3.exe
	mono $< >$@



sfuns.dll : plots.cs ;$(MKLIB)

main.exe  : main.cs sfuns.dll; $(MKEXE)
main2.exe : main2.cs sfuns.dll; $(MKEXE)
main3.exe : main3.cs sfuns.dll; $(MKEXE)


clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og* *.svg log.gpi log2.gpi log3.gpi
