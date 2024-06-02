matrix.dll : vector.cs matrix.cs
	mcs -target:library -out:$@ $^

tot.dll : QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ QRGS.cs

main.exe : main.cs matrix.dll
	mcs main.cs -reference:matrix.dll -target:exe -out:main.exe

Erf.gnuplot.svg : erf.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right top ;\
		set tics out ;\
		set grid ;\
		plot \
			"erf.txt" using 1:2 with lines title "Erf" ;\
	' | tee log.gpi | gnuplot


clean :
	rm -f *.dll *.exe *.txt *.svg bestfit*.txt
